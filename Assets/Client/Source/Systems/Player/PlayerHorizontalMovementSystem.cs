using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client
{
    // TODO: backwards speed
    public class PlayerGroundMovementSystem : IEcsRunSystem, IEcsInitSystem {        
        readonly EcsSharedInject<SharedData> _shared = default;

        struct PlayerSpeed
        {
            public float value;
        }

        public void Run (EcsSystems systems) {

            EcsWorld world = systems.GetWorld();
            var plSettings = systems.GetShared<SharedData>().playerSettings;
            var filter = world.Filter<PlayerComponent>().End ();//change filter in future it can broke othere states

            var rbInfoPool = world.GetPool<RbInfoComponent>();
            // var inputPool = world.GetPool<InputComponent>();
            var rbPool = world.GetPool<RbComponent>();
            var rbDragPool = world.GetPool<RbDragComponent>();
            var jumpCdPool = world.GetPool<JumpCd>();

            var playerSpeedPool = world.GetPool<PlayerSpeed>();

            foreach (var entity in filter)
            {
                // ref var input = ref inputPool.Get(entity);
                ref var rb = ref rbPool.Get(entity);
                ref var rbInfo = ref rbInfoPool.Get(entity);
                ref var rbDrag= ref rbDragPool.Get(entity);
                ref var jumpCd = ref jumpCdPool.Get(entity);

                if (!playerSpeedPool.Has(entity))
                {
                    playerSpeedPool.Add(entity);
                }
                ref var playerSpeed= ref playerSpeedPool.Get(entity);

                rbDrag.yDrag = 0f; 
                if (rbInfo.isBottomContact)
                {
                    playerSpeed.value = plSettings.groundSpeed;
                    rbDrag.xDrag = plSettings.groundDrag; 
                    var force = playerSpeed.value * _shared.Value.inputService.X_INPUT;
                    // var force = playerSpeed.value * input.x_input;

                    if(rbInfo.isOnSlope)
                    {
                        bool jumpCdDone = Time.time >= jumpCd.jumpCdStartTime + plSettings.jumpCd;
                        if (jumpCdDone)
                        {
                            rbDrag.yDrag = rbDrag.xDrag;
                            // force = plSettings.slopeSpeed * input.x_input;
                            force = plSettings.slopeSpeed * _shared.Value.inputService.X_INPUT;
                            rb.rb.AddForce(force * -rbInfo.slopePerpendicular.normalized);
                        }
                        else 
                        {
                            rb.rb.AddForce(force * Vector2.right);
                        }
                    }
                    else 
                    {
                        rb.rb.AddForce(force * Vector2.right);
                    }
                }
                else 
                {
                    bool isChangeDir = (_shared.Value.inputService.X_INPUT < -0.1 && rb.rb.velocity.x > 0.1) || (_shared.Value.inputService.X_INPUT > 0.1 && rb.rb.velocity.x < -0.1);
                    if (_shared.Value.inputService.X_INPUT == 0f || isChangeDir)
                    {
                        rbDrag.xDrag = plSettings.airDrag; 
                        playerSpeed.value = plSettings.airSpeed;
                    }
                    var force = playerSpeed.value* _shared.Value.inputService.X_INPUT;
                    rb.rb.AddForce(force * Vector2.right);
                }
                
            }
        }

        public void Init(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            var filter = world.Filter<PlayerComponent>().End ();//change filter in future it can broke othere states
            
            var playerSpeedPool = world.GetPool<PlayerSpeed>();

            foreach (var entity in filter)
            {
                playerSpeedPool.Add(entity);
                
            }
        }
    }
}