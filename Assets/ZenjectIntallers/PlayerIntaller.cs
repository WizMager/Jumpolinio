using UnityEngine;
using Zenject;

public class PlayerIntaller : MonoInstaller
{
    [SerializeField] private Player player;
    [SerializeField] private Transform playerSpawn;
    public override void InstallBindings()
    {
        var playerInstance =
            Container.InstantiatePrefabForComponent<Player>(player, playerSpawn.position, playerSpawn.rotation, null);

        Container.Bind<Player>().FromInstance(playerInstance).AsSingle().NonLazy();
    }
}