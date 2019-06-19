using EmployeeManagement.Model;
using EmployeeManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class FakeCountryService : ICountryService
    {
        public void Create(Country entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            //throw new NotImplementedException();
        }
        public void Delete(Country entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            // throw new NotImplementedException();
        }

        public IEnumerable<Country> GetAll()
        {
            Country country = new Country();
            country.Id = 1;
            country.Name = "India";
            IList<Country> listOfCountries = new List<Country>();
            return listOfCountries;
            
        }

        public Country GetById(int Id)
        {
            if(Id ==1)
            {
                Country country = new Country();
                country.Id = 1;
                country.Name = "India";
                return country;
            }
            return null;
        }

        public void Update(Country entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            //throw new NotImplementedException();
        }
    }
}
