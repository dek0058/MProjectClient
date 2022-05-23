// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace MProject.Packet
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct Actor : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_2_0_0(); }
  public static Actor GetRootAsActor(ByteBuffer _bb) { return GetRootAsActor(_bb, new Actor()); }
  public static Actor GetRootAsActor(ByteBuffer _bb, Actor obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Actor __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint ActorKey { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public uint UserKey { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public MProject.Packet.Transform? Transform { get { int o = __p.__offset(8); return o != 0 ? (MProject.Packet.Transform?)(new MProject.Packet.Transform()).__assign(__p.__indirect(o + __p.bb_pos), __p.bb) : null; } }

  public static Offset<MProject.Packet.Actor> CreateActor(FlatBufferBuilder builder,
      uint actor_key = 0,
      uint user_key = 0,
      Offset<MProject.Packet.Transform> transformOffset = default(Offset<MProject.Packet.Transform>)) {
    builder.StartTable(3);
    Actor.AddTransform(builder, transformOffset);
    Actor.AddUserKey(builder, user_key);
    Actor.AddActorKey(builder, actor_key);
    return Actor.EndActor(builder);
  }

  public static void StartActor(FlatBufferBuilder builder) { builder.StartTable(3); }
  public static void AddActorKey(FlatBufferBuilder builder, uint actorKey) { builder.AddUint(0, actorKey, 0); }
  public static void AddUserKey(FlatBufferBuilder builder, uint userKey) { builder.AddUint(1, userKey, 0); }
  public static void AddTransform(FlatBufferBuilder builder, Offset<MProject.Packet.Transform> transformOffset) { builder.AddOffset(2, transformOffset.Value, 0); }
  public static Offset<MProject.Packet.Actor> EndActor(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<MProject.Packet.Actor>(o);
  }
}


}
