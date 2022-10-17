global using System.Drawing;

namespace Контрольная1;

class Plant : IWater
{
    protected const string name = "Гладиолус";
    protected string group;
    protected KnownColor color;

    public string Name
    {
        get => name;
    }
    public string Group
    {
        get => group;
        set => group = value;
    }
    public KnownColor Color
    {
        get => color;
        set => color = value;
    }

    public Plant(string? group,
                 KnownColor? color)
    {
        Group = group ??
                "Неизвестная группа";

        Color = color ??
                KnownColor.Aqua;
    }

    public override string ToString() => $"Название: {Name},\n" +
                                         $"Группа: {Group},\n" +
                                         $"Цвет: {Color}\n";

    public static bool operator ==(Plant plant1, Plant plant2) => plant1.Group == plant2.Group;

    public static bool operator !=(Plant plant1, Plant plant2) => !(plant1 == plant2);

    public void WaterPlant() => Console.WriteLine("Растение полито!");
}

