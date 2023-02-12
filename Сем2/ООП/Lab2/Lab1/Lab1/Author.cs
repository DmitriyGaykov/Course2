using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1;

class Author
{
    public string Name { get; set; }
    public string Country { get; set; }
    public Sex Sex { get; set; }
    public Direction Direction { get; set; }

    public Author() { }
    public Author(
        string name,
        string country,
        Sex sex,
        Direction direction)
    {
        Name = name;
        Country = country;
        Sex = sex;
        Direction = direction;
    }

    public override string ToString() =>
        $"""
        Name: {Name}
        Country {Country}
        Sex: {Sex}
        Direction: {Direction}
        """;
}

enum Sex
{
    Male,
    Woman
}

enum Direction
{
    Drama,
    Public,
    Romantic,
    Critic,
    Poet
}