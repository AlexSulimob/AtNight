using LeoEcsPhysics;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client {
    public class PlayerDeathSystem : IEcsRunSystem {        
        readonly EcsSharedInject<SharedData> _shared = default;
        public void Run (EcsSystems systems) {

            var filter = systems.GetWorld().Filter<OnTriggerEnter2DEvent>().End();
            var pool = systems.GetWorld().GetPool<OnTriggerEnter2DEvent>();
            
            foreach (var entity in filter)
            {
                ref var eventData = ref pool.Get(entity);

                if(eventData.senderGameObject.tag == "Player" && eventData.collider2D.tag == "Death")
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    eventData.senderGameObject.SetActive(false);
                }

                if(eventData.senderGameObject.tag == "Player" && eventData.collider2D.tag == "CheckPoint")
                {
                    _shared.Value.persistentData.lastCheckPointPos = eventData.collider2D.transform.position;
                    SaveAndLoad.Save(_shared.Value.persistentData);
                    // eventData.senderGameObject.SetActive(false);
                }
            }
        }
    }
}