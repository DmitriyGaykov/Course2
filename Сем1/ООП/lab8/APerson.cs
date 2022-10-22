namespace lab8;

abstract class APerson
{
    #region Fields

    protected string name;
    protected Roles role;
    protected int salary;
    protected string id;

    protected static Dictionary<Roles, int> Salaries = new()
    {
        {Roles.Headmaster, 1000 },
        {Roles.Teacher, 800 },
        {Roles.Assistent, 500 },
        {Roles.Student, 400 },
        {Roles.Nobody, 0 }
    };

    #endregion

    #region Props

    public virtual string? ID
    {
        get => id;
        init => id = value ??
                     Guid.NewGuid().ToString("N");
    }

    public virtual string? Name
    {
        get => name;
        init => name = value ??
                       "No name";
    }

    public virtual Roles? Role
    {
        get => role;
        set
        {
            role = value ??
                   Roles.Nobody;

            PromoteEvent();
        }
    }

    public virtual int? Salary
    {
        get => salary;
        set => salary = value ??
                        0;
    }

    #endregion

    #region Ctors

    public APerson(string name,
                   Roles role)
    {
        Name = name;
        this.role = role;
        Salary = Salaries[this.role];
        FineDelegate += CheckRole;
        FineDelegate += ToFine;
        ID = Guid.NewGuid().ToString("N");

        PromoteEvent += NotifyWhoWasPromoted;
        PromoteEvent += NotifyAboutPromoting;
        PromoteEvent += NotifyAboutNewSalary;
        PromoteEvent += NotifyAboutNewAbilities;

        FineEvent += NotifyWhoWasFined;
        FineEvent += NotifyAboutFining;
        FineEvent += NotifyAboutFineSalary;
        FineEvent += NotifyFineEnd;
    }

    #endregion

    #region Methods

    public override string ToString() => $"Name: {Name},\n" +
                                         $"Role: {Role},\n" +
                                         $"Salary: {Salary}\n";

    public override bool Equals(object? obj) => obj is APerson person &&
                                                person.ID == this.ID;

    protected void CheckRole(APerson person,
                             int fine)
    {
        if (this.Role is not (Roles.Teacher or Roles.Headmaster) ||
            person is Headmaster)
        {
            throw new Exception("You are not allowed to do this");
        }
    }
    protected void ToFine(APerson person,
                          int fine)
    {
        person.Salary -= person.Salary < fine ?
                         person.Salary :
                         fine;

        person.FineEvent(fine);
    }

    #region Notify | Promote

    protected void NotifyWhoWasPromoted() =>
        Console.WriteLine($"\n\n--------------{Name} was promoted to {Role}--------------");
    protected void NotifyAboutPromoting() =>
        Console.WriteLine("Congratulations! You have been promoted!");

    protected void NotifyAboutNewSalary() =>
        Console.WriteLine($"Your new salary is {Salary}");

    protected void NotifyAboutNewAbilities()
    {
        if (Role is (Roles.Teacher or Roles.Headmaster))
        {
            Console.WriteLine("You can now fine people");
        }
        if (Role is Roles.Headmaster)
        {
            Console.WriteLine("You can now add people to the school");
        }
        Console.WriteLine("--------------------------------------------------------\n\n");
    }

    #endregion

    #region Notify | Fine

    protected void NotifyWhoWasFined(int fine) =>
        Console.WriteLine($"\n\n--------------{Name} was fined--------------");

    protected void NotifyAboutFining(int fine) =>
        Console.WriteLine($"You have been fined for {fine}");

    protected void NotifyAboutFineSalary(int fine) =>
        Console.WriteLine($"Your salary is now {Salary}");

    protected void NotifyFineEnd(int fine) =>
        Console.WriteLine("------------------------------------------------");

    #endregion

    #endregion

    #region Enum roles

    public enum Roles
    {
        Headmaster,
        Teacher,
        Assistent,
        Student,
        Nobody
    }

    #endregion

    #region Delegates | Fine

    public Action<APerson, int> FineDelegate { get; set; }

    public event Action PromoteEvent;

    public event Action<int> FineEvent;

    #endregion
}
