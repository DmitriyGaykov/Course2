using System.Text.Json;
namespace lab7;
class Set<T> : IProduct<T>
{
    #region Fields

    private T[] _Set;
    private int CountEls = 20;
    private int _NowCount = 0;
    private const string FILEPATH = "set.json";

    #endregion

    #region Properties
    public int NowCount
    {
        get => _NowCount;
        set => _NowCount = value;
    }
    public T[] AllElements
    {
        get
        {
            T[] Elements = new T[NowCount];
            Array.Copy(_Set, Elements, NowCount);
            return Elements;
        }
        set => _Set = value;
    }

    public static ProductionStruct Production { get; set; } = new(31, "DimAnder");
    public static DeveloperStruct Developer { get; set; } = new("Dima", 142, Divisions.BACKEND);
    #endregion

    #region Operators

    public static Set<T> operator +(Set<T> El1, T El2)
    {
        El1.Add(El2);
        return El1;
    }

    public static Set<T> operator -(Set<T> El1, T El2)
    {
        int Index = Array.IndexOf(El1._Set, El2);
        if (Index != -1)
        {
            El1.NowCount--;
            El1._Set = El1._Set.Where(val => !val.Equals(El2)).ToArray();
        }
        return El1;
    }

    public static Set<T> operator *(Set<T> El1, Set<T> El2)
    {
        Set<T> NewSet = new();
        for (var i = 0; i < El1.NowCount; i++)
        {
            for (var j = 0; j < El2.NowCount; j++)
            {
                if (El1._Set[i].Equals(El2._Set[j]))
                {
                    NewSet.Add(El1._Set[i]);
                }
            }
        }
        El1 = NewSet;
        return El1;
    }

    public static bool operator >(Set<T> El1, Set<T> El2) =>
        IsSubset(ref El1, ref El2);

    public static bool operator <(Set<T> El1, Set<T> El2) =>
        IsEqual(ref El1, ref El2);

    public static Set<T> operator &(Set<T> El1, Set<T> El2) =>
        CombineSets(El1, El2);

    #endregion

    #region Constructors
    public Set()
    {
        if (typeof(T) == typeof(char))
        {
            throw new Exception("Set can't contain another char");
        }
        _Set = new T[CountEls];
    }

    #endregion

    #region Methods

    #region Method | Public

    public void Adds(params T[] Els)
    {
        foreach (var El in Els)
        {
            Add(El);
        }
    }
    public void Add(T El)
    {
        if (NowCount + 1 != CountEls)
        {
            if (Array.IndexOf(_Set, El) != -1)
            {
                return;
            }
            _Set[NowCount++] = El;
            this.Sorting();
        }
        else
        {
            CountEls *= 2;
            Array.Resize<T>(ref _Set, CountEls);
            this.Add(El);
        }
    }

    public void Sorting()
    {
        T[] NewArr = new T[NowCount];
        Array.Copy(_Set, NewArr, NowCount);
        Array.Sort(NewArr);
        Array.Copy(NewArr, _Set, NowCount);
    }
    public void Print()
    {
        for (var i = 0; i < NowCount; i++)
        {
            Console.WriteLine(_Set[i].ToString());
        }
    }

    public void Remove(T El)
    {
        int Index = Array.IndexOf(_Set, El);
        if (Index != -1)
        {
            NowCount--;
            _Set = _Set.Where(val => !val.Equals(El)).ToArray();
        }
    }

    public void GetInfoAbout(T El)
    {
        int Index = Array.IndexOf(_Set, El);
        if (Index != -1)
        {
            Console.WriteLine($"Element {El} is in set");
        }
        else
        {
            Console.WriteLine($"Element {El} is not in set");
        }
    }

    public void ToFile()
    {
        using StreamWriter sr = new(FILEPATH);
        sr.WriteLine(JsonSerializer.Serialize(this));
    }
    public Set<T> FromFile()
    {
        Set<T> set = new();
        using StreamReader sr = new(FILEPATH);
        set = JsonSerializer.Deserialize<Set<T>>(sr.ReadToEnd()) ?? new();
        return set;
    }

    #endregion

    #region Method | Private

    private static bool IsSubset(ref Set<T> El1, ref Set<T> El2)
    {
        for (var i = 0; i < El1.NowCount; i++)
        {
            if (Array.IndexOf(El2._Set, El1._Set[i]) == -1)
            {
                return false;
            }
        }
        return true;
    }
    private static bool IsEqual(ref Set<T> El1, ref Set<T> El2)
    {
        if (El1 > El2 && El2 > El1)
        {
            return true;
        }
        return false;
    }
    private static Set<T> CombineSets(Set<T> El1, Set<T> El2)
    {
        Set<T> NewSet = new();
        for (var i = 0; i < El2.NowCount; i++)
        {
            NewSet.Add(El2._Set[i]);
        }
        for (var j = 0; j < El1.NowCount; j++)
        {
            NewSet.Add(El1._Set[j]);
        }
        return NewSet;
    }
    #endregion

    #endregion
}


#region Struct Production

struct ProductionStruct
{
    public int ID { get; init; }
    public string? Name { get; init; }

    public ProductionStruct(int ID, string Name) =>
        (this.ID, this.Name) = (ID, Name);
}

#endregion

#region Struct Developer

enum Divisions
{
    GAMEDEV,
    GAMEDIS,
    FRONTEND,
    BACKEND,
    FULLSTACK,
}

struct DeveloperStruct
{
    public string FIO { get; init; }
    public int ID { get; init; }
    public Divisions Division { get; set; }
    public DeveloperStruct(string FIO, int ID, Divisions Division) =>
        (this.FIO, this.ID, this.Division) = (FIO, ID, Division);
}

#endregion
