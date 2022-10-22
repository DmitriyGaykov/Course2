namespace Контрольная1;
class Bag : IComparable
{
    private int sum;
    private string name;

    public int? Sum
    {
        get => sum;
        set => sum = value ??
                     0;
    }

    public string? Name
    {
        get => name;
        set => name = value ??
                      "default";
    }

    public Bag(int? sum,
               string? name)
    {
        Sum = sum;
        Name = name;
    }

    public int CompareTo(object? obj) => Name!.CompareTo((obj as Bag)?.Name);
}
