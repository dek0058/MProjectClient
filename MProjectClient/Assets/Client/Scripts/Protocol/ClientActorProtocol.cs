using System;
using System.Collections.Generic;
using UnityEngine;
using FlatBuffers;
using MProject.Utility;
using MProject.Network;
using MProject.Player;
using MProject.Unit;

namespace MProject.Protocol {

    #region User Login
    //! Send
    public class NC2S_MoveActorInWorldProtocol : IBaseProtocol {
        private static byte[] Hash_Code_Array = new byte[GlobalDefine.PACKET_HASH_CODE_SIZE];
        static UInt32 Packet_Tag = (UInt32)Packet.Tag.C2S_MoveActorInWorld;
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
        static public FPacket CreatePacket(UInt32 _world_key, List<Actor> _actors) {
            var builder = new FlatBufferBuilder(GlobalDefine.PACKET_MAX_SIZE);

            // Build Actors
            var actor_vector = new Offset<Packet.Actor>[_actors.Count];
            for(Int32 i = 0; i < _actors.Count; ++i) {
                actor_vector[i] = _actors[i].ToFlatbuffer(builder);
            }
            var actors_offset = Packet.NC2S_MoveActorInWorld.CreateActorsVector(builder, actor_vector);

            Packet.NC2S_MoveActorInWorld.StartNC2S_MoveActorInWorld(builder);
            Packet.NC2S_MoveActorInWorld.AddWorldKey(builder, _world_key);
            Packet.NC2S_MoveActorInWorld.AddActors(builder, actors_offset);
            var packet_offset = Packet.NC2S_MoveActorInWorld.EndNC2S_MoveActorInWorld(builder);
            builder.Finish(packet_offset.Value);
            var buffer = builder.DataBuffer;
            return new FPacket(Packet_Tag, Convert.ToUInt32(buffer.Length - buffer.Position), Hash_Code_Array, buffer.ToSizedArray());
        }
    }
    public class NC2S_MoveActorInWorldProtocolHandler : BaseProtocolHandler {
        public NC2S_MoveActorInWorldProtocolHandler() : base(new NC2S_MoveActorInWorldProtocol()) { }
    }

    //! Receive
    public class NS2C_MoveActorInWorldProtocol : IBaseProtocol {
        private static byte[] Hash_Code_Array = new byte[GlobalDefine.PACKET_HASH_CODE_SIZE];
        static UInt32 Packet_Tag = (UInt32)Packet.Tag.S2C_MoveActorInWorld;
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
        static public (UInt32, List<Packet.Actor>) Deserialize(FPacket _packet) {
            var buffer = _packet.data;
            var data = Packet.NS2C_MoveActorInWorld.GetRootAsNS2C_MoveActorInWorld(new ByteBuffer(buffer));

            (UInt32, List<Packet.Actor>) result;
            result.Item1 = data.WorldKey;

            result.Item2 = new List<Packet.Actor>();
            for (Int32 i = 0; i < data.ActorsLength; ++i) {
                var actor = data.Actors(i);
                if (false == actor.HasValue) {
                    continue;
                }
                result.Item2.Add(actor.Value);
            }

            return result;
        }
    }
    public class NS2C_MoveActorInWorldProtocolHandler : BaseProtocolHandler {
        public NS2C_MoveActorInWorldProtocolHandler() : base(new NS2C_MoveActorInWorldProtocol()) { }
        public override void ReceivePacket(FPacket _packet) {
            var data = NS2C_MoveActorInWorldProtocol.Deserialize(_packet);
        }
    }
    #endregion
}