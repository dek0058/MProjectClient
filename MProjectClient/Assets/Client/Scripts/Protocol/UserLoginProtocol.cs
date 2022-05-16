using System;
using System.Collections;
using System.Collections.Generic;
using FlatBuffers;
using MProject.Packet;
using MProject.Utility;
using MProject.Network;
using MProject.Manager;


namespace MProject.Protocol {
    public class UserLoginProtocol : IBaseProtocol{

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

        static public FPacket CreatePacket() {
            var builder = new FlatBufferBuilder(GlobalDefine.PACKET_MAX_SIZE);
            NUserLoginPacket.StartNUserLoginPacket(builder);
            var packet_offset = NUserLoginPacket.EndNUserLoginPacket(builder);

            builder.Finish(packet_offset.Value);
            var buffer = builder.DataBuffer;
            
            var packet = new FPacket(Packet_Tag, Convert.ToUInt32(buffer.Length - buffer.Position), UserLoginProtocol.Hash_Code_Array, buffer.ToSizedArray());
            return packet;
        }

        public NUserLoginPacket Deserialize(FPacket _packet) {
            var buffer = _packet.data;
            var packet = NUserLoginPacket.GetRootAsNUserLoginPacket(new ByteBuffer(buffer));
            return packet;
        }
    }

    public class UserLoginProtocolHandler : BaseProtocolHandler {
        private UserLoginProtocol protocol_message;

        public UserLoginProtocolHandler() : base(new UserLoginProtocol()) {
            protocol_message = BaseProtocol as UserLoginProtocol;
        }

        public override void ReceivePacket(FPacket _packet) {
            
        }
    }
}
