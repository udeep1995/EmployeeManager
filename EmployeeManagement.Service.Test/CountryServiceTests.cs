using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EmployeeManagement.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Unity;

namespace EmployeeManagement.Service.Test
{
    [TestClass]
    public class CountryServiceTests
    {
        public static UnityContainer UnityContainer;
        [TestMethod]
        public void GetAll_ShouldReturnCountriesAsEnumerable()
        {
            // Arrange
            var listCountry = new List<Country>()
            {
                new Country(){Id=1, Name="India"},
                new Country(){Id=2, Name="US"},
            }.AsQueryable();
            var employeeContext = Substitute.For<IEmployeeContext>();
             employeeContext.Countries = Substitute.For<DbSet<Country>, IQueryable<Country>>();
            ((IQueryable<Country>)employeeContext.Countries).Provider.Returns(listCountry.Provider);
            ((IQueryable<Country>)employeeContext.Countries).Expression.Returns(listCountry.Expression);
            ((IQueryable<Country>)employeeContext.Countries).ElementType.Returns(listCountry.ElementType);
            ((IQueryable<Country>)employeeContext.Countries).GetEnumerator().Returns(listCountry.GetEnumerator());

            var countryService = new CountryService(employeeContext);

            // Act
            var result = countryService.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count());

        }

        [TestMethod]
        public void GetById_ValidArgumentAs_Id_ShouldReturnCountry()
        {
            // Arrange
            var listCountry = new List<Country>()
            {
                new Country(){Id=1, Name="US"},
                new Country(){Id=2, Name="India"},
            }.AsQueryable();
            var employeeContext = Substitute.For<IEmployeeContext>();
            employeeContext.Countries = Substitute.For<DbSet<Country>, IQueryable<Country>>();
            ((IQueryable<Country>)employeeContext.Countries).Provider.Returns(listCountry.Provider);
            ((IQueryable<Country>)employeeContext.Countries).Expression.Returns(listCountry.Expression);
            ((IQueryable<Country>)employeeContext.Countries).ElementType.Returns(listCountry.ElementType);
            ((IQueryable<Country>)employeeContext.Countries).GetEnumerator().Returns(listCountry.GetEnumerator());

            var countryService = new CountryService(employeeContext);

            // Act
            var results = countryService.GetById(1);

            // Assert
            Assert.AreEqual("US", results.Name);
        }
        [TestMethod]
        public void GetById_ValidArgumentAs_IdNotInDb_ShouldReturnNull()
        {
            // Arrange
            var listCountry = new List<Country>()
            {
                new Country(){Id=1, Name="US"},
                new Country(){Id=2, Name="India"},
            }.AsQueryable();
            var employeeContext = Substitute.For<IEmployeeContext>();
            employeeContext.Countries = Substitute.For<DbSet<Country>, IQueryable<Country>>();
            ((IQueryable<Country>)employeeContext.Countries).Provider.Returns(listCountry.Provider);
            ((IQueryable<Country>)employeeContext.Countries).Expression.Returns(listCountry.Expression);
            ((IQueryable<Country>)employeeContext.Countries).ElementType.Returns(listCountry.ElementType);
            ((IQueryable<Country>)employeeContext.Countries).GetEnumerator().Returns(listCountry.GetEnumerator());

            var countryService = new CountryService(employeeContext);

            // Act
            var results = countryService.GetById(3);

            // Assert
            Assert.IsNull(results);
        }

        [TestMethod]
        public void Create_ValidArgumentAs_Country_ShouldSaveChangesToContext()
        {
            // Arrange
            var country = new Country() { Id = 1, Name = "India" };
            var listCountry = new List<Country>(){}.AsQueryable();
            var employeeContext = Substitute.For<IEmployeeContext>();
            employeeContext.Countries = Substitute.For<DbSet<Country>, IQueryable<Country>>();
            ((IQueryable<Country>)employeeContext.Countries).Provider.Returns(listCountry.Provider);
            ((IQueryable<Country>)employeeContext.Countries).Expression.Returns(listCountry.Expression);
            ((IQueryable<Country>)employeeContext.Countries).ElementType.Returns(listCountry.ElementType);
            ((IQueryable<Country>)employeeContext.Countries).GetEnumerator().Returns(listCountry.GetEnumerator());
            var countryService = new CountryService(employeeContext);
            // Act
            countryService.Create(country);

            // Assert
            Received.InOrder(() =>
            {
                employeeContext.Countries.Add(country);
                employeeContext.SaveChanges();
            });
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "entity")]
        public void Create_InValidArgumentAs_Null_ShouldReturnArgumentNullException()
        {
            // Arrange
            var listCountry = new List<Country>() { }.AsQueryable();
            var employeeContext = Substitute.For<IEmployeeContext>();
            employeeContext.Countries = Substitute.For<DbSet<Country>, IQueryable<Country>>();
            ((IQueryable<Country>)employeeContext.Countries).Provider.Returns(listCountry.Provider);
            ((IQueryable<Country>)employeeContext.Countries).Expression.Returns(listCountry.Expression);
            ((IQueryable<Country>)employeeContext.Countries).ElementType.Returns(listCountry.ElementType);
            ((IQueryable<Country>)employeeContext.Countries).GetEnumerator().Returns(listCountry.GetEnumerator());
            var countryService = new CountryService(employeeContext);
            // Act
            countryService.Create(null);

            // Assert
        }


        [TestMethod]
        public void Update_ValidArgumentAs_Country_ShouldSaveChangesToContext()
        {
            // Arrange
            var country = new Country() { Id =1, Name = "US" };
            var listCountry = new List<Country>() {
            new Country() {Id=1, Name="US"} }.AsQueryable();
            var employeeContext = Substitute.For<IEmployeeContext>();
            employeeContext.Countries = Substitute.For<DbSet<Country>, IQueryable<Country>>();
            ((IQueryable<Country>)employeeContext.Countries).Provider.Returns(listCountry.Provider);
            ((IQueryable<Country>)employeeContext.Countries).Expression.Returns(listCountry.Expression);
            ((IQueryable<Country>)employeeContext.Countries).ElementType.Returns(listCountry.ElementType);
            ((IQueryable<Country>)employeeContext.Countries).GetEnumerator().Returns(listCountry.GetEnumerator());
            var countryService = new CountryService(employeeContext);
            var newCountry = new Country() { Id = 1, Name = "USA" };
            // Act
            countryService.Update(country);

            // Assert
            Received.InOrder(() =>
            {
                employeeContext.Countries.SingleOrDefault(x=>x.Id == newCountry.Id).Name = newCountry.Name;
                employeeContext.SaveChanges();
            });
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "entity")]
        public void Update_InValidArgumentAs_Null_ShouldReturnArgumentNullException()
        {
            // Arrange
            var listCountry = new List<Country>() { }.AsQueryable();
            var employeeContext = Substitute.For<IEmployeeContext>();
            employeeContext.Countries = Substitute.For<DbSet<Country>, IQueryable<Country>>();
            ((IQueryable<Country>)employeeContext.Countries).Provider.Returns(listCountry.Provider);
            ((IQueryable<Country>)employeeContext.Countries).Expression.Returns(listCountry.Expression);
            ((IQueryable<Country>)employeeContext.Countries).ElementType.Returns(listCountry.ElementType);
            ((IQueryable<Country>)employeeContext.Countries).GetEnumerator().Returns(listCountry.GetEnumerator());
            var countryService = new CountryService(employeeContext);
            // Act
            countryService.Update(null);

            // Assert
        }


        [TestMethod]
        public void Delete_ValidArgumentAs_Country_ShouldSaveChangesToContext()
        {
            // Arrange
            var country = new Country() { Id=1, Name = "India" };
            var listCountry = new List<Country>() {
                   new Country() {Id=1, Name="India"}
            }.AsQueryable();
            var employeeContext = Substitute.For<IEmployeeContext>();
            employeeContext.Countries = Substitute.For<DbSet<Country>, IQueryable<Country>>();
            ((IQueryable<Country>)employeeContext.Countries).Provider.Returns(listCountry.Provider);
            ((IQueryable<Country>)employeeContext.Countries).Expression.Returns(listCountry.Expression);
            ((IQueryable<Country>)employeeContext.Countries).ElementType.Returns(listCountry.ElementType);
            ((IQueryable<Country>)employeeContext.Countries).GetEnumerator().Returns(listCountry.GetEnumerator());
            var countryService = new CountryService(employeeContext);
            // Act
            countryService.Delete(country);

            // Assert
            Received.InOrder(() =>
            {
                employeeContext.Countries.Remove(country);
                employeeContext.SaveChanges();
            });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "entity")]
        public void Delete_InValidArgumentAs_Null_ShouldReturnArgumentNullException()
        {
            // Arrange
            var listCountry = new List<Country>() {
                   new Country() {Id=1, Name="India"}
            }.AsQueryable();
            var employeeContext = Substitute.For<IEmployeeContext>();
            employeeContext.Countries = Substitute.For<DbSet<Country>, IQueryable<Country>>();
            ((IQueryable<Country>)employeeContext.Countries).Provider.Returns(listCountry.Provider);
            ((IQueryable<Country>)employeeContext.Countries).Expression.Returns(listCountry.Expression);
            ((IQueryable<Country>)employeeContext.Countries).ElementType.Returns(listCountry.ElementType);
            ((IQueryable<Country>)employeeContext.Countries).GetEnumerator().Returns(listCountry.GetEnumerator());
            var countryService = new CountryService(employeeContext);
            // Act
            countryService.Delete(null);

            // Assert
        }

        [AssemblyInitialize]
        public static void Init(TestContext testContext)
        {
          
        }
    }
}
