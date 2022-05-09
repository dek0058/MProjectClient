using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MProject.Manager;

namespace MProject.Input {
    public class GenericInputModule : InputModule {


        public override ModuleType Module_Type { get => ModuleType.Generic; }

        public override void Register(PlayerInput _player_input) {
        
        }
    }
}