using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Service
{
    public class CountryService 
    {
        EmployeeContext _context;
        
        public CountryService()
        {
            _context = new EmployeeContext();
        }

        public Country GetById(int Id) {
            return _context.Countries.FirstOrDefault(x=>x.Id == Id);
        }

        public void Create(Country entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _context.Countries.Add(entity);
            _context.SaveChanges();
        }


        public void Update(Country entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Country entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _context.Countries.Remove(entity);
            _context.SaveChanges();
        }

        public virtual IEnumerable<Country> GetAll()
        {
            return _context.Countries.AsEnumerable<Country>();
        }
    }
}
