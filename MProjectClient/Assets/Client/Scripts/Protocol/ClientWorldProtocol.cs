using System;
using System.Collections.Generic;
using UnityEngine;
using FlatBuffers;
using MProject.Utility;
using MProject.Network;
using MProject.Player;
using MProject.Unit;
using MProject.Manager;

namespace MProject.Protocol {

    #region User Join World
    //! Send
    public class NC2S_JoinWorldProtocol : IBaseProtocol {
        private static byte[] Hash_Code_Array = new byte[GlobalDefine.PACKET_HASH_CODE_SIZE];
        static UInt32 Packet_Tag = (UInt32)Packet.Tag.C2S_JoinWorld;
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
        static public FPacket CreatePacket() {
            var builder = new FlatBufferBuilder(GlobalDefine.PACKET_MAX_SIZE);
            Packet.NC2S_JoinWorld.StartNC2S_JoinWorld(builder);
            var packet_offset = Packet.NC2S_JoinWorld.EndNC2S_JoinWorld(builder);
            builder.Finish(packet_offset.Value);
            var buffer = builder.DataBuffer;
            return new FPacket(Packet_Tag, Convert.ToUInt32(buffer.Length - buffer.Position), Hash_Code_Array, buffer.ToSizedArray());
        }
    }
    public class NC2S_JoinWorldProtocolHandler : BaseProtocolHandler {
        public NC2S_JoinWorldProtocolHandler() : base(new NC2S_JoinWorldProtocol()) {}
    }

    //! Receive
    public class NS2C_JoinWorldProtocol : IBaseProtocol {
        private static byte[] Hash_Code_Array = new byte[GlobalDefine.PACKET_HASH_CODE_SIZE];
        static UInt32 Packet_Tag = (UInt32)Packet.Tag.S2C_JoinWorld;
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
        static public UInt32 Deserialize(FPacket _packet) {
            var buffer = _packet.data;
            var data = Packet.NS2C_JoinWorld.GetRootAsNS2C_JoinWorld(new ByteBuffer(buffer));
            return data.WorldKey;
        }
    }
    public class NS2C_JoinWorldProtocolHandler : BaseProtocolHandler {
        public NS2C_JoinWorldProtocolHandler() : base(new NS2C_JoinWorldProtocol()) {}
        public override void ReceivePacket(FPacket _packet) {
            var data = NS2C_JoinWorldProtocol.Deserialize(_packet);
            WorldManager.Instance.JoinWorld ( data );
        }
    }
    #endregion


    #region User Left World
    //! Send
    public class NC2S_LeftWorldProtocol : IBaseProtocol {
        private static byte[] Hash_Code_Array = new byte[GlobalDefine.PACKET_HASH_CODE_SIZE];
        static UInt32 Packet_Tag = (UInt32)Packet.Tag.C2S_LeftWorld;
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
        static public FPacket CreatePacket() {
            var builder = new FlatBufferBuilder(GlobalDefine.PACKET_MAX_SIZE);
            Packet.NC2S_LeftWorld.StartNC2S_LeftWorld(builder);
            var packet_offset = Packet.NC2S_LeftWorld.EndNC2S_LeftWorld(builder);
            builder.Finish(packet_offset.Value);
            var buffer = builder.DataBuffer;
            return new FPacket(Packet_Tag, Convert.ToUInt32(buffer.Length - buffer.Position), Hash_Code_Array, buffer.ToSizedArray());
        }
    }
    public class NC2S_LeftWorldProtocolHandler : BaseProtocolHandler {
        public NC2S_LeftWorldProtocolHandler() : base(new NC2S_LeftWorldProtocol()) { }
    }

    //! Receive
    public class NS2C_LeftWorldProtocol : IBaseProtocol {
        private static byte[] Hash_Code_Array = new byte[GlobalDefine.PACKET_HASH_CODE_SIZE];
        static UInt32 Packet_Tag = (UInt32)Packet.Tag.S2C_LeftWorld;
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
        //static public Packet.NS2C_LeftWorld Deserialize(FPacket _packet) {
        //    var buffer = _packet.data;
        //    var data = Packet.NS2C_LeftWorld.GetRootAsNS2C_LeftWorld(new ByteBuffer(buffer));
        //    return data;
        //}
    }
    public class NS2C_LeftWorldProtocolHandler : BaseProtocolHandler {
        public NS2C_LeftWorldProtocolHandler() : base(new NS2C_LeftWorldProtocol()) { }
        public override void ReceivePacket(FPacket _packet) {
            //var data = NS2C_LeftWorldProtocol.Deserialize(_packet);
            
        }
    }
    #endregion


    //! Receive
    public class NS2C_JoinUserInWorldProtocol : IBaseProtocol {
        private static byte[] Hash_Code_Array = new byte[GlobalDefine.PACKET_HASH_CODE_SIZE];
        static UInt32 Packet_Tag = (UInt32)Packet.Tag.S2C_JoinUserInWorld;
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
        static public (UInt32, List<Packet.GPC>, List<Packet.Actor>) Deserialize(FPacket _packet) {
            var buffer = _packet.data;
            var data = Packet.NS2C_JoinUserInWorld.GetRootAsNS2C_JoinUserInWorld(new ByteBuffer(buffer));

            (UInt32, List<Packet.GPC>, List<Packet.Actor>) result;
            result.Item1 = data.WorldKey;

            result.Item2 = new List<Packet.GPC>();
            for (Int32 i = 0; i < data.PlayersLength; ++i) {
                var player = data.Players(i);
                if(false == player.HasValue) {
                    continue;
                }
                result.Item2.Add(player.Value);
            }

            result.Item3 = new List<Packet.Actor>();
            for (Int32 i = 0; i < data.ActorsLength; ++i) {
                var actor = data.Actors(i);
                if (false == actor.HasValue) {
                    continue;
                }
                result.Item3.Add(actor.Value);
            }

            return result;
        }
    }
    public class NS2C_JoinUserInWorldProtocolHandler : BaseProtocolHandler {
        public NS2C_JoinUserInWorldProtocolHandler() : base(new NS2C_JoinUserInWorldProtocol()) { }
        public override void ReceivePacket(FPacket _packet) {
            var data = NS2C_JoinUserInWorldProtocol.Deserialize(_packet);

            var world = WorldManager.Instance.GetWorld ( data.Item1 );
            if(null == world ) {
                Debug.LogFormat ( "World is null[{0}]", data.Item1 );
                return;
            }

            foreach(var game_player in data.Item2) {
                
            }

            foreach ( var actor in data.Item3 ) {
                //world.JoinActor( actor );
            }
            //WorldManager.Instance.JoinUserInWorld ( data.Item1, data.Item2, data.Item3 );

        }
    }


    //! Receive
    public class NS2C_LeftUserInWorldProtocol : IBaseProtocol {
        private static byte[] Hash_Code_Array = new byte[GlobalDefine.PACKET_HASH_CODE_SIZE];
        static UInt32 Packet_Tag = (UInt32)Packet.Tag.S2C_LeftUserInWorld;
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
        static public (UInt32, List<Packet.GPC>, List<Packet.Actor>) Deserialize(FPacket _packet) {
            var buffer = _packet.data;
            var data = Packet.NS2C_LeftUserInWorld.GetRootAsNS2C_LeftUserInWorld(new ByteBuffer(buffer));

            (UInt32, List<Packet.GPC>, List<Packet.Actor>) result;
            result.Item1 = data.WorldKey;

            result.Item2 = new List<Packet.GPC>();
            for (Int32 i = 0; i < data.PlayersLength; ++i) {
                var player = data.Players(i);
                if (false == player.HasValue) {
                    continue;
                }
                result.Item2.Add(player.Value);
            }

            result.Item3 = new List<Packet.Actor>();
            for (Int32 i = 0; i < data.ActorsLength; ++i) {
                var actor = data.Actors(i);
                if (false == actor.HasValue) {
                    continue;
                }
                result.Item3.Add(actor.Value);
            }

            return result;
        }
    }
    public class NS2C_LeftUserInWorldProtocolHandler : BaseProtocolHandler {
        public NS2C_LeftUserInWorldProtocolHandler() : base(new NS2C_LeftUserInWorldProtocol()) { }
        public override void ReceivePacket(FPacket _packet) {
            var data = NS2C_LeftUserInWorldProtocol.Deserialize(_packet);
            // Ã³¸®
        }
    }
}
