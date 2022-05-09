using System;

namespace MProject.Network {
    public class BaseProtocolHandler {
        private IBaseProtocol base_protocol;
        public IBaseProtocol BaseProtocol {
            get { return base_protocol; }
        }

        public BaseProtocolHandler(IBaseProtocol _protocol)
            => base_protocol = _protocol;

        public byte[] GetHashCodeArray() {
            return BaseProtocol.GetHashCodeArray();
        }

        public string GetHashCodeString() {
            return BaseProtocol.GetHashCodeString();
        }

        public UInt32 GetPacketTag() {
            return BaseProtocol.GetPacketTag();
        }

        public void SetHashCodeArray(byte[] _hash_code) {
            BaseProtocol.SetHashCodeArray(_hash_code);
        }


        public virtual void ReceivePacket(FPacket _packet) {; }
    }

    public struct FPacket {
        public UInt32 tag;
        public UInt32 length;
        public byte[] hash_code;
        public byte[] data;
        public FPacket(UInt32 _tag, UInt32 _length, byte[] _hash_code, byte[] _data)
           => (tag, length, hash_code, data) = (_tag, _length, _hash_code, _data);
    }
}
