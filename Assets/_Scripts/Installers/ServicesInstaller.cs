using _Scripts.Services;
using Zenject;

namespace _Scripts.Installers
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPoolHub();
            BindEnemiesHasher();
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
    }
}