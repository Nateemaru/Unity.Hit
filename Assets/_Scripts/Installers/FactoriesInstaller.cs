using _Scripts.AI;
using _Scripts.Factories;
using _Scripts.Services;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPoolFactory();
            BindGameObjectFactory();
        }

        private void BindPoolFactory()
        {
            Container.BindFactory<ObjectPool, PoolFactory>().FromFactory<PoolFactory>();
        }

        private void BindGameObjectFactory()
        {
            Container.BindFactory<GameObject, GameObjectFactory>().FromFactory<GameObjectFactory>();
        }
    }
}