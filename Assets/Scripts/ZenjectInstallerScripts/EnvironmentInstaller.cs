using ComponentsMonoScripts;
using Data;
using Factory;
using UnityEngine;
using Views;
using Zenject;

namespace ZenjectInstallerScripts
{
    public class EnvironmentInstaller : MonoInstaller
    {
        [SerializeField] private CrystalData crystalData;
        [SerializeField] private Transform environmentRoot;
        [SerializeField] private GameObject allPlatformsPrefab;

        public override void InstallBindings()
        {
            var platformInstance = Container.InstantiatePrefabForComponent<AllPlatformsComponents>(allPlatformsPrefab, environmentRoot);
            Container.Bind<CrystalData>().FromScriptableObject(crystalData).AsSingle().NonLazy();
            Container.Bind<AllPlatformsComponents>().FromInstance(platformInstance).AsSingle().NonLazy();
            Container.Bind<CrystalView>().FromFactory<CrystalFactory>().AsSingle();
        }
    }
}