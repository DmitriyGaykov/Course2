namespace Контрольная1;
class Flower : Plant, IWater
{
    public Flower(string? group, KnownColor? color) : base(group, color)
    {
    }

    public new void WaterPlant() => Console.WriteLine("Цветок полит!");
}
