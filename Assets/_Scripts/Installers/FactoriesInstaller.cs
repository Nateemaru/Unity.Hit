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
            BindObjectPoolFactory();
            BindGameObjectFactory();
        }

        private void BindObjectPoolFactory()
        {
            Container.BindFactory<ObjectPool, ObjectPool.Factory>().FromNewComponentOnNewGameObject();
        }

        private void BindGameObjectFactory()
        {
            Container.BindFactory<GameObject, GameObjectFactory>().FromFactory<GameObjectFactory>();
        }
    }
}