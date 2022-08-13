using UnityEngine;
using Zenject;
using Yarn.Unity;

public class DialogServiceInstaller : MonoInstaller
{
    public DialogueService service;
    public override void InstallBindings()
    {
        var dialogueInstance = 
            Container.InstantiatePrefabForComponent<DialogueService>(
                service, Vector3.zero, Quaternion.identity, null);
        
        // dialogueInstance.runner = 

        Container.Bind<DialogueService>().FromInstance(dialogueInstance).AsSingle().NonLazy();
    }
}
