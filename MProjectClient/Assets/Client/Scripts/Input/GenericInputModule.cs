using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MProject.Manager;
using UnityEngine.InputSystem.Interactions;

namespace MProject.Input {
    public class GenericInputModule : InputModule {

        public PlayerInput Player_Input { get; private set; }

        public override ModuleType Module_Type { get => ModuleType.Generic; }
        //SlowTapInteraction

        public override void Register(PlayerInput _player_input) {
            Player_Input = _player_input;

            // Movement
            var move_action = Player_Input.actions["Move"];
            move_action.started += OnMoveStart;
            move_action.performed += OnMovePerformed;
            move_action.canceled += OnMoveCanceld;
        }

        public override void Unregister() {
            // Movement
            var move_action = Player_Input.actions["Move"];
            move_action.started -= OnMoveStart;
            move_action.performed -= OnMovePerformed;
            move_action.canceled -= OnMoveCanceld;
        }

        private void OnMoveStart(InputAction.CallbackContext _context) {

        }

        private void OnMovePerformed(InputAction.CallbackContext _context) {

        }

        private void OnMoveCanceld(InputAction.CallbackContext _context) {

        }

        

    }
}