namespace lab8;
sealed class Headmaster : APerson
{
    #region Fields

    private APerson[] _staff = new APerson[20];

    private int _staffCount = 0;

    #endregion

    #region Props

    public APerson[] Staff
    {
        get
        {
            APerson[] result = new APerson[_staffCount];
            Array.Copy(_staff, result, _staffCount);
            return result;
        }
    }

    #endregion

    #region Ctors

    public Headmaster(string name) : base(name, Roles.Headmaster)
    {
        PromoteDelegate += ChangeSalary;
        PromoteDelegate += ToPromote;
    }

    #endregion

    #region Delegates | Promote

    public Action<APerson, Roles> PromoteDelegate { get; set; }

    #endregion

    #region Methods

    public void TestHeadmaster(string str) => Console.WriteLine(str);

    public void AddMemberOrStudent(APerson person)
    {
        if (_staffCount < _staff.Length)
        {
            _staff[_staffCount] = person;
        }
        else
        {
            Array.Resize(ref _staff, _staff.Length * 2);
            _staff[_staffCount] = person;
        }
        _staffCount++;
    }

    private void ToPromote(APerson person, Roles role)
    {
        if (!this.Staff.Contains(person))
        {
            throw new Exception("This person is not in your staff");
        }

        person.Role = role;
    }

    private void ChangeSalary(APerson person, Roles role) =>
        person.Salary = Salaries[role];

    #endregion
}