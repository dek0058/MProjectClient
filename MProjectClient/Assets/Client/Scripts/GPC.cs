using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MProject {
    // Game Player Controller
    public class GPC : MonoBehaviour {

        private Dictionary<PlayerActorType, Actor> acotr_map = new Dictionary<PlayerActorType, Actor>();


        public Actor GetActor(PlayerActorType type) {
            if (true == acotr_map.ContainsKey(type)) {
                return acotr_map[type];
            }
            return null;
        }

        
    }
}
    
