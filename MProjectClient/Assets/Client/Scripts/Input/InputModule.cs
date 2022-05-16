using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MProject.Input {

    

    public class InputModule : MonoBehaviour {

        public virtual GameModeType Module_Type { get => GameModeType.None; }

        public virtual void Register(PlayerInput _player_input) {}
        public virtual void Unregister() {}


    }
}
