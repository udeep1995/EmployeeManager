using EmployeeManagement.Model;
using EmployeeManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Tests
{
    public class FakePersonService : IPersonService
    {
        public void Create(Person entity)
        {
            return;
        }

        public void Delete(Person entity)
        {
            return;
        }

        public IEnumerable<Person> GetAll()
        {
            return new List<Person>();
        }

        public Person GetById(long Id)
        {
            if(Id==1)
            {
                return new Person() { Id = 1, Name = "John Doe" };
            }
            return null;
        }

        public void Update(Person entity)
        {
            return;
        }
    }
}
