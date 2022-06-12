using System;
using System.Collections;
using System.Collections.Generic;
using MProject.Packet;
using MProject.Utility;
using MProject.Network;
using MProject.Manager;

namespace MProject.Protocol {
    public class ProtocolMessageProtocol : IBaseProtocol {
        private static byte[] Hash_Code_Array = new byte[GlobalDefine.PACKET_HASH_CODE_SIZE];
        static UInt32 Packet_Tag = (UInt32)Tag.Create;
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
        static public List<(UInt32, byte[])> Deserialize(FPacket _packet) {
            List<(UInt32, byte[])> result = new List<(uint, byte[])>();
            var byte_buffer = new FlatBuffers.ByteBuffer(_packet.data);
            var data = NProtocolMessage.GetRootAsNProtocolMessage(byte_buffer);
            for (Int32 i = 0; i < data.ProtocolLength; ++i) {
                var protocol = data.Protocol(i);
                var bytes = protocol.Value.GetHashCodeArray();
                result.Add((protocol.Value.Tag, bytes));
            }

            if (Hash_Code_Array == null) {
                Hash_Code_Array = _packet.hash_code;
            }

            return result;
        }
    }

    public class ProtocolMessageHandler : BaseProtocolHandler {
        public ProtocolMessageHandler() : base(new ProtocolMessageProtocol()) {}
        public override void ReceivePacket(FPacket _packet) {
            NetworkManager.Instance.Handler_Manager.ClearHandler();
            foreach (var (tag, hash_code) in ProtocolMessageProtocol.Deserialize(_packet)) {
                NetworkManager.Instance.Handler_Manager.RegisterHandler(tag, hash_code);
            }
            if(null == WorldManager.Instance.CurrentWorld) {
                Debug.LogError("WorldManager Current World is null!");
                return;
            }
            WorldManager.Instance.CurrentWorld.Connect();
        }
    }
}