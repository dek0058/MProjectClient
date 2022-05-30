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
    public class NC2S_UserLoginProtocol : IBaseProtocol {
        private static byte[] Hash_Code_Array = new byte[GlobalDefine.PACKET_HASH_CODE_SIZE];
        static UInt32 Packet_Tag = (UInt32)Packet.Tag.C2S_UserLogin;
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
            Packet.NC2S_UserLogin.StartNC2S_UserLogin(builder);
            var packet_offset = Packet.NC2S_UserLogin.EndNC2S_UserLogin(builder);
            builder.Finish(packet_offset.Value);
            var buffer = builder.DataBuffer;
            return new FPacket(Packet_Tag, Convert.ToUInt32(buffer.Length - buffer.Position), Hash_Code_Array, buffer.ToSizedArray());
        }
    }
    public class NC2S_UserLoginProtocolHandler : BaseProtocolHandler {
        public NC2S_UserLoginProtocolHandler() : base(new NC2S_UserLoginProtocol()) { }
    }

    //! Receive
    public class NS2C_UserLoginProtocol : IBaseProtocol {
        private static byte[] Hash_Code_Array = new byte[GlobalDefine.PACKET_HASH_CODE_SIZE];
        static UInt32 Packet_Tag = (UInt32)Packet.Tag.S2C_UserLogin;
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
            var data = Packet.NS2C_UserLogin.GetRootAsNS2C_UserLogin(new ByteBuffer(buffer));
            return data.UserKey;
        }
    }
    public class NS2C_UserLoginProtocolHandler : BaseProtocolHandler {
        public NS2C_UserLoginProtocolHandler() : base(new NS2C_UserLoginProtocol()) { }
        public override void ReceivePacket(FPacket _packet) {
            var data = NS2C_JoinWorldProtocol.Deserialize(_packet);
        }
    }
    #endregion

    #region User Logout
    //! Send
    public class NC2S_UserLogoutProtocol : IBaseProtocol {
        private static byte[] Hash_Code_Array = new byte[GlobalDefine.PACKET_HASH_CODE_SIZE];
        static UInt32 Packet_Tag = (UInt32)Packet.Tag.C2S_UserLogout;
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
            Packet.NC2S_UserLogout.StartNC2S_UserLogout(builder);
            var packet_offset = Packet.NC2S_UserLogout.EndNC2S_UserLogout(builder);
            builder.Finish(packet_offset.Value);
            var buffer = builder.DataBuffer;
            return new FPacket(Packet_Tag, Convert.ToUInt32(buffer.Length - buffer.Position), Hash_Code_Array, buffer.ToSizedArray());
        }
    }
    public class NC2S_UserLogoutProtocolHandler : BaseProtocolHandler {
        public NC2S_UserLogoutProtocolHandler() : base(new NC2S_UserLogoutProtocol()) { }
    }

    //! Receive
    public class NS2C_UserLogoutProtocol : IBaseProtocol {
        private static byte[] Hash_Code_Array = new byte[GlobalDefine.PACKET_HASH_CODE_SIZE];
        static UInt32 Packet_Tag = (UInt32)Packet.Tag.S2C_UserLogout;
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
        //static public UInt32 Deserialize(FPacket _packet) {
        //    var buffer = _packet.data;
        //    var data = Packet.NS2C_UserLogin.GetRootAsNS2C_UserLogin(new ByteBuffer(buffer));
        //    return data.UserKey;
        //}
    }
    public class NS2C_UserLogoutProtocolHandler : BaseProtocolHandler {
        public NS2C_UserLogoutProtocolHandler() : base(new NS2C_UserLogoutProtocol()) { }
        public override void ReceivePacket(FPacket _packet) {
            //var data = NS2C_JoinWorldProtocol.Deserialize(_packet);
        }
    }
    #endregion

}