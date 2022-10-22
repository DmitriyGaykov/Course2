using lab7;
namespace lab4;
class Gladiolus : AFlower, IPlant, IComparable
{
    #region Properties
    public override DateTime WillBeRipen
    {
        get => WasPlanted.AddSeconds(5);
        set => WasPlanted = value;
    }

    #endregion

    #region Constrs

    public Gladiolus(string Name) : base(Name) =>
        this.Name = Name;

    #endregion

    #region Methods

    public override void Plant()
    {
        WasPlanted = DateTime.Now;
        Console.WriteLine("Gladioluscs was planted");
    }
    public bool IsGrow()
    {
        if (DateTime.Now >= WillBeRipen)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int CompareTo(object? obj)
    {
        if (obj is Gladiolus glad)
        {
            return Name.CompareTo(glad.Name);
        }
        else
        {
            throw new Exception("Невозможно сравнить два объекта");
        }
    }

    public void GetFruits()
    {
        if (IsGrow())
        {
            Console.WriteLine("Gladioluscs is picken");
        }
        else
        {
            Console.WriteLine("Gladioluscs is not picken, because it is not grow");
        }
    }

    #endregion

    #region Override Methods

    public override string ToString() => $"{Type}: {Name}";

    #endregion
}

