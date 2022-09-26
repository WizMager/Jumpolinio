using ComponentsMonoScripts;
using Data;
using MonoController.ControllerScripts;
using UnityEngine;
using Zenject;

namespace ZenjectInstallerScripts
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private CameraData cameraData;

        public override void InstallBindings()
        {
            var cameraInstance = Container.InstantiatePrefabForComponent<CameraComponents>(cameraData.cameraPrefab);
            
            Container.Bind<CameraMove>().AsSingle().NonLazy();
            Container.Bind<CameraComponents>().FromInstance(cameraInstance).AsSingle().NonLazy();
            Container.Bind<CameraData>().FromScriptableObject(cameraData).AsSingle().NonLazy();
        }
    }
}