using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11.Model.Database.Tables;

public class Specification
{
    public int Id { get; set; }
    public string Name { get; set; }

    [InverseProperty("Spec")]
    public virtual ICollection<Group> Groups { get; set; }
}
