using EmployeeManagement.Controllers;
using EmployeeManagement.Model;
using EmployeeManagement.Service;
using EmployeeManagement.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EmployeeManagement.Tests
{
    [TestClass]
    public class PersonControllerTests
    {
        [TestMethod]
        public void Index_ShouldReturnViewResult()
        {
            // Arrange
            IPersonService fakePersonService = new FakePersonService();
            ICountryService fakeCountryService = new FakeCountryService();
            PersonController pc = new PersonController(fakePersonService, fakeCountryService);

            // Act
            var result = pc.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));

        }
        [TestMethod]
        public void Details_ValidArgumentAs_1_ShouldReturnViewResult()
        {
            // Arrange
            IPersonService fakePersonService = new FakePersonService();
            ICountryService fakeCountryService = new FakeCountryService();
            PersonController pc = new PersonController(fakePersonService, fakeCountryService);

            // Act
            var result = pc.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }


        [TestMethod]
        public void Details_InValidArgumentAs_Null_ShouldReturnHttpStatusCodeResult()
        {
            // Arrange
            IPersonService fakePersonService = new FakePersonService();
            ICountryService fakeCountryService = new FakeCountryService();
            PersonController pc = new PersonController(fakePersonService, fakeCountryService);

            // Act
            var result = pc.Details(null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        }

        [TestMethod]
        public void Details_InValidArgumentAs_2_ShouldReturnHttpNotFoundResult()
        {
            // Arrange
            IPersonService fakePersonService = new FakePersonService();
            ICountryService fakeCountryService = new FakeCountryService();
            PersonController pc = new PersonController(fakePersonService, fakeCountryService);

            // Act
            var result = pc.Details(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void Create_ShouldReturnViewResult()
        {
            // Arrange
            IPersonService fakePersonService = new FakePersonService();
            ICountryService fakeCountryService = new FakeCountryService();
            PersonController pc = new PersonController(fakePersonService, fakeCountryService);

            // Act
            var result = pc.Create();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void Create_ValidArgumentAs_Person_ShouldReturnRedirectToRouteResult()
        {
            // Arrange
            IPersonService fakePersonService = new FakePersonService();
            ICountryService fakeCountryService = new FakeCountryService();
            PersonController pc = new PersonController(fakePersonService, fakeCountryService);

            Person person = new Person()
            {
                Id = 1,
                Name = "John Doe",
                Address = "Abc",
                CountryId = 1
            };
            // Act
            var result = pc.Create(person);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }


        [TestMethod]
        public void Create_InValidArgumentAs_ModelStateError_ShouldReturnViewResult()
        {
            // Arrange
            IPersonService fakePersonService = new FakePersonService();
            ICountryService fakeCountryService = new FakeCountryService();
            PersonController pc = new PersonController(fakePersonService, fakeCountryService);
            pc.ModelState.AddModelError("Required", "Name is required");
            Person person = new Person()
            {
                Id = 1
            };
            // Act
            var result = pc.Create(person);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }


        [TestMethod]
        public void Edit_ValidArgumentAs_1_ShouldReturnViewResult()
        {
            // Arrange
            IPersonService fakePersonService = new FakePersonService();
            ICountryService fakeCountryService = new FakeCountryService();
            PersonController pc = new PersonController(fakePersonService, fakeCountryService);

            // Act
            var result = pc.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }


        [TestMethod]
        public void Edit_InValidArgumentAs_Null_ShouldReturnHttpStatusCodeResult()
        {
            // Arrange
            IPersonService fakePersonService = new FakePersonService();
            ICountryService fakeCountryService = new FakeCountryService();
            PersonController pc = new PersonController(fakePersonService, fakeCountryService);

            long? id = null;
            // Act
            var result = pc.Edit(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        }

        [TestMethod]
        public void Edit_InValidArgumentAs_2_ShouldReturnHttpNotFoundResult()
        {
            // Arrange
            IPersonService fakePersonService = new FakePersonService();
            ICountryService fakeCountryService = new FakeCountryService();
            PersonController pc = new PersonController(fakePersonService, fakeCountryService);

            // Act
            var result = pc.Edit(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void Edit_ValidArgumentAs_Person_ShouldReturnRedirectToRouteResult()
        {
            // Arrange
            IPersonService fakePersonService = new FakePersonService();
            ICountryService fakeCountryService = new FakeCountryService();
            PersonController pc = new PersonController(fakePersonService, fakeCountryService);

            Person person = new Person()
            {
                Id = 1,
                Name = "John Doe",
                Address = "Abc",
                CountryId = 1
            };
            // Act
            var result = pc.Edit(person);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }


        [TestMethod]
        public void Edit_InValidArgumentAs_ModelStateError_ShouldReturnViewResult()
        {
            // Arrange
            IPersonService fakePersonService = new FakePersonService();
            ICountryService fakeCountryService = new FakeCountryService();
            PersonController pc = new PersonController(fakePersonService, fakeCountryService);
            pc.ModelState.AddModelError("Required", "Name is required");
            Person person = new Person()
            {
                Id = 1
            };
            // Act
            var result = pc.Edit(person);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Delete_ValidArgumentAs_1_ShouldReturnViewResult()
        {
            // Arrange
            IPersonService fakePersonService = new FakePersonService();
            ICountryService fakeCountryService = new FakeCountryService();
            PersonController pc = new PersonController(fakePersonService, fakeCountryService);

            // Act
            var result = pc.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }


        [TestMethod]
        public void Delete_InValidArgumentAs_Null_ShouldReturnHttpStatusCodeResult()
        {
            // Arrange
            IPersonService fakePersonService = new FakePersonService();
            ICountryService fakeCountryService = new FakeCountryService();
            PersonController pc = new PersonController(fakePersonService, fakeCountryService);

            long? id = null;
            // Act
            var result = pc.Delete(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        }

        [TestMethod]
        public void Delete_InValidArgumentAs_2_ShouldReturnHttpNotFoundResult()
        {
            // Arrange
            IPersonService fakePersonService = new FakePersonService();
            ICountryService fakeCountryService = new FakeCountryService();
            PersonController pc = new PersonController(fakePersonService, fakeCountryService);

            // Act
            var result = pc.Delete(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void DeleteConfirmed_ValidArgumentAs_1_ShouldReturnReturnToRouteResult()
        {
            // Arrange
            IPersonService fakePersonService = new FakePersonService();
            ICountryService fakeCountryService = new FakeCountryService();
            PersonController pc = new PersonController(fakePersonService, fakeCountryService);

            // Act
            var result = pc.DeleteConfirmed(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

    }
}
