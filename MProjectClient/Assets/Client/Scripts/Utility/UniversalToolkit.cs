using System;
using System.Text;
using UnityEngine;
using FlatBuffers;

namespace MProject.Utility {
    public class UniversalToolkit {

        static public string Digest2Hex(byte[] _data) {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in _data) {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }


        static public Offset<Packet.Vector> Vector2Flatbuffer(FlatBufferBuilder _builder, Vector3 _vector) {
            return Packet.Vector.CreateVector(_builder, _vector.x, _vector.y, _vector.z);
        }

        static public Offset<Packet.Quaternion> Quaternion2Flatbuffer(FlatBufferBuilder _builder, Quaternion _quaternion) {
            return Packet.Quaternion.CreateQuaternion(_builder, _quaternion.x, _quaternion.y, _quaternion.z, _quaternion.w);
        }

        static public Offset<Packet.Transform> Transform2Flatbuffer(FlatBufferBuilder _builder, Vector3 _position, Quaternion _rotation, Vector3 _scale) {
            return Packet.Transform.CreateTransform(_builder, Vector2Flatbuffer(_builder, _position), Quaternion2Flatbuffer(_builder, _rotation), Vector2Flatbuffer(_builder, _scale));
        }

    }
}
