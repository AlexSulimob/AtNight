using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client {
    // TODO: backwards animations of walk and jump
    public class PlayerAnimationSystem : IEcsRunSystem {        
        readonly EcsSharedInject<SharedData> _shared = default;

        public void Run (EcsSystems systems) {

            EcsWorld world = systems.GetWorld();
            var filter = world.Filter<PlayerComponent>().End ();//change filter in future it can broke othere states

            var rbInfoPool = world.GetPool<RbInfoComponent>();
            // var inputPool = world.GetPool<InputComponent>();
            var animatorPool = world.GetPool<AnimatorComponent>();
            var rbPool = world.GetPool<RbComponent>();
            var spritePool = world.GetPool<SpriteComponent>();

            var currentFaceDirStatePool = world.GetPool<CurrentFaceDirState>();

            foreach (var entity in filter)
            {
                
                ref var rbInfo = ref rbInfoPool.Get(entity);
                // ref var input = ref inputPool.Get(entity);
                ref var rb = ref rbPool.Get(entity).rb;
                ref var sprite = ref spritePool.Get(entity).sprite;
                ref var animator = ref animatorPool.Get(entity).animator;
                
                if (!currentFaceDirStatePool.Has(entity))
                {
                    currentFaceDirStatePool.Add(entity).faceDir = 1;
                }
                ref var curFaceDir = ref currentFaceDirStatePool.Get(entity);

                //get direction of view
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(_shared.Value.inputService.MOUSE_POS);
                Vector2 direction = (Vector2)worldPosition - rb.position;

                //jumping anim change
                animator.SetBool("isJumping", !rbInfo.isBottomContact);
                animator.SetFloat("jumpState", rb.velocity.y);

                if(direction.x > 0.1){
                    sprite.flipX = false;
                }
                else if (direction.x < -0.1){
                    sprite.flipX = true;
                }
               
                //change run anim
                if((Mathf.Abs(rb.velocity.x) > 1f) )
                {
                    animator.SetBool("isRunning", true);
                }
                else 
                {
                    animator.SetBool("isRunning", false);
                }

            }

        }
        struct CurrentFaceDirState 
        {
            public int faceDir;
        }
    }
}