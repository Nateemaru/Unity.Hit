using _Scripts.AI;
using _Scripts.Gameplay;
using _Scripts.Player;
using _Scripts.Services;
using _Scripts.Services.GameStateMachine;
using _Scripts.Services.GameStateMachine.GameStates;
using _Scripts.Services.PauseHandlerService;
using _Scripts.SO;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private LevelsContainerConfig _levelsContainer;
        
        public override void InstallBindings()
        {
            BindGameStateMachine();
            BindPoolHub();
            BindEnemiesHasher();
            BindCameraHasher();
            BindLevelSpawner();
            BindLevelContainerConfig();
            BindTarget();
            BindLevelBootstrapper();
        }
        
        private void BindLevelBootstrapper()
        {
            Container
                .BindInterfacesAndSelfTo<LevelBootstrapper>()
                .AsSingle()
                .NonLazy();
        }

        private void BindTarget()
        {
            Container
                .Bind<ITarget>()
                .To<PlayerController>()
                .FromComponentInHierarchy()
                .WhenInjectedInto<EnemyBase>();
        }
        private void BindLevelContainerConfig()
        {
            Container
                .Bind<LevelsContainerConfig>()
                .FromScriptableObject(_levelsContainer)
                .AsSingle()
                .NonLazy();
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
                .Bind<IGameStateMachine>()
                .To<GameStateMachine>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}