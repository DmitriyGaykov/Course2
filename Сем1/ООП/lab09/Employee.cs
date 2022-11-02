namespace Lab9;
class Employee
{
    #region Props

    public string Name { get; set; }
    public string Organization { get; set; }
    public int Age { get; set; }

    #endregion

    #region Ctors

    public Employee(string Name,
                    string Organization,
                    int Age)
    {
        this.Name = Name;
        this.Organization = Organization;
        this.Age = Age;
    }

    #endregion

    #region Methods

    public override bool Equals(object? obj) => obj is Employee emp &&
                                                emp.Name == this.Name &&
                                                emp.Age == this.Age ? true :
                                                                      false;

    public override string ToString() => $"Name: {Name}\n" +
                                         $"Age: {Age}\n" +
                                         $"Organization: {Organization}";

    public override int GetHashCode() =>
        Name.GetHashCode() + Age.GetHashCode() + Organization.GetHashCode();

    #endregion

}
