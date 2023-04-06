using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11.Model.Database.Tables;

public class Group
{
    public int Id { get; set; }
    public int GroupNumber { get; set; }
    [ForeignKey("Spec")]
    public int SpecId { get; set; }

    [NotMapped]
    public string SpecName => Spec.Name;
    public virtual Specification Spec { get; set; }

    [InverseProperty("Group")]
    public virtual ICollection<Person> People { get; set; }
}