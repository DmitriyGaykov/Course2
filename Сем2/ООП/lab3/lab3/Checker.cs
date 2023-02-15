using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1;
static class Checker
{
    static public bool CheckOnNumber(string snum, int start = int.MinValue, int end = int.MaxValue)
    {
        int num;

        if(
            int.TryParse(snum, out num) && 
            num > start &&
            num < end)
        {
            return true;
        }

        return false;
    }
}
