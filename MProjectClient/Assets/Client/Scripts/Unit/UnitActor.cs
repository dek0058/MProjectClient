using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MProject.Unit {
    public class UnitActor : Actor, IUnit {

        [SerializeReference]
        public UnitController unit_controller = new UnitController();


        
        private void FixedUpdate() {
            unit_controller.Update();
        }
    }
}
