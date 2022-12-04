using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17;
sealed class Reader : APerson
{
    public void DoOrder(Librarian pers, string name) => pers.GetOrder(this, name);
}
