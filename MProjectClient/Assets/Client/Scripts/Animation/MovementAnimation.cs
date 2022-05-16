using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MProject.Unit;

namespace MProject.Animation {

    public class MovementAnimation : SceneLinkedSMB<UnitActor> {
        public override void OnSLStateNoTransitionUpdate(Animator _animator, AnimatorStateInfo _info, int _layer) {
            if (component == null) {
                return;
            }
            
            if(component.MDirection.magnitude == 0) {
                component.animation_controller.Set(AnimationPrority.Middle, component.origin.Animation_Map[AnimationType.Stand]);
                return;
            }

            Vector3 forward = component.transform.forward;
            Vector3 right = component.transform.right;
            forward *= component.MDirection.z;
            right *= component.MDirection.x;
            var result = (forward + right).normalized * (component.Unit_Data.mspeed / 100.0F) * Time.deltaTime;
            result.y = 0;

            component.ARigidbody.MovePosition(component.ARigidbody.position + result);
            component.ARigidbody.MoveRotation(Quaternion.LookRotation(component.RDirection));
        }
    }
}