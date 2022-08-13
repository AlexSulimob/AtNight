using UnityEngine;
using Zenject;

public class PlayerServiceInstaller : MonoInstaller
{
    public PlayerUnit playerPrefab;
    public override void InstallBindings()
    {
        var plyaerInstance = 
            Container.InstantiatePrefabForComponent<PlayerUnit>(
                playerPrefab, Vector3.zero, Quaternion.identity, null);

        Container.Bind<PlayerUnit>().FromInstance(plyaerInstance).AsSingle();
    }
}