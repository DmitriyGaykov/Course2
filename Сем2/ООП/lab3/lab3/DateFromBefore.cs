using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3;

class DateFromBefore : ValidationAttribute
{
    private readonly int minYear;
    private readonly int maxYear;
    public DateFromBefore(string minYear, string maxYear)
    {
        this.minYear = int.Parse(minYear);
        this.maxYear = int.Parse(maxYear);
    }
    public override bool IsValid(object? value) => value is DateTime dt &&
                                                   dt.Year >= minYear && 
                                                   dt.Year <= maxYear; 
}
