using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MProject.GameMode;
using MProject.Protocol;

namespace MProject.World {
    public class MWorld : MonoBehaviour {

        [SerializeField]
        private UInt32 key;

        [SerializeField]
        protected BaseGameMode gamemode;

        private Dictionary<UInt32/*Actor Key*/, Actor> actor_map = new Dictionary<uint, Actor>();

        public UInt32 WorldKey {
            get => key;
        }

        public BaseGameMode GameMode {
            get {
                return gamemode;
            }
                
            protected set {
                gamemode = value;
                gamemode.Initialize();
            }
        }


        public virtual void Load() {
            GameMode = gamemode;
        }
        
        public virtual void Join() {
        }
        
    }
}