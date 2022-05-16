// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace MProject.Packet
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct NProtocolMessage : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_2_0_0(); }
  public static NProtocolMessage GetRootAsNProtocolMessage(ByteBuffer _bb) { return GetRootAsNProtocolMessage(_bb, new NProtocolMessage()); }
  public static NProtocolMessage GetRootAsNProtocolMessage(ByteBuffer _bb, NProtocolMessage obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public NProtocolMessage __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public MProject.Packet.FProtocol? Protocol(int j) { int o = __p.__offset(4); return o != 0 ? (MProject.Packet.FProtocol?)(new MProject.Packet.FProtocol()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int ProtocolLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<MProject.Packet.NProtocolMessage> CreateNProtocolMessage(FlatBufferBuilder builder,
      VectorOffset protocolOffset = default(VectorOffset)) {
    builder.StartTable(1);
    NProtocolMessage.AddProtocol(builder, protocolOffset);
    return NProtocolMessage.EndNProtocolMessage(builder);
  }

  public static void StartNProtocolMessage(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddProtocol(FlatBufferBuilder builder, VectorOffset protocolOffset) { builder.AddOffset(0, protocolOffset.Value, 0); }
  public static VectorOffset CreateProtocolVector(FlatBufferBuilder builder, Offset<MProject.Packet.FProtocol>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateProtocolVectorBlock(FlatBufferBuilder builder, Offset<MProject.Packet.FProtocol>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartProtocolVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<MProject.Packet.NProtocolMessage> EndNProtocolMessage(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<MProject.Packet.NProtocolMessage>(o);
  }
  public static void FinishNProtocolMessageBuffer(FlatBufferBuilder builder, Offset<MProject.Packet.NProtocolMessage> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedNProtocolMessageBuffer(FlatBufferBuilder builder, Offset<MProject.Packet.NProtocolMessage> offset) { builder.FinishSizePrefixed(offset.Value); }
}


}
