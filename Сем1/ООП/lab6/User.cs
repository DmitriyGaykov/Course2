using System.Text.RegularExpressions;

namespace lab6;
class User
{
    #region Fields

    private const int MAX_NAME_SIZE = 30;
    private string name;
    private int age;

    #endregion

    #region Props

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int Age
    {
        get => age;
        set => age = value;
    }

    #endregion

    #region Constructors

    public User() { }

    #endregion

    #region Methods

    #region Creating User

    public void CreateUser()
    {
        this.Name = GetName();
        this.Age = GetAge();
    }

    private static string GetName()
    {
        string name;
        Regex reg = new("([A-Z]([a-z])+)|([А-Я]([а-я])+)");

        Console.WriteLine($"Введите имя(максимальное количество символов {MAX_NAME_SIZE}):");

        name = Console.ReadLine();

        if (name == null)
        {
            throw new PtrException(PtrException.ECode.ErrorNullptr);
        }

        if (!reg.IsMatch(name) || name.Length > MAX_NAME_SIZE)
        {
            throw new UserException(UserException.ECode.ErrorInCreateUserName);
        }

        return name;
    }

    private static int GetAge()
    {
        int age;
        string sAge;

        Console.WriteLine("Введите ваш возраст(18-100)");
        sAge = Console.ReadLine() ?? "Error 1";

        if (!int.TryParse(sAge, out age) || age < 18 || age > 100)
        {
            throw new UserException(UserException.ECode.ErrorInCreateUserAge);
        }

        return age;
    }

    #endregion

    #region Abilities

    private delegate short Operation(short a, short b);

    public void CalculateNumbers(short a, short b)
    {
        Console.WriteLine("Какая операция будет произведена над числами?");
        Console.WriteLine("1. Сложение");
        Console.WriteLine("2. Деление");

        var point = Console.ReadLine();
        Operation operation;

        switch (point)
        {
            case "1":
                operation = (short A, short B) => (short)(A + B);
                break;
            case "2":
                if (b == 0)
                {
                    throw new NullException(NullException.ECode.ErrorDellNull);
                }
                operation = (short A, short B) => (short)(A / B);
                break;
            default:
                throw new UserException(UserException.ECode.ErrorInCalculateMenu);

        }

        Console.WriteLine($"Ответ: {operation(a, b)}");
    }

    #endregion

    #region Override Methods

    public override string ToString() => $"Имя: {this.Name},\n" +
                                         $" Возраст: {this.Age}";

    #endregion

    #endregion
}
