using _Scripts.AI;
using _Scripts.Factories;
using _Scripts.Services;
using _Scripts.Services.GameStateMachine;
using _Scripts.Services.GameStateMachine.GameStates;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindObjectPoolFactory();
            BindGameObjectFactory();
            BindGameStatesFactories();
        }

        private void BindGameStatesFactories()
        {
            Container.BindFactory<IGameStateMachine, GameStartState, GameStartState.Factory>();
            Container.BindFactory<IGameStateMachine, GameRunState, GameRunState.Factory>();
            Container.BindFactory<IGameStateMachine, GamePauseState, GamePauseState.Factory>();
            Container.BindFactory<IGameStateMachine, GameLoseState, GameLoseState.Factory>();
            Container.BindFactory<IGameStateMachine, GameWinState, GameWinState.Factory>();
            Container.BindFactory<IGameStateMachine, SceneLoadState, SceneLoadState.Factory>();
        }

        private void BindObjectPoolFactory()
        {
            Container.BindFactory<ObjectPool, ObjectPool.Factory>().FromNewComponentOnNewGameObject();
        }

        private void BindGameObjectFactory()
        {
            Container.BindFactory<GameObject, GameObjectFactory>().FromFactory<GameObjectFactory>();
        }
    }
}