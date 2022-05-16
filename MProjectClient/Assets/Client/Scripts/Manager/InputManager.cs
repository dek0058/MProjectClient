using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MProject.Utility;
using MProject.Input;
using MProject.Player;

namespace MProject.Manager {
    public class InputManager : USingleton<InputManager> {

        public PlayerInput player_input;


        private InputModule current_module;
        public InputModule Current_Module {
            get {
                return current_module;
            }
            private set {
                if (current_module != null) {
                    current_module.Unregister();
                }
                current_module = value;
                current_module.Register(player_input);
            }
            
        }


        public void Connect(GPC _PC) {
            Current_Module = _PC.gameObject.GetComponent<InputModule>();
            
        }


    }
}

