using Lab11.Model.Database.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11.Model.Database;

public class DB : DbContext
{
    private const string stringConnection = "Data Source=DIMA;Initial Catalog=JOURNAL;Integrated Security=True;TrustServerCertificate=true";

    public DB() : base(stringConnection)
    {
        
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Mark> Marks { get; set; }
    public DbSet<Specification> Specifications { get; set; }
    public DbSet<Group> Groups { get; set; }
}
