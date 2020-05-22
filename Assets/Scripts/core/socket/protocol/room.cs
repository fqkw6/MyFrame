//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: room.proto
// Note: requires additional types generated from: common.proto
namespace room
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_join_match")]
  public partial class req_join_match : global::ProtoBuf.IExtensible
  {
    public req_join_match() {}
    
    private int _battle_type = (int)0;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"battle_type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((int)0)]
    public int battle_type
    {
      get { return _battle_type; }
      set { _battle_type = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"rsp_join_match")]
  public partial class rsp_join_match : global::ProtoBuf.IExtensible
  {
    public rsp_join_match() {}
    
    private int _result = (int)0;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((int)0)]
    public int result
    {
      get { return _result; }
      set { _result = value; }
    }
    private common.match_player _player = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"player", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public common.match_player player
    {
      get { return _player; }
      set { _player = value; }
    }
    private int _battle_type = (int)0;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"battle_type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((int)0)]
    public int battle_type
    {
      get { return _battle_type; }
      set { _battle_type = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ntf_join_match_mateinfo")]
  public partial class ntf_join_match_mateinfo : global::ProtoBuf.IExtensible
  {
    public ntf_join_match_mateinfo() {}
    
    private int _result = (int)0;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((int)0)]
    public int result
    {
      get { return _result; }
      set { _result = value; }
    }
    private readonly global::System.Collections.Generic.List<common.match_player> _mate_list = new global::System.Collections.Generic.List<common.match_player>();
    [global::ProtoBuf.ProtoMember(2, Name=@"mate_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<common.match_player> mate_list
    {
      get { return _mate_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ntf_join_match_result")]
  public partial class ntf_join_match_result : global::ProtoBuf.IExtensible
  {
    public ntf_join_match_result() {}
    
    private int _result = (int)0;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((int)0)]
    public int result
    {
      get { return _result; }
      set { _result = value; }
    }
    private int _battle_svr_id = (int)0;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"battle_svr_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((int)0)]
    public int battle_svr_id
    {
      get { return _battle_svr_id; }
      set { _battle_svr_id = value; }
    }
    private long _battle_id = (long)0;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"battle_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((long)0)]
    public long battle_id
    {
      get { return _battle_id; }
      set { _battle_id = value; }
    }
    private readonly global::System.Collections.Generic.List<common.match_player> _mate_list = new global::System.Collections.Generic.List<common.match_player>();
    [global::ProtoBuf.ProtoMember(4, Name=@"mate_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<common.match_player> mate_list
    {
      get { return _mate_list; }
    }
  
    private readonly global::System.Collections.Generic.List<common.match_player> _enemy_list = new global::System.Collections.Generic.List<common.match_player>();
    [global::ProtoBuf.ProtoMember(5, Name=@"enemy_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<common.match_player> enemy_list
    {
      get { return _enemy_list; }
    }
  
    private int _battle_type = (int)0;
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"battle_type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((int)0)]
    public int battle_type
    {
      get { return _battle_type; }
      set { _battle_type = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_cancel_join_match")]
  public partial class req_cancel_join_match : global::ProtoBuf.IExtensible
  {
    public req_cancel_join_match() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"rsp_cancel_join_match")]
  public partial class rsp_cancel_join_match : global::ProtoBuf.IExtensible
  {
    public rsp_cancel_join_match() {}
    
    private int _result = (int)0;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((int)0)]
    public int result
    {
      get { return _result; }
      set { _result = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}