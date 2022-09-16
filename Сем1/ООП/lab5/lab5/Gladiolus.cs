using System.Drawing;

namespace lab4;
class Gladiolus : AFlower, IPlant
{
    #region Properties
    public override System.Drawing.KnownColor Color { get; set; }
    public override DateTime WillBeRipen
    {
        get => WasPlanted.AddSeconds(2);
    }

    #endregion

    #region Constrs

    public Gladiolus(string Name, KnownColor Color, int Price) : base(Name, Color, Price)
    {
        this.Name = Name;
        this.Color = Color;
        this.Price = Price;
        this.Type = TypePlant.FLOWER;
    }

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

    public override string ToString() => $"{Type}: {Name}\n" +
                                         $"Цена: {Price}\n" +
                                         $"{Color}";

    #endregion
}

