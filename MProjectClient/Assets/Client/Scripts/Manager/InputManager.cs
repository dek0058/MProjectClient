using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MProject.Utility;
using MProject.Input;

namespace MProject.Manager {
    public class InputManager : USingleton<InputManager> {

        public PlayerInput player_input;
        public InputModule.ModuleType input_module_type;
        
        public InputModule Module { get; private set; }
        private Dictionary<InputModule.ModuleType, InputModule> scene_input_module_map = new Dictionary<InputModule.ModuleType, InputModule>();

        private void Awake() {
            //! 첫 초기화시 모듈 장착
            foreach(var item in FindObjectsOfType<InputModule>(true)) {
                if(false == scene_input_module_map.TryAdd(item.Module_Type, item)) {
                    Debug.LogError("InputModuleType is duplicated.");
                    Debug.Break();
                }
            }
            if(false == scene_input_module_map.ContainsKey(input_module_type)) {
                Debug.LogError("InputModuleType is not found.");
                Debug.Break();
            }
            Module = scene_input_module_map[input_module_type];
            Module.Register(player_input);
        }



    }
}

