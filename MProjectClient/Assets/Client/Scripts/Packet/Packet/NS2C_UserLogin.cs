// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace MProject.Packet
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct NS2C_UserLogin : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_2_0_0(); }
  public static NS2C_UserLogin GetRootAsNS2C_UserLogin(ByteBuffer _bb) { return GetRootAsNS2C_UserLogin(_bb, new NS2C_UserLogin()); }
  public static NS2C_UserLogin GetRootAsNS2C_UserLogin(ByteBuffer _bb, NS2C_UserLogin obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public NS2C_UserLogin __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint UserKey { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }

  public static Offset<MProject.Packet.NS2C_UserLogin> CreateNS2C_UserLogin(FlatBufferBuilder builder,
      uint user_key = 0) {
    builder.StartTable(1);
    NS2C_UserLogin.AddUserKey(builder, user_key);
    return NS2C_UserLogin.EndNS2C_UserLogin(builder);
  }

  public static void StartNS2C_UserLogin(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddUserKey(FlatBufferBuilder builder, uint userKey) { builder.AddUint(0, userKey, 0); }
  public static Offset<MProject.Packet.NS2C_UserLogin> EndNS2C_UserLogin(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<MProject.Packet.NS2C_UserLogin>(o);
  }
}


}
