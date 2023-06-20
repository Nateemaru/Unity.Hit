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
            BindCamerasHasher();
            BindLevelSpawner();
            BindLevelContainerConfig();
            BindTarget();
            BindLevelBootstrapper();
        }
        
        private void BindLevelBootstrapper()
        {
            Container
                .Bind<LevelBootstrapper>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindTarget()
        {
            Container
                .Bind<ITarget>()
                .To<PlayerController>()
                .FromComponentInHierarchy()
                .AsSingle()
                .Lazy();
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
                .Bind<LevelSpawner>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindCamerasHasher()
        {
            Container
                .Bind<CamerasHasher>()
                .FromNewComponentOnNewGameObject()
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
                .Bind<EnemiesHasher>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindGameStateMachine()
        {
            Container.BindFactory<IGameStateMachine, GameStartState, GameStartState.Factory>();
            Container.BindFactory<IGameStateMachine, GameRunState, GameRunState.Factory>();
            Container.BindFactory<IGameStateMachine, GamePauseState, GamePauseState.Factory>();
            Container.BindFactory<IGameStateMachine, GameLoseState, GameLoseState.Factory>();
            Container.BindFactory<IGameStateMachine, GameWinState, GameWinState.Factory>();
            
            Container
                .Bind<IGameStateMachine>()
                .To<GameStateMachine>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}