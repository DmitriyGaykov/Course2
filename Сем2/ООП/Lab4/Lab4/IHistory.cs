using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal interface IHistory
    {
        History.History Storage { get; set; }
    }
}
