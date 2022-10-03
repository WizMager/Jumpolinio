using ComponentsMonoScripts;
using Data;
using MonoController.ControllerScripts;
using UnityEngine;
using Zenject;

namespace ZenjectInstallerScripts
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerData playerData;
        
        public override void InstallBindings()
        {
            var playerInstance = Container.InstantiatePrefabForComponent<PlayerComponents>(playerData.playerPrefab, playerData.playerSpawn.position, playerData.playerSpawn.rotation, null);

            Container.Bind<PlayerMove>().AsSingle().NonLazy();
            Container.Bind<PlayerComponents>().FromInstance(playerInstance).AsSingle().NonLazy();
            Container.Bind<PlayerData>().FromScriptableObject(playerData).AsSingle().NonLazy();
            Container.Bind<PlayerShoot>().AsSingle().NonLazy();
        }
    }
}