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
        set => role = value ??
                      Roles.Nobody;
    }

    public virtual int? Salary
    {
        get => salary;
        set => salary = value ?? 0;
    }

    #endregion

    #region Ctors

    public APerson(string name,
                   Roles role)
    {
        Name = name;
        Role = role;
        Salary = Salaries[this.role];
        FineDelegate += CheckRole;
        FineDelegate += ToFine;
        ID = Guid.NewGuid().ToString("N");
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
    protected void ToFine(APerson person, int fine) => person.Salary -= fine;

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

    #endregion
}
