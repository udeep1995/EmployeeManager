using System.Data.Entity;

namespace EmployeeManagement.Model
{
    public interface IEmployeeContext
    {
        DbSet<Country> Countries { get; set; }
        DbSet<Person> Persons { get; set; }

        int SaveChanges();
    }
}