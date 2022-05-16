using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MProject.Unit;

namespace MProject.Animation {

    public class StandAnimation : SceneLinkedSMB<UnitActor> {

        public override void OnSLStateNoTransitionUpdate(Animator _animator, AnimatorStateInfo _info, int _layer) {
            if (component == null) {
                return;
            }

            if (component.MDirection.magnitude > 0) {
                component.animation_controller.Set(AnimationPrority.Middle, component.origin.Animation_Map[AnimationType.Movement]);
                return;
            }
        }

    }
}