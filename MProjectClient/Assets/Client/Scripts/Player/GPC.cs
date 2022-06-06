using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
     
namespace MProject.Player {
    // Game Player Controller
    public class GPC : MonoBehaviour {
        public enum ActorType {
            Main,
        }

        public UInt32 UserKey {
            get; set;
        }

        public virtual GameModeType InutType { 
            get => GameModeType.None; 
        }

        public bool Local {
            get;
            private set;
        }
        

        protected Dictionary<ActorType, Actor[]> actor_map = new Dictionary<ActorType, Actor[]>();


        public virtual void Initialize(bool _is_local = false) {
            Local = _is_local;
        }

    }
}
    
