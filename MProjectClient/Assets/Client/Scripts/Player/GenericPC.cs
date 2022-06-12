using System;
using System.Collections.Generic;
using UnityEngine;
using MProject.Unit;
using MProject.Input;
using MProject.Manager;
using MProject.Camera;
using MProject.GameMode;

namespace MProject.Player {
    public class GenericPC : GPC {

        public override GameModeType InutType {
            get => GameModeType.Generic;
        }

        public Actor Character {
            get => actor_map[ActorType.Main][0];
            set {
                actor_map[ActorType.Main][0] = value;
            }
        }

        private void Awake() {
            actor_map.Add(ActorType.Main, new Actor[1]);
        }


        public override void Initialize(bool _is_local = false) {
            base.Initialize(_is_local);
            if(true == Local) {
                var component = gameObject.AddComponent<GenericInputModule>() as GenericInputModule;
                component.Player_Controller = this;
            }
        }



        //! Command

        public void OnMove(Vector2 _axis) {
            UnitActor unit_actor = Character as UnitActor;
            if (unit_actor == null) {
                return;
            }

            //var test_game_mode = WorldManager.Instance.Game_Mode as TestGameMode;
            //if (null == test_game_mode) {
            //    return;
            //}
            //
            //unit_actor.SetDirection(_axis);
        }

        public void OnStop() {
            UnitActor unit_actor = Character as UnitActor;
            if (unit_actor != null) {
                unit_actor.SetDirection(Vector2.zero);
            }
        }

        public void OnLock(Vector2 _axis) {
            UnitActor unit_actor = Character as UnitActor;
            if (unit_actor == null) {
                return;
            }
            
            //var test_game_mode = WorldManager.Instance.Game_Mode as TestGameMode;
            //if(null == test_game_mode) {
            //    return;
            //}
            //
            //test_game_mode.third_person_camera.SetTarget(_axis);
            //var forward = test_game_mode.third_person_camera.target.forward;
            //unit_actor.SetRotation(new Vector2(forward.x, forward.z).normalized);
        }
    }
}
