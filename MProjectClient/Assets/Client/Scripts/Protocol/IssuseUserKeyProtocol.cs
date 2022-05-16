using System;
using System.Collections;
using System.Collections.Generic;
using FlatBuffers;
using MProject.Packet;
using MProject.Utility;
using MProject.Network;
using MProject.Manager;
using MProject.GameMode;
using MProject.Unit;
using UnityEngine;

namespace MProject.Protocol {
    
    public class IssuseUserKeyProtocol : IBaseProtocol {

        private static byte[] Hash_Code_Array = new byte[GlobalDefine.PACKET_HASH_CODE_SIZE];
        static UInt32 Packet_Tag = (UInt32)Tag.UserLogin;

        public byte[] GetHashCodeArray() {
            return Hash_Code_Array;
        }

        public string GetHashCodeString() {
            return UniversalToolkit.Digest2Hex(Hash_Code_Array);
        }

        public uint GetPacketTag() {
            return Packet_Tag;
        }

        public void SetHashCodeArray(byte[] _hash_code) {
            Hash_Code_Array = _hash_code;
        }

        static public FPacket CreatePacket(UInt32 _user_key) {
            var builder = new FlatBufferBuilder(GlobalDefine.PACKET_MAX_SIZE);
            NIssuseUserKeyPacket.StartNIssuseUserKeyPacket(builder);
            NIssuseUserKeyPacket.AddKey(builder, _user_key);
            var packet_offset = NIssuseUserKeyPacket.EndNIssuseUserKeyPacket(builder);

            builder.Finish(packet_offset.Value);
            var buffer = builder.DataBuffer;

            var packet = new FPacket(Packet_Tag, Convert.ToUInt32(buffer.Length - buffer.Position), IssuseUserKeyProtocol.Hash_Code_Array, buffer.ToSizedArray());
            return packet;
        }

        public NIssuseUserKeyPacket Deserialize(FPacket _packet) {
            var buffer = _packet.data;
            var packet = NIssuseUserKeyPacket.GetRootAsNIssuseUserKeyPacket(new ByteBuffer(buffer));
            return packet;
        }
    }

    public class IssuseUserKeyProtocolHandler : BaseProtocolHandler {
        private IssuseUserKeyProtocol protocol_message;

        public IssuseUserKeyProtocolHandler() : base(new IssuseUserKeyProtocol()) {
            protocol_message = BaseProtocol as IssuseUserKeyProtocol;
        }

        public override void ReceivePacket(FPacket _packet) {
            var data = protocol_message.Deserialize(_packet);
            Debug.Log("IssuseUserKeyProtocol 받음!:" + data.Key);

            NetworkManager.Instance.recv_callback.Enqueue(() => {
                var test_game_mode = WorldManager.Instance.Game_Mode as GameMode.TestGameMode;
                test_game_mode.CreateActor();
            });
        }
    }
}
