using EmployeeManagement.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.Test
{
    [TestClass]
    public class PersonServiceTests
    {
        // Not working
        // How to mock employeeContext.Persons.Include
        [TestMethod]
        public void GetAll_ShouldReturnPersonsEnumerableWithCountry()
        {
            var John = new Person() { Id = 1, CountryId = 1, Name = "John" };
            var JohnDoe = new Person() { Id = 2, CountryId = 2, Name = "John Doe" };


            var listPersons = new List<Person>()
            {John, JohnDoe}.AsQueryable();

      
            var employeeContext = Substitute.For<IEmployeeContext>();

            employeeContext.Persons = Substitute.For<DbSet<Person>, IQueryable<Person>>();
            ((IQueryable<Person>)employeeContext.Persons).Provider.Returns(listPersons.Provider);
            ((IQueryable<Person>)employeeContext.Persons).Expression.Returns(listPersons.Expression);
            ((IQueryable<Person>)employeeContext.Persons).ElementType.Returns(listPersons.ElementType);
            ((IQueryable<Person>)employeeContext.Persons).GetEnumerator().Returns(listPersons.GetEnumerator());


            employeeContext.Persons.Include(Arg.Any<string>()).Returns(listPersons);

            var personService = new PersonService(employeeContext);
            // Act
            var results = personService.GetAll();

            // Assert
            Assert.AreEqual(2, results.Count());
        }

        [TestMethod]
        public void GetById_ValidArgumentAs_1_ShouldReturnPerson()
        {
            var John = new Person() { Id = 1, CountryId = 1, Name = "John" };
     
            var listPersons = new List<Person>()
            {John}.AsQueryable();


            var employeeContext = Substitute.For<IEmployeeContext>();

            employeeContext.Persons = Substitute.For<DbSet<Person>, IQueryable<Person>>();
            ((IQueryable<Person>)employeeContext.Persons).Provider.Returns(listPersons.Provider);
            ((IQueryable<Person>)employeeContext.Persons).Expression.Returns(listPersons.Expression);
            ((IQueryable<Person>)employeeContext.Persons).ElementType.Returns(listPersons.ElementType);
            ((IQueryable<Person>)employeeContext.Persons).GetEnumerator().Returns(listPersons.GetEnumerator());

            var personService = new PersonService(employeeContext);
            // Act
            var results = personService.GetById(1);

            // Assert
            Assert.AreEqual("John", results.Name);
        }

        [TestMethod]
        public void GetById_InValidArgument_ShouldReturnNull()
        {
            var John = new Person() { Id = 1, CountryId = 1, Name = "John" };

            var listPersons = new List<Person>()
            {John}.AsQueryable();


            var employeeContext = Substitute.For<IEmployeeContext>();

            employeeContext.Persons = Substitute.For<DbSet<Person>, IQueryable<Person>>();
            ((IQueryable<Person>)employeeContext.Persons).Provider.Returns(listPersons.Provider);
            ((IQueryable<Person>)employeeContext.Persons).Expression.Returns(listPersons.Expression);
            ((IQueryable<Person>)employeeContext.Persons).ElementType.Returns(listPersons.ElementType);
            ((IQueryable<Person>)employeeContext.Persons).GetEnumerator().Returns(listPersons.GetEnumerator());

            var personService = new PersonService(employeeContext);
            // Act
            var results = personService.GetById(2);

            // Assert
            Assert.IsNull(results);
        }


        [TestMethod]
        public void Create_ValidArgumentAs_Person_ShouldSaveChangesToContext()
        {
            var John = new Person() { Id = 1, CountryId = 1, Name = "John" };

            var listPersons = new List<Person>()
            {John}.AsQueryable();


            var employeeContext = Substitute.For<IEmployeeContext>();

            employeeContext.Persons = Substitute.For<DbSet<Person>, IQueryable<Person>>();
            ((IQueryable<Person>)employeeContext.Persons).Provider.Returns(listPersons.Provider);
            ((IQueryable<Person>)employeeContext.Persons).Expression.Returns(listPersons.Expression);
            ((IQueryable<Person>)employeeContext.Persons).ElementType.Returns(listPersons.ElementType);
            ((IQueryable<Person>)employeeContext.Persons).GetEnumerator().Returns(listPersons.GetEnumerator());

            var personService = new PersonService(employeeContext);
            // Act
            personService.Create(John);

            // Assert
            Received.InOrder(() =>
            {
                employeeContext.Persons.Add(John);
                employeeContext.SaveChanges();
            });
        }
        [ExpectedException(typeof(ArgumentNullException), "entity")]
        [TestMethod]
        public void Create_InValidArgumentAs_Null_ShouldReturnArgumentException()
        {
            var John = new Person() { Id = 1, CountryId = 1, Name = "John" };

            var listPersons = new List<Person>()
            {John}.AsQueryable();


            var employeeContext = Substitute.For<IEmployeeContext>();

            employeeContext.Persons = Substitute.For<DbSet<Person>, IQueryable<Person>>();
            ((IQueryable<Person>)employeeContext.Persons).Provider.Returns(listPersons.Provider);
            ((IQueryable<Person>)employeeContext.Persons).Expression.Returns(listPersons.Expression);
            ((IQueryable<Person>)employeeContext.Persons).ElementType.Returns(listPersons.ElementType);
            ((IQueryable<Person>)employeeContext.Persons).GetEnumerator().Returns(listPersons.GetEnumerator());

            var personService = new PersonService(employeeContext);
            // Act
            personService.Create(null);

            // Assert
           
        }


        [TestMethod]
        public void Update_ValidArgumentAs_Person_ShouldSaveChangesToContext()
        {
            var John = new Person() { Id = 1, CountryId = 1, Name = "John" };

            var listPersons = new List<Person>()
            {John}.AsQueryable();


            var employeeContext = Substitute.For<IEmployeeContext>();

            employeeContext.Persons = Substitute.For<DbSet<Person>, IQueryable<Person>>();
            ((IQueryable<Person>)employeeContext.Persons).Provider.Returns(listPersons.Provider);
            ((IQueryable<Person>)employeeContext.Persons).Expression.Returns(listPersons.Expression);
            ((IQueryable<Person>)employeeContext.Persons).ElementType.Returns(listPersons.ElementType);
            ((IQueryable<Person>)employeeContext.Persons).GetEnumerator().Returns(listPersons.GetEnumerator());

            var personService = new PersonService(employeeContext);
            var newJohn = new Person() { Id = 1, Name = "John Doe" };
            // Act
            personService.Update(newJohn);

            // Assert
            Received.InOrder(() =>
            {
                employeeContext.Persons.SingleOrDefault(x => x.Id == John.Id).Name = newJohn.Name;
                employeeContext.SaveChanges();
            });
        }
        [ExpectedException(typeof(ArgumentNullException), "entity")]
        [TestMethod]
        public void Update_InValidArgumentAs_Null_ShouldReturnArgumentException()
        {
            var John = new Person() { Id = 1, CountryId = 1, Name = "John" };

            var listPersons = new List<Person>()
            {John}.AsQueryable();


            var employeeContext = Substitute.For<IEmployeeContext>();

            employeeContext.Persons = Substitute.For<DbSet<Person>, IQueryable<Person>>();
            ((IQueryable<Person>)employeeContext.Persons).Provider.Returns(listPersons.Provider);
            ((IQueryable<Person>)employeeContext.Persons).Expression.Returns(listPersons.Expression);
            ((IQueryable<Person>)employeeContext.Persons).ElementType.Returns(listPersons.ElementType);
            ((IQueryable<Person>)employeeContext.Persons).GetEnumerator().Returns(listPersons.GetEnumerator());

            var personService = new PersonService(employeeContext);
            // Act
            personService.Create(null);

            // Assert

        }

        [TestMethod]
        public void Delete_ValidArgumentAs_Person_ShouldSaveChangesToContext()
        {
            // Arrange
            var John = new Person() { Id = 1, CountryId = 1, Name = "John" };

            var listPersons = new List<Person>()
            {John}.AsQueryable();


            var employeeContext = Substitute.For<IEmployeeContext>();

            employeeContext.Persons = Substitute.For<DbSet<Person>, IQueryable<Person>>();
            ((IQueryable<Person>)employeeContext.Persons).Provider.Returns(listPersons.Provider);
            ((IQueryable<Person>)employeeContext.Persons).Expression.Returns(listPersons.Expression);
            ((IQueryable<Person>)employeeContext.Persons).ElementType.Returns(listPersons.ElementType);
            ((IQueryable<Person>)employeeContext.Persons).GetEnumerator().Returns(listPersons.GetEnumerator());

            var personService = new PersonService(employeeContext);

            // Act
            personService.Delete(John);

            // Assert
            Received.InOrder(() =>
            {
                employeeContext.Persons.Remove(John);
                employeeContext.SaveChanges();
            });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "entity")]
        public void Delete_InValidArgumentAs_Null_ShouldReturnArgumentNullException()
        {
            // Arrange
            var John = new Person() { Id = 1, CountryId = 1, Name = "John" };

            var listPersons = new List<Person>()
            {John}.AsQueryable();


            var employeeContext = Substitute.For<IEmployeeContext>();

            employeeContext.Persons = Substitute.For<DbSet<Person>, IQueryable<Person>>();
            ((IQueryable<Person>)employeeContext.Persons).Provider.Returns(listPersons.Provider);
            ((IQueryable<Person>)employeeContext.Persons).Expression.Returns(listPersons.Expression);
            ((IQueryable<Person>)employeeContext.Persons).ElementType.Returns(listPersons.ElementType);
            ((IQueryable<Person>)employeeContext.Persons).GetEnumerator().Returns(listPersons.GetEnumerator());

            var personService = new PersonService(employeeContext);

            // Act
            personService.Delete(null);

            // Assert
        }


    }
}
