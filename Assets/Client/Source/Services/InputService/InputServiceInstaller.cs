using UnityEngine;
using Zenject;

public class InputServiceInstaller : MonoInstaller
{
    InputService service;
    public override void InstallBindings()
    {
        service = new InputService();
        Container.Bind<InputService>().FromInstance(service).AsSingle().NonLazy();
    }
}