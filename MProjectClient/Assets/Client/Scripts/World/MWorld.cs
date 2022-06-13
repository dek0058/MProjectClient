using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MProject.GameMode;
using MProject.Protocol;

namespace MProject.World {
    public class MWorld : MonoBehaviour {

        [SerializeField]
        private UInt32 key = 0;

        [SerializeField]
        bool conneceted = false;

        [SerializeField]
        protected BaseGameMode gamemode;

        private Dictionary<UInt32/*Actor Key*/, Actor> actor_map = new Dictionary<uint, Actor> ( );

        //! Getter

        public UInt32 WorldKey {
            get => key;
        }

        public bool Connected {
            get => conneceted;
            protected set => conneceted = value;
        }


        public BaseGameMode GameMode {
            get {
                return gamemode;
            }

            protected set {
                gamemode = value;
                gamemode.Initialize ( );
            }
        }


        public virtual void Load ( ) {
            GameMode = gamemode;
        }

        public virtual void Connect ( ) {
            Connected = true;
        }

        public virtual void Join ( ) {
        }

        public virtual void Left ( ) {
            Connected = false;
        }

        public void JoinActor ( Actor _actor ) {
            if(actor_map.ContainsKey(_actor.actor_key)) {
                actor_map.Add ( _actor.actor_key, _actor );
            }
        }

        public void LeftActor ( Actor _actor ) {

        }

        public Actor GetActor ( UInt32 _actor_key ) {
            if ( actor_map.ContainsKey ( _actor_key ) ) {
                return actor_map[_actor_key];
            }
            return null;
        }
    }
}