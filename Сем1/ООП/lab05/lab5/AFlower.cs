namespace lab4;
abstract class AFlower : APlant
{
    public abstract override DateTime WillBeRipen { get; }
    public abstract KnownColor Color { get; set; }
    public virtual int Price { get; init; }
    public abstract override void Plant();
    public AFlower(string Name, KnownColor Color, int Price) : base(Name)
    {
        this.Name = Name;
        this.Color = Color;
        this.Price = Price;
    }
}
