using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using MProject.Manager;
using MProject.Player;

namespace MProject.Input {
    public class GenericInputModule : InputModule {

        
        public PlayerInput Player_Input { get; private set; }
        public GenericPC Player_Controller { get; set; }
        public override GameModeType Module_Type { get => GameModeType.Generic; }

        public override void Register(PlayerInput _player_input) {
            Player_Input = _player_input;

            var move_action = Player_Input.actions["Move"];
            move_action.started += OnMoveStart;
            move_action.performed += OnMovePerformed;
            move_action.canceled += OnMoveCanceld;

            var lock_action = Player_Input.actions["Look"];
            lock_action.performed += OnLock;
            //lock_action.ReadValue<Vector2>();
            //lock_action.cont;
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
            Vector2 axis = _context.ReadValue<Vector2>();
            Player_Controller.OnMove(axis);
        }

        private void OnMoveCanceld(InputAction.CallbackContext _context) {
            Player_Controller.OnStop();
        }

        private void OnLock(InputAction.CallbackContext _context) {
            Vector2 axis = _context.ReadValue<Vector2>().normalized;
            Player_Controller.OnLock(axis);
        }
    }
}