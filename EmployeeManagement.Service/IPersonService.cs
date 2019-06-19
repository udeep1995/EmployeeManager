using System.Collections.Generic;
using EmployeeManagement.Model;

namespace EmployeeManagement.Service
{
    public interface IPersonService
    {
        void Create(Person entity);
        void Delete(Person entity);
        IEnumerable<Person> GetAll();
        Person GetById(long Id);
        void Update(Person entity);
    }
}