using System;
using System.Collections.Generic;
using UnityEngine;
using MProject.Utility;
using MProject.Player;

namespace MProject.Manager {
    public class PlayerManager : USingleton<PlayerManager> {

        //public List<GPC> players = new List<GPC>();
        public Dictionary<UInt32, GPC> players = new Dictionary<uint, GPC>();

        private GPC local_player = null;
        public virtual GPC LocalPlayer {
            get {
                if(null == local_player) {
                    local_player = CreatePlayer<GPC>(0);
                }
                return local_player;
            } 
        }

        protected override void Enable() {
            LocalPlayer.Initialize(true);
        }


        private T CreatePlayer<T>(UInt32 _user_key, bool _is_local = false) where T : GPC {
            GameObject player_object = new GameObject("Player");
            player_object.transform.parent = transform;
            T player = player_object.AddComponent<T>();
            player.Initialize(_is_local);
            player.UserKey = _user_key;
            return player;
        }

        public void Join<T>(UInt32 _user_key, bool _is_local = false) where T : GPC {
            GPC player = null;
            if(true == _is_local) {
                player = LocalPlayer;
                player.UserKey = _user_key;
            } else {
                player = CreatePlayer<T>(_user_key);
            }
            if(null == player) {
                Debug.LogErrorFormat("Player is null [{0}]", _user_key);
                return;
            }
            Debug.LogFormat("Join User[{0}]", _user_key);
            players.Add(_user_key, player);
        }
        
        public void Left(UInt32 _user_key) {
            
        }

        //public GPC Join(GameModeType _game_mode_type) {
        //    GameObject player_object = new GameObject("Local Player");
        //    player_object.transform.parent = transform;
        //    var component = player_object.AddComponent(player_map[_game_mode_type]) as GPC;
        //    component.Initialize(true);
        //    players.Add(0, component);
        //    return component;
        //}
    }
}
