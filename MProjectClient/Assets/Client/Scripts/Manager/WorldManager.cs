using System;
using System.Collections.Generic;
using UnityEngine;
using MProject.Utility;
using MProject.GameMode;
using MProject.World;

namespace MProject.Manager {
    public class WorldManager : USingleton<WorldManager> {

        public MWorld current_world = null;
        public SortedDictionary<UInt32/*World Key*/, MWorld> world_map = new SortedDictionary<uint, MWorld>();


        public BaseGameMode Game_Mode {
            get;
            private set;
        }
        
        //! Getter

        public MWorld GetWorld(UInt32 _world_key) {
            return world_map.ContainsKey(_world_key) ? world_map[_world_key] : null;
        }
        
        public T GetWorld<T>(UInt32 _world_key) where T : MWorld {
            return world_map.ContainsKey(_world_key) ? world_map[_world_key] as T : null;
        }

        public T GetWorld<T>() where T : MWorld {
            foreach(var world in world_map) {
                if(world.Value is T) {
                    return world.Value as T;
                }
            }
            return null;
        }


        protected override void Enable() {
            //! Find Worlds
            foreach (var world in MonoBehaviour.FindObjectsOfType<MWorld>(true)) {
                world_map.Add(world.WorldKey, world);
            }

            current_world.Load();

        }

        public void JoinWorld(UInt32 _world_key) {
            var world = GetWorld(_world_key);
            if(null == world) {
                Debug.LogErrorFormat("World not find.[{0}]", _world_key);
                return;
            }
            world.Join();
        }

    }
}
