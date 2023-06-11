using System;
using _Scripts.Gameplay;
using _Scripts.Gameplay.FSM;
using _Scripts.Player;
using _Scripts.Services;
using _Scripts.SO;
using Animancer;
using RootMotion.Dynamics;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace _Scripts.AI
{
    public abstract class EnemyBase : MonoBehaviour, IEnemy
    {
        [TabGroup("Params")][SerializeField] protected UnitConfig _config;
        [TabGroup("Components")][SerializeField] protected AnimancerComponent _animancer;
        [TabGroup("Components")][SerializeField] protected PuppetMaster _puppetMaster;

        protected FSM _fsm;
        protected HealthComponent _health;
        protected ITarget _target;
        
        private EnemiesHasher _enemiesHasher;

        [Inject]
        private void Construct(EnemiesHasher enemiesHasher, ITarget target)
        {
            _enemiesHasher = enemiesHasher;
            _target = target;
        }

        protected virtual void Start()
        {
            _health = GetComponent<HealthComponent>();
            _health.Initialize(_config.Hp);
            _health.OnDeadAction += () =>
            {
                _enemiesHasher.Unregister(this);
                _puppetMaster.Kill();
            };
            _enemiesHasher.Register(this);
            
            Init();
        }

        private void OnEnable()
        {
            _enemiesHasher.Register(this);
        }

        private void OnDisable()
        {
            _enemiesHasher.Unregister(this);
        }

        protected virtual void Update()
        {
            if (_health.IsDead)
                return;
            
            _fsm?.UpdateMachine();
        }

        protected abstract void Init();
    }
}