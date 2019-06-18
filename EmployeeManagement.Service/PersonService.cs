using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EmployeeManagement.Service
{
    public class PersonService 
    {
        EmployeeContext _context;
        public PersonService()
        {
            _context = new EmployeeContext();
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.Persons.Include(x => x.Country).ToList(); 
        }

        public Person GetById(long Id) {
            return _context.Persons.FirstOrDefault(x => x.Id == Id);
        }


        public void Create(Person entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _context.Persons.Add(entity);
            _context.SaveChanges();
        }


        public void Update(Person entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Person entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _context.Persons.Remove(entity);
            _context.SaveChanges();
        }
    }
}
