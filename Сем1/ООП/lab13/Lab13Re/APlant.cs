using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace lab4;
[Serializable]
public abstract class APlant
{
    #region Fields
    
    protected TypePlant _type;
    [NonSerialized]
    protected string _name = "deflaut";
    protected DateTime _wasPlanted;

    #endregion

    #region Properties

    public virtual TypePlant Type 
    { 
        get => _type;
        set => _type = value;
    }

    [JsonIgnore]
    [XmlIgnore]
    public virtual string Name 
    {
        get => _name; 
        set => _name = value;
    }
    public virtual DateTime WasPlanted 
    {
        get => _wasPlanted;
        set => _wasPlanted = value;
    }
    public abstract DateTime WillBeRipen { get;  }

    #endregion

    public APlant(string Name) =>
        this.Name = Name;

    public APlant(TypePlant type,
                  string name,
                  DateTime wasPlanted)
    {
        Type = type;
        Name = name;
        WasPlanted = wasPlanted;
    }

    public APlant() { }

    public abstract void Plant();
}

public enum TypePlant
{
    BUSH,
    TREE,
    FLOWER,
    CACTUS
}