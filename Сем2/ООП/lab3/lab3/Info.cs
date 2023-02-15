using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1;
sealed class Info : IInfo
{
    private Control controler;
    private bool isUsed;

    public Control Controler 
    {
        get => controler;
        set => controler = value; 
    }
    public bool IsUsed 
    {
        get => isUsed;
        set => isUsed = value;
    }

    public Info(Control controler, bool isUsed = false)
    {
        this.controler = controler;
        this.isUsed = isUsed;
    }
}
