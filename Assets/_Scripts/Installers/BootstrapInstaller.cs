using _Scripts.Services;
using _Scripts.Services.AudioSystem;
using _Scripts.Services.CoroutineRunnerService;
using _Scripts.Services.Database;
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
            BindISceneLoadService();
            BindStorage();
            BindDataContainer();
            BindAudioController();
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
            .To<JsonStorage>()
            .AsSingle()
            .NonLazy();
        }

        private void BindDataContainer()
        {
            Container
            .Bind<IDataContainer>()
            .To<GameDataContainer>()
            .FromNew()
            .AsSingle()
            .NonLazy();
        }

        private void BindISceneLoadService()
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
