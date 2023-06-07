using _Scripts.Player;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private PlayerController _target;
        
        public override void InstallBindings()
        {
            BindTarget();
        }

        private void BindTarget()
        {
            Container
                .Bind<ITarget>()
                .To<PlayerController>()
                .FromInstance(_target)
                .AsSingle()
                .NonLazy();
        }
    }
}