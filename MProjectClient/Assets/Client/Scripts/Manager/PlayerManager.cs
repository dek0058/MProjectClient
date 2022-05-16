using System;
using System.Collections.Generic;
using UnityEngine;
using MProject.Utility;
using MProject.Player;

namespace MProject.Manager {
    public class PlayerManager : USingleton<PlayerManager> {

        private Dictionary<GameModeType, Type> player_map = new Dictionary<GameModeType, Type>();

        public SortedList<UInt32, GPC> players = new SortedList<uint, GPC>();

        public GPC Local_Player {
            get => players[0];
        }

        protected override void Enable() {
            player_map.Add(GameModeType.None, typeof(GPC));
            player_map.Add(GameModeType.Generic, typeof(GenericPC));
        }

        public GPC Join(GameModeType _game_mode_type) {
            GameObject player_object = new GameObject("Local Player");
            player_object.transform.parent = transform;
            var component = player_object.AddComponent(player_map[_game_mode_type]) as GPC;
            component.Initialize(true);
            players.Add(0, component);
            return component;
        }
    }
}
