using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace MProject.Camera {
    public class ThirdPersonCamera : MonoBehaviour {
        
        public CinemachineVirtualCamera VCamera {
            get; private set;
        }

        public Transform target;
        public Transform character;

        public float rotation_power;

        private void Awake() {
            VCamera = GetComponent<CinemachineVirtualCamera>();
        }


        public void SetTarget(Vector2 _axis) {

            target.rotation *= Quaternion.AngleAxis(_axis.x * rotation_power, Vector3.up);
            target.rotation *= Quaternion.AngleAxis(_axis.y * rotation_power, Vector3.right);

            var angles = target.localEulerAngles;
            angles.z = 0;

            var angle = target.localEulerAngles.x;

            //Clamp the Up/Down rotation
            if (angle > 180 && angle < 340) {
                angles.x = 340;
            } else if (angle < 180 && angle > 40) {
                angles.x = 40;
            }

            target.localEulerAngles = angles;
        }

        public void FixedUpdate() {
            if(character != null) {
                target.position = character.position;
            }
        }



    }
}