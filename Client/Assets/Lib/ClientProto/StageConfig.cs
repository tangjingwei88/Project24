//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: StageConfig.proto
namespace m
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"StageConfig")]
  public partial class StageConfig : global::ProtoBuf.IExtensible
  {
    public StageConfig() {}
    
    private int _RankID;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"RankID", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int RankID
    {
      get { return _RankID; }
      set { _RankID = value; }
    }
    private string _Name;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"Name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string Name
    {
      get { return _Name; }
      set { _Name = value; }
    }
    private string _Icon;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"Icon", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string Icon
    {
      get { return _Icon; }
      set { _Icon = value; }
    }
    private int _TimeLong;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"TimeLong", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int TimeLong
    {
      get { return _TimeLong; }
      set { _TimeLong = value; }
    }
    private int _Level;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"Level", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int Level
    {
      get { return _Level; }
      set { _Level = value; }
    }
    private string _SelectPool;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"SelectPool", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string SelectPool
    {
      get { return _SelectPool; }
      set { _SelectPool = value; }
    }
    private int _ResultColumn;
    [global::ProtoBuf.ProtoMember(7, IsRequired = true, Name=@"ResultColumn", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int ResultColumn
    {
      get { return _ResultColumn; }
      set { _ResultColumn = value; }
    }
    private int _Column;
    [global::ProtoBuf.ProtoMember(8, IsRequired = true, Name=@"Column", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int Column
    {
      get { return _Column; }
      set { _Column = value; }
    }
    private int _DiamondsCost;
    [global::ProtoBuf.ProtoMember(9, IsRequired = true, Name=@"DiamondsCost", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int DiamondsCost
    {
      get { return _DiamondsCost; }
      set { _DiamondsCost = value; }
    }
    private int _DiamondsWin;
    [global::ProtoBuf.ProtoMember(10, IsRequired = true, Name=@"DiamondsWin", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int DiamondsWin
    {
      get { return _DiamondsWin; }
      set { _DiamondsWin = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}