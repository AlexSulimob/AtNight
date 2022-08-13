using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Client {
    public class SharedData : MonoBehaviour
    {
        [Inject]
        public PlayerUnit playerUnit;
        [Inject]
        public InputService inputService;

        public PlayerSettings playerSettings;
        public PersistentData persistentData;
        private void Awake() {
            persistentData = new PersistentData();
            var data = SaveAndLoad.Load();

            if (data != null){
                Debug.Log("good loaad ");
                persistentData = data;
            }
            
        }
        private void OnDestroy() {

        }
    }

}
