using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MProject.Utility;
using MProject.Packet;
using MProject.Protocol;

namespace MProject.Network {


    public class HandlerManager {

        private SortedDictionary<string, BaseProtocolHandler> handler_map = new SortedDictionary<string, BaseProtocolHandler>();
        private SortedDictionary<UInt32, BaseProtocolHandler> handler_tag_map = new SortedDictionary<UInt32, BaseProtocolHandler>();

        public HandlerManager() {
            ClearHandler();
            RegisterHandler<ProtocolMessageHandler>();

            //! Client Login Protocol
            RegisterHandler<NC2S_UserLoginProtocolHandler>();
            RegisterHandler<NS2C_UserLoginProtocolHandler>();
            
            RegisterHandler<NC2S_UserLogoutProtocolHandler>();
            RegisterHandler<NS2C_UserLogoutProtocolHandler>();

            //! Client World Protocol
            RegisterHandler<NC2S_JoinWorldProtocolHandler>();
            RegisterHandler<NS2C_JoinWorldProtocolHandler>();

            RegisterHandler<NC2S_LeftWorldProtocolHandler>();
            RegisterHandler<NS2C_LeftWorldProtocolHandler>();


            RegisterHandler<NS2C_JoinUserInWorldProtocolHandler>();
            RegisterHandler<NS2C_LeftUserInWorldProtocolHandler>();

            //! Client Actor Protocol
            RegisterHandler<NC2S_MoveActorInWorldProtocolHandler>();
            RegisterHandler<NS2C_MoveActorInWorldProtocolHandler>();
            
        }

        public void RegisterHandler<T>() where T : BaseProtocolHandler, new() {
            var handler = new T();
            if (handler_tag_map.ContainsKey(handler.GetPacketTag())) {
                Debug.LogWarning("[HandlerManager] Handler already registered");
                return;
            }
            handler_tag_map.Add(handler.GetPacketTag(), handler);
        }

        public void RegisterHandler(UInt32 _tag, byte[] _hash_code) {
            if (!handler_tag_map.ContainsKey(_tag)) {
                Debug.LogWarningFormat("[HandlerManager] Handler not registered[{0}]", (Packet.Tag)_tag);
                return;
            }

            string hash_code_string = UniversalToolkit.Digest2Hex(_hash_code);
            if (handler_map.ContainsKey(hash_code_string)) {
                Debug.LogWarning("[HandlerManager] Handler already registered");
                return;
            }

            var handler = handler_tag_map[_tag];
            handler.SetHashCodeArray(_hash_code);
            handler_map.Add(hash_code_string, handler);
        }

        public void UnregisterHanlder(UInt32 _tag) {
            if (!handler_tag_map.ContainsKey(_tag)) {
                Debug.LogWarning("[HandlerManager] Handler not registered");
                return;
            }
            handler_tag_map.Remove(_tag);
        }

        public void UnregisterHanlder(string _hash_code) {
            if (!handler_map.ContainsKey(_hash_code)) {
                Debug.LogWarning("[HandlerManager] Handler not registered");
                return;
            }
            handler_map.Remove(_hash_code);
        }

        public void ClearHandler() {
            handler_map.Clear();
        }

        public void ReceivePacket(FPacket _packet) {
            if (!handler_tag_map.ContainsKey(_packet.tag)) {
                Debug.LogWarningFormat("[HandlerManager] Handler not registered [{0}]", (Packet.Tag)_packet.tag);
                return;
            } else if ((Tag)_packet.tag == Tag.Create) {
                handler_tag_map[_packet.tag].ReceivePacket(_packet);
                Debug.LogFormat("[ReceivePacket]{0}", Tag.Create);
                return;
            }

            string hash_key = UniversalToolkit.Digest2Hex(_packet.hash_code);
            if (!handler_map.ContainsKey(hash_key)) {
                Debug.LogWarningFormat("[HandlerManager] No handler for packet[{0}]", (Packet.Tag)_packet.tag);
                return;
            }
            handler_map[hash_key].ReceivePacket(_packet);
            Debug.LogFormat("[ReceivePacket]{0}", (Packet.Tag)handler_map[hash_key].GetPacketTag());
        }
    }
}