using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1;

interface IInfo
{
    Control Controler { get; set; }
    bool IsUsed { get; set; }
}
