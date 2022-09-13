namespace lab3;

static class StaticOperations
{
    public static int Sum(Set<int> Set) =>
        Set.AllElements.Sum();

    public static int DiffBetweenMaxAndMin(Set<int> Set) =>
        Set.AllElements[Set.AllElements.Length - 1] - Set.AllElements[0];

    public static int LengthOfSet<T>(Set<T> _Set) =>
        _Set.AllElements.Length;

    public static string AddDotToEnd(this string Str) =>
        Str + ".";

    public static void DellFirst<T>(this Set<T> _Set)
    {
        var Elements = _Set.AllElements;
        _Set -= Elements[0];
    }
}
