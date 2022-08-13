using LeoEcsPhysics;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client {
    sealed class EcsStartup : MonoBehaviour {

        EcsWorld _world;
        EcsSystems _update_systems;
        EcsSystems _fixed_systems;
        public SharedData data;

        void Start () {        
            _world = new EcsWorld();

            _update_systems = new EcsSystems (_world, data);
            _fixed_systems = new EcsSystems (_world, data);

            _update_systems
                .Add(new FirstSceneSystem())
                // .Add(new PlayerInputSystem())
                .Add(new PlayerJumpSystem())
                .Add(new PlayerAnimationSystem())
                // register your systems here, for example:
                // .Add (new TestSystem1 ())
                // .Add (new TestSystem2 ())
                
                // register additional worlds here, for example:
                // .AddWorld (new EcsWorld (), "events")
#if UNITY_EDITOR
                // add debug systems for custom worlds here, for example:
                // .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ("events"))
                .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ())
#endif
                .Inject()
                .Init ();
                
            _fixed_systems
                .Add(new RbPhysicsInfoSystem())
                .Add(new PlayerGroundMovementSystem())
                .Add(new RbDragSystem())
                .Add(new PlayerGravityControlSystem())

                .Inject()
                .Init ();
        }

        void Update () {
            if (Time.timeScale == 0) {
                return;
            }
            
            _update_systems?.Run ();
        }
        void FixedUpdate() {
            if (Time.timeScale == 0) {
                return;
            }
            _fixed_systems?.Run ();
        }

        void OnDestroy () {
            if (_update_systems != null) {

                _update_systems.Destroy ();
                _fixed_systems.Destroy ();
                // add here cleanup for custom worlds, for example:
                // _systems.GetWorld ("events").Destroy ();
                _update_systems.GetWorld ().Destroy ();
                _update_systems = null;

                _fixed_systems.GetWorld ().Destroy ();
                _fixed_systems = null;
            }
        }
    }
}