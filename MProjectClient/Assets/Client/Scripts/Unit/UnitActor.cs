using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem; //test

namespace MProject.Unit {
    public class UnitActor : Actor, IUnit {

        [SerializeReference]
        public UnitController unit_controller = new UnitController();

        

        public void Move(InputAction.CallbackContext context) {
           unit_controller.rigidbody.MovePosition(context.ReadValue<Vector2>());
        }
        
        private void FixedUpdate() {
            unit_controller.Update();
        }
    }
}
