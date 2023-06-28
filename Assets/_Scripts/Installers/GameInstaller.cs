using System;
using _Scripts.Gameplay;
using _Scripts.Services.AudioSystem;
using _Scripts.Services.CoroutineRunnerService;
using _Scripts.Services.Database;
using _Scripts.Services.InputService;
using _Scripts.Services.PauseHandlerService;
using _Scripts.Services.SceneLoadService;
using _Scripts.Services.StateMachines;
using _Scripts.Services.StateMachines.GameStateMachine;
using _Scripts.Services.StateMachines.GameStateMachine.GameStates;
using _Scripts.Services.StateMachines.LevelStateMachine.LevelStates;
using _Scripts.SO;
using _Scripts.UI;
using _Scripts.UI.UIInfrastructure.ViewControllers;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _fader;
        [SerializeField] private LevelsContainerConfig _levelsContainer;

        public override void InstallBindings()
        {
            BindFPSUnlocker();
            BindCoroutineStarter();
            BindSceneLoadService();
            BindStorage();
            BindDataReader();
            BindAudioController();
            BindPauseHandler();
            BindFadeScreen();
            BindGameStateMachine();
            BindFactories();
            BindProgressBarController();
            BindLevelContainerConfig();
            BindInputService();
        }

        private void BindInputService()
        {
            Container
                .Bind<IInputService>()
                .To<InputHandler>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
        }

        private void BindLevelContainerConfig()
        {
            Container
                .Bind<LevelsContainerConfig>()
                .FromScriptableObject(_levelsContainer)
                .AsSingle()
                .NonLazy();
        }

        private void BindProgressBarController()
        {
            Container
                .Bind<ProgressBarController>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindFactories()
        {
            Container.BindFactory<IStateMachine, GameStartState, GameStartState.Factory>();
            Container.BindFactory<IStateMachine, GameLoadState, GameLoadState.Factory>();
            Container.BindFactory<IStateMachine, GameRunState, GameRunState.Factory>();
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

        private void BindFadeScreen()
        {
            Container
                .BindInterfacesAndSelfTo<IFadeScreen>()
                .FromComponentsInNewPrefab(_fader)
                .AsSingle()
                .NonLazy();
        }

        private void BindPauseHandler()
        {
            Container
                .Bind<PauseHandler>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindAudioController()
        {
            Container
                .Bind<AudioController>()
                .AsSingle()
                .NonLazy();
        }

        private void BindStorage()
        {
            Container
            .Bind<IStorageService>()
            .To<JsonToFileStorage>()
            .FromNew()
            .AsSingle()
            .NonLazy();
        }

        private void BindDataReader()
        {
            Container
                .BindInterfacesAndSelfTo<DataReader>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindSceneLoadService()
        {
            Container
                .Bind<ISceneLoadService>()
                .To<SceneLoader>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindCoroutineStarter()
        {
            Container
            .Bind<ICoroutineRunner>()
            .To<CoroutineRunner>()
            .FromNewComponentOnNewGameObject()
            .AsSingle()
            .NonLazy();
        }

        private void BindFPSUnlocker()
        {
            Container
                .BindInterfacesAndSelfTo<FPSUnlocker>()
                .AsSingle()
                .NonLazy();
        }
    }
}
