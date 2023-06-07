using System;
using _Scripts.Gameplay;
using _Scripts.Gameplay.FSM;
using _Scripts.Player;
using _Scripts.Services;
using _Scripts.SO;
using Animancer;
using RootMotion.Dynamics;
using UnityEngine;
using Zenject;

namespace _Scripts.AI
{
    public abstract class EnemyBase : MonoBehaviour, IEnemy
    {
        [SerializeField] protected UnitConfig _config;

        protected FSM _fsm;
        protected AnimancerComponent _animancer;
        protected HealthComponent _health;
        protected ITarget _target;
        protected PuppetMaster _puppetMaster;
        
        private EnemiesHasher _enemiesHasher;

        [Inject]
        private void Construct(EnemiesHasher enemiesHasher, ITarget target)
        {
            _enemiesHasher = enemiesHasher;
            _target = target;
        }

        protected void Start()
        {
            _animancer = GetComponentInChildren<AnimancerComponent>();
            _puppetMaster = GetComponentInChildren<PuppetMaster>();
            _health = GetComponent<HealthComponent>();
            _health.Initialize(_config.Hp);
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

        protected void Update()
        {
            _fsm?.UpdateMachine();
        }

        protected abstract void Init();
    }
}