using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client {
    public class FirstSceneSystem : IEcsInitSystem {

        readonly EcsSharedInject<SharedData> _shared = default;

        public void Init (EcsSystems systems) {
            EcsWorld world = systems.GetWorld ();

            EcsPool<PlayerComponent> playersPool = world.GetPool<PlayerComponent>();
            EcsPool<RbComponent> rbPool = world.GetPool<RbComponent>();
            EcsPool<AnimatorComponent> animatorPool = world.GetPool<AnimatorComponent>();
            EcsPool<SpriteComponent> spritePool = world.GetPool<SpriteComponent>();
            EcsPool<RbDragComponent> rbDragPool = world.GetPool<RbDragComponent>();
            // EcsPool<InputComponent> inputPool = world.GetPool<InputComponent>();

            var player = _shared.Value.playerUnit.gameObject;
            // var player = GameObject.FindGameObjectWithTag("Player");
            var playerCharView = player.GetComponent<CharView>();

            var playerEnitity = world.NewEntity();
            playersPool.Add(playerEnitity);

            rbPool.Add(playerEnitity).rb = playerCharView.rb;
            animatorPool.Add(playerEnitity).animator = playerCharView.animator;
            spritePool.Add(playerEnitity).sprite = playerCharView.sprite;

            rbDragPool.Add(playerEnitity).xDrag = _shared.Value.playerSettings.startGroundDrag;
            rbDragPool.Get(playerEnitity).yDrag = _shared.Value.playerSettings.startAirDrag;

            // _shared.Value.inputService
            // inputPool.Add(playerEnitity);



            

        }
    }
}