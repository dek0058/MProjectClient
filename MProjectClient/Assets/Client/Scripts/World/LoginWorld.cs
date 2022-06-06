using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MProject.GameMode;
using MProject.Manager;

namespace MProject.World {
    public class LoginWorld : MWorld {

        public LoginGameMode LocalGameMode {
            get;
            private set;
        }

        public override void Load() {
            base.Load();

            LocalGameMode = GameMode as LoginGameMode;

        }

    }
}