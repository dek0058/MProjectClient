using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MProject.GameMode {
    public class BaseGameMode : MonoBehaviour {

        public GameModeType game_mode_type = GameModeType.None;
        

        public virtual void Initialize() {}
    }
}
