using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MProject.Animation {

    public class ActorAnimation : SceneLinkedSMB<Actor> {

        [SerializeField]
        private float exit_time = 1.0F;

        [SerializeField]
        private AnimationType animation_type;

        public override void OnSLStateEnter(Animator _animator, AnimatorStateInfo _state_info, int layer_index) {
            if (component == null) {
                return;
            }
            component.animation_controller.Current_State = animation_type;
        }
        
        public override void OnSLStateNoTransitionUpdate(Animator _animator, AnimatorStateInfo _info, int _layer) {
            if (component == null) {
                return;
            }
            component.animation_controller.Current_State = animation_type;
            if (_info.normalizedTime >= exit_time) {
                component.animation_controller.Ready = true;
            }
        }
    }

}
