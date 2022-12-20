using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex3;

class Circ
{
    public void NewYear(params Artist[] arts)
    {
        foreach(var atr in arts)
        {
            atr.IsInvited = true;
        }
    }
}

class Artist
{
    private bool isInvited;
    public string Name { get; set; } = "name";
    public event Action Invite;
    public Artist(string name) => Name = name;

    public bool IsInvited
    {
        get => isInvited;
        set
        {
            isInvited = value;
            Invite = () => { Console.WriteLine($"{Name} is invited"); };
            
            if (isInvited)
            {
                Invite?.Invoke();
            }
        }
    }
    public override string ToString() => Name;
}
