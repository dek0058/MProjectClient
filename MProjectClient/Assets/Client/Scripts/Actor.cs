using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MProject.Animation;

namespace MProject {
    public class Actor : MonoBehaviour {

        [SerializeReference]
        public AnimationController animation_controller = new AnimationController();

        private void Awake() {
        }


        private void OnEnable() {
            ActorAnimation.Initialize(animation_controller.animator, this);
        }

        private void Update() {
            animation_controller.Update();
        }

    }
}

