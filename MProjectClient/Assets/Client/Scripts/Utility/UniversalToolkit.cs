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


        static public Offset<Packet.FVector> Vector2Flatbuffer(FlatBufferBuilder _builder, Vector3 _vector) {
            return Packet.FVector.CreateFVector(_builder, _vector.x, _vector.y, _vector.z);
        }

        static public Offset<Packet.FQuaternion> Quaternion2Flatbuffer(FlatBufferBuilder _builder, Quaternion _quaternion) {
            return Packet.FQuaternion.CreateFQuaternion(_builder, _quaternion.x, _quaternion.y, _quaternion.z, _quaternion.w);
        }

        static public Offset<Packet.FTransform> Transform2Flatbuffer(FlatBufferBuilder _builder, Vector3 _position, Quaternion _rotation, Vector3 _scale) {
            return Packet.FTransform.CreateFTransform(_builder, Vector2Flatbuffer(_builder, _position), Quaternion2Flatbuffer(_builder, _rotation), Vector2Flatbuffer(_builder, _scale));
        }

    }
}
