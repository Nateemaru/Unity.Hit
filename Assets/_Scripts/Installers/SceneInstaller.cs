using _Scripts.AI;
using _Scripts.Factories;
using _Scripts.Gameplay;
using _Scripts.Player;
using _Scripts.Services;
using _Scripts.Services.StateMachines;
using _Scripts.Services.StateMachines.GameStateMachine;
using _Scripts.Services.StateMachines.GameStateMachine.GameStates;
using _Scripts.Services.StateMachines.LevelStateMachine;
using _Scripts.Services.StateMachines.LevelStateMachine.LevelStates;
using _Scripts.SO;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameStateMachine();
            BindPoolHub();
            BindEnemiesHasher();
            BindCameraHasher();
            BindLevelSpawner();
            BindTarget();
            BindFactories();
        }

        private void BindFactories()
        {
            Container.BindFactory<IStateMachine, LevelInitState, LevelInitState.Factory>();
            Container.BindFactory<IStateMachine, LevelRunState, LevelRunState.Factory>();
            Container.BindFactory<IStateMachine, LevelPauseState, LevelPauseState.Factory>();
            Container.BindFactory<IStateMachine, LevelLoseState, LevelLoseState.Factory>();
            Container.BindFactory<IStateMachine, LevelWinState, LevelWinState.Factory>();
            Container.BindFactory<IStateMachine, LevelStartState, LevelStartState.Factory>();
            
            Container.BindFactory<ObjectPool, ObjectPool.Factory>().FromNewComponentOnNewGameObject();
            Container.BindFactory<GameObject, GameObjectFactory>().FromFactory<GameObjectFactory>();
        }

        private void BindTarget()
        {
            Container
                .Bind<ITarget>()
                .To<PlayerController>()
                .FromComponentInHierarchy()
                .WhenInjectedInto<EnemyBase>();
        }

        private void BindLevelSpawner()
        {
            Container
                .BindInterfacesAndSelfTo<LevelSpawner>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindCameraHasher()
        {
            Container
                .Bind<CameraHasher>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindPoolHub()
        {
            Container
                .Bind<PoolHub>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
        }

        private void BindEnemiesHasher()
        {
            Container
                .BindInterfacesAndSelfTo<EnemiesHasher>()
                .AsSingle()
                .NonLazy();
        }

        private void BindGameStateMachine()
        {
            Container
                .Bind<ILevelStateMachine>()
                .To<LevelStateMachine>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}