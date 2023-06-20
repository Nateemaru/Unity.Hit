using _Scripts.Services;
using _Scripts.Services.GameStateMachine;
using _Scripts.Services.PauseHandlerService;
using Zenject;

namespace _Scripts.Installers
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPoolHub();
            BindEnemiesHasher();
            BindCamerasHasher();
            BindPauseHandler();
            BindGameStateMachine();
        }

        private void BindCamerasHasher()
        {
            Container
            .Bind<CamerasHasher>()
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
                .Bind<EnemiesHasher>()
                .FromNew()
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