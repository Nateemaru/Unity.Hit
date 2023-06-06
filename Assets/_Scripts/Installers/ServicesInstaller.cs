using _Scripts.Services;
using Zenject;

namespace _Scripts.Installers
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPoolHub();
        }

        private void BindPoolHub()
        {
            Container
                .Bind<PoolHub>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
        }
    }
}