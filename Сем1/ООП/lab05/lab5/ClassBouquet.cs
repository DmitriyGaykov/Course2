namespace lab4;
partial class ClassBouquet
{
    #region Fields

    private AFlower[] _Flowers;

    private uint CurrentCount = 0;

    #endregion

    #region Properties

    public uint MaxCount { get; } = 10;
    public AFlower[] AllFlowerIn
    {
        get
        {
            var Tmp = new AFlower[CurrentCount];
            Array.Copy(Flowers, Tmp, CurrentCount);
            return Tmp;
        }
    }

    public AFlower[] Flowers
    {
        get => _Flowers;
        set => _Flowers = value;
    }

    #endregion

    #region Constructors

    public ClassBouquet() =>
        Flowers = new AFlower[MaxCount];


    #endregion

    #region Override Methods

    public override string ToString()
    {
        string Text = "Букет состоит из: \n";
        short i = 0;
        foreach (var item in Flowers)
        {
            Text += $"{item.ToString()}\n\n";
            ++i;
            if (i == CurrentCount)
            {
                break;
            }
        }
        return Text;
    }

    #endregion
}
