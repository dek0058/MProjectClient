using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MProject.Animation;
using MProject.Player;
using MProject.Utility;

namespace MProject {
    [RequireComponent(typeof(Rigidbody))]
    public class Actor : MonoBehaviour {

        public UInt32 actor_key = 0;
        public GPC player {
            get; protected set;
        }

        [SerializeReference]
        public AnimationController animation_controller = new AnimationController();

        public Rigidbody ARigidbody { 
            get; private set; 
        }

        /// <summary>Movement Driection</summary>
        public virtual Vector3 MDirection {
            get=>Vector3.zero;
            protected set { ; }
        }

        /// <summary>Rotation Driection</summary>
        public virtual Vector3 RDirection {
            get => Vector3.zero; 
            protected set { ; }
        }

        public FlatBuffers.Offset<Packet.Actor> ToFlatbuffer(FlatBuffers.FlatBufferBuilder _builder) {
            return Packet.Actor.CreateActor(_builder, actor_key, player.UserKey, UniversalToolkit.Transform2Flatbuffer(_builder, transform.position, transform.rotation, transform.localScale));
        }

        protected virtual void Awake() {
            ARigidbody = GetComponent<Rigidbody>();
        }

        protected virtual void OnEnable() {
            SceneLinkedSMB<Actor>.Initialize(animation_controller.animator, this);
        }

        protected virtual void Update() {
            animation_controller.Update();
        }

    }
}

