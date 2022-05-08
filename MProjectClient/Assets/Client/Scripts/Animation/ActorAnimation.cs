using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MProject.Animation {

    public class ActorAnimation : SceneLinkedSMB<Actor> {

        [SerializeField]
        private float exit_time = 1.0F;

        public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo info, int layer) {
            if (component == null) {
                return;
            }
            if(info.normalizedTime >= exit_time) {
                component.animation_controller.Ready = true;
            }
        }
    }

}
