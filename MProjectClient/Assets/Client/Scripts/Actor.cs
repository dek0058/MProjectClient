using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MProject.Animation;

namespace MProject {
    [RequireComponent(typeof(Rigidbody))]
    public class Actor : MonoBehaviour {

        public UInt32 actor_key = 0;

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

