// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace MProject.Packet
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct NC2S_JoinWorld : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_2_0_0(); }
  public static NC2S_JoinWorld GetRootAsNC2S_JoinWorld(ByteBuffer _bb) { return GetRootAsNC2S_JoinWorld(_bb, new NC2S_JoinWorld()); }
  public static NC2S_JoinWorld GetRootAsNC2S_JoinWorld(ByteBuffer _bb, NC2S_JoinWorld obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public NC2S_JoinWorld __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }


  public static void StartNC2S_JoinWorld(FlatBufferBuilder builder) { builder.StartTable(0); }
  public static Offset<MProject.Packet.NC2S_JoinWorld> EndNC2S_JoinWorld(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<MProject.Packet.NC2S_JoinWorld>(o);
  }
}


}
