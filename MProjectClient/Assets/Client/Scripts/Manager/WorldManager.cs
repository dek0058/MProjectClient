using System;
using System.Collections.Generic;
using MProject.Utility;
using MProject.GameMode;

namespace MProject.Manager {
    public class WorldManager : USingleton<WorldManager> {

        public BaseGameMode Game_Mode {
            get;
            private set;
        }




        private void Start() {
            Initailize();
        }


        void Initailize() {
            Game_Mode = FindObjectOfType<BaseGameMode>();
            var player_manager = PlayerManager.Instance;
            var local_player = player_manager.Join(Game_Mode.game_mode_type);
            InputManager.Instance.Connect(local_player);

            
            Game_Mode.Initialize();
        }


    }
}
