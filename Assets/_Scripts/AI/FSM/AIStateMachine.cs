using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.AI.FSM
{
   public class AIStateMachine
   {
      private class Transition
      {
         public Func<bool> Condition { get; }
         public StateBase To { get; }
         public StateBase From { get; }

         public Transition(StateBase from, StateBase to, Func<bool> condition)
         {
            From = from;
            To = to;
            Condition = condition;
         }
      }

      private static readonly List<Transition> EmptyTransitions = new List<Transition>(0);

      private readonly Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type, List<Transition>>();
      private readonly List<Transition> _anyTransitions = new List<Transition>();

      private List<Transition> _currentTransitions = new List<Transition>();

      public StateBase CurrentState { get; private set; }

      // 0 = no decision delay
      private float _decisionDelay = 0;

      private float _timeOfNextPossibleDecision;

      public AIStateMachine(float decisionDelay = 0)
      {
         _decisionDelay = decisionDelay;
      }

      public void UpdateMachine()
      {
         Transition transition = GetTransition();
         if (transition != null)
            SetState(transition.To);

         CurrentState?.Update();
      }

      public void SetState(StateBase newState)
      {
         if (newState == CurrentState)
            return;

         if (_decisionDelay > 0)
         {
            // Wait for next possible decision time
            if (Time.time < _timeOfNextPossibleDecision)
               return;

            _timeOfNextPossibleDecision = Time.time + _decisionDelay;
         }

         CurrentState?.Exit();

         CurrentState = newState;

         _transitions.TryGetValue(CurrentState.GetType(), out _currentTransitions);
         if (_currentTransitions == null)
            _currentTransitions = EmptyTransitions;

         CurrentState.Enter();
      }

      public void AddTransition(StateBase from, StateBase to, Func<bool> predicate)
      {
         if (_transitions.TryGetValue(from.GetType(), out var transitions) == false)
         {
            transitions = new List<Transition>();
            _transitions[from.GetType()] = transitions;
         }

         transitions.Add(new Transition(from, to, predicate));
      }

      public void AddAnyTransition(StateBase state, Func<bool> predicate)
      {
         _anyTransitions.Add(new Transition(null, state, predicate));
      }

      private Transition GetTransition()
      {
         foreach (Transition transition in _anyTransitions)
         {
            if (transition.Condition())
               return transition;
         }

         foreach (Transition transition in _currentTransitions)
         {
            if (transition.Condition() && transition.From == CurrentState)
               return transition;
         }

         return null;
      }
   }
}
