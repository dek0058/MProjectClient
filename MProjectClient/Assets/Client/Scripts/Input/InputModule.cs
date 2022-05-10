using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MProject.Input {

    

    public class InputModule : MonoBehaviour {

        public enum ModuleType : byte {
            None = 0,
            Generic = 1,
        }

        public virtual ModuleType Module_Type { get => ModuleType.None; }

        public virtual void Register(PlayerInput _player_input) {}
        public virtual void Unregister() {}


    }
}
