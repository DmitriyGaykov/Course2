namespace Lab2;
/*
    Не менее трех конструкторов(с параметрами и без, а также с
    параметрами по умолчанию);
     статический конструктор(конструктор типа);
     определите закрытый конструктор; предложите варианты его вызова;
     поле - только для чтения(например, для каждого экземпляра сделайте
    поле только для чтения ID - равно некоторому уникальному номеру
    (хэшу) вычисляемому автоматически на основе инициализаторов
    объекта);
     поле - константу;
     свойства(get, set) – для всех поле класса(поля класса должны быть
    закрытыми); Для одного из свойств ограните доступ по set
     в одном из методов класса для работы с аргументами используйте ref -
    и out-параметры.
     создайте в классе статическое поле, хранящее количество созданных
    объектов(инкрементируется в конструкторе) и статический
    метод вывода информации о классе.
     сделайте касс partial
     переопределяете методы класса Object: Equals, для сравнения объектов,
    GetHashCode; для алгоритма вычисления хэша руководствуйтесь
    стандартными рекомендациями, ToString – вывода строки –
    информации об объекте.
*/
partial class Customer
{
    #region Field
    private readonly string _ID;
    private string _Surname;
    private string _Name;
    private string _MiddleName;
    private uint _Balance;
    private int _CartNumber;
    public static int _Count;
    #endregion

    #region Properties
    public string ID
    {
        get => _ID;
    }
    public string? Surname
    {
        get => _Surname;
        set => _Surname = value ??
                         "Нет данных";
    }
    public string? Name
    {
        get => _Name;
        set => _Name = value ??
                       "Нет данных";
    }
    public string? MiddleName
    {
        get => _MiddleName;
        set => _MiddleName = value ??
                             "Нет данных";
    }
    public uint Balance
    {
        get => _Balance;
        set => _Balance = value;
    }
    public int? CardNumber
    {
        get => _CartNumber;
        set => _CartNumber = value ??
                             000000;
    }
    public static int Count
    {
        get => _Count;
        set => _Count = value;
    }
    #endregion

    #region Methods
    public void TopUpBalance(out uint Amount)
    {
        Console.WriteLine("Пополнение баланса:");
        Amount = EnterAmount();
        Balance += Amount;
    }
    public void WithdrawBalance(ref uint Amount)
    {
        Console.WriteLine("Снятие с баланса:");
        Amount = EnterAmount();
        if (Amount > Balance)
        {
            Console.WriteLine("Недостаточно средств на счете");
        }
        else
        {
            Balance -= Amount;
        }
    }
    private static uint EnterAmount()
    {
        string? MaskNum;
        uint Amount;

        do
        {
            Console.WriteLine("Введите сумму:");
            MaskNum = Console.ReadLine();
        } while (!uint.TryParse(MaskNum, out Amount));
        Amount = uint.Parse(MaskNum);

        return Amount;
    }
    public static void PrintInfo()
    {
        Console.WriteLine("Класс Customer");
        Console.WriteLine("Количество экземпляров: {0}", Count);
    }
    #endregion

    #region Constrs
    static Customer() =>
        Count = 0;

    public Customer() =>
        _ID = Guid.NewGuid().ToString("N");

    public Customer(string Surname, string Name, string MiddleName, uint Balance = 0)
    {
        this.Surname = Surname;
        this.Name = Name;
        this.MiddleName = MiddleName;
        this.Balance = Balance;
        this._ID = Guid.NewGuid().ToString("N");
        CardNumber = Count++;
    }
    public Customer(int CardNumber, string? Surname, string? Name, string? MiddleName, uint Balance = 0)
    {
        this.Surname = Surname;
        this.Name = Name;
        this.MiddleName = MiddleName;
        this.Balance = Balance;
        this._ID = Guid.NewGuid().ToString("N");
        this.CardNumber = CardNumber;
    }
    // определите закрытый конструктор; предложите варианты его вызова;
    private Customer(string Surname, string Name, string MiddleName, int CardNumber, uint Balance = 0)
    {
        this.Surname = Surname;
        this.Name = Name;
        this.MiddleName = MiddleName;
        this.Balance = Balance;
        this._ID = Guid.NewGuid().ToString("N");
        this.CardNumber = CardNumber;
    }

    #endregion
}
#region RedefiningClass
partial class Customer
{
    public override bool Equals(object? obj) =>
        obj is Customer customer &&
               this.ID == customer.ID;

    public override int GetHashCode() => HashCode.Combine(this.ID);
    public override string ToString() => $"ID: {this.ID};\n" +
                                         $"ФИО: {this.Surname} {this.Name} {this.MiddleName};\n" +
                                         $"Баланс: {this.Balance}\n" +
                                         $"Номер счета: {this.CardNumber}\n";
}
#endregion