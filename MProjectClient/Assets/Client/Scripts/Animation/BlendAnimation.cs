using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MProject.Animation {
    public class BlendAnimation : SceneLinkedSMB<Actor> {

        public override void OnSLStateEnter(Animator _animator, AnimatorStateInfo _state_info, int _layer_index) {
            if (component == null) {
                return;
            }
            _animator.SetFloat("MOVE_DIR_X", component.MDirection.x);
            _animator.SetFloat("MOVE_DIR_Y", component.MDirection.z);
        }
        public override void OnSLStateNoTransitionUpdate(Animator _animator, AnimatorStateInfo _info, int _layer) {
            if (component == null) {
                return;
            }
            _animator.SetFloat("MOVE_DIR_X", component.MDirection.x);
            _animator.SetFloat("MOVE_DIR_Y", component.MDirection.z);
        }
    }
}
