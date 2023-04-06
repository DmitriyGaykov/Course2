using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11.Model.Database.Tables;
public class Mark
{
    [Key, ForeignKey("Person")]
    public int PersonId { get; set; }
    public byte? StudentMark { get; set; }
    public int? NumberOfPasses { get; set; }

    [Required]
    public virtual Person Person { get; set; }
}