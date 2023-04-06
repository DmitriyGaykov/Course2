using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11.Model.Database.Tables;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    [ForeignKey("Group")]
    public int GroupId { get; set; }

    [NotMapped]
    public int GroupNumber => Group?.GroupNumber ?? 0;
    [NotMapped]
    public string SpecName => Group?.SpecName ?? "None";

    public virtual Group Group { get; set; }
}