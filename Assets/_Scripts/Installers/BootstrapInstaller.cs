using _Scripts.Services.AudioSystem;
using _Scripts.Services.CoroutineRunnerService;
using _Scripts.Services.Database;
using _Scripts.Services.PauseHandlerService;
using _Scripts.Services.SceneLoadService;
using Zenject;

namespace _Scripts.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFPSUnlocker();
            BindCoroutineStarter();
            BindSceneLoadService();
            BindStorage();
            BindDataReader();
            BindAudioController();
            BindPauseHandler();
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
            .Bind<IDataReader>()
            .To<DataReader>()
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
                .Bind<FPSUnlocker>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}
