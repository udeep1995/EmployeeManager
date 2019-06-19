using System.Collections.Generic;
using EmployeeManagement.Model;

namespace EmployeeManagement.Service
{
    public interface ICountryService
    {
        void Create(Country entity);
        void Delete(Country entity);
        IEnumerable<Country> GetAll();
        Country GetById(int Id);
        void Update(Country entity);
    }
}