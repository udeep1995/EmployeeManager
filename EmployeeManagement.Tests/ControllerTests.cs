using System.Web.Mvc;
using EmployeeManagement.Controllers;
using EmployeeManagement.Model;
using EmployeeManagement.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeManagement.Test
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void Index_ShouldReturnView()
        {
            ICountryService fakeService = new FakeCountryService();
            // Arrange
            CountryController cc = new CountryController(fakeService);

            // Act
             var result = cc.Index();

            // Assert
             Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void Create_ValidArgumentAs_Country_ShouldReturnRedirectionToRouteResult()
        {
            ICountryService fakeService = new FakeCountryService();
            // Arrange
            CountryController cc = new CountryController(fakeService);
            Country country = new Country() {
                Id = 1,
                Name = "India"
            };

            // Act
            var result = cc.Create(country);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }
        [TestMethod]
        public void Create_InValidArgumentAs_ModelStateError_ShouldReturnViewResult()
        {
            ICountryService fakeService = new FakeCountryService();
            // Arrange
            CountryController cc = new CountryController(fakeService);
            Country country = new Country();
            cc.ModelState.AddModelError("Required", "Name is required");
            // Act
            var result = cc.Create(country);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Edit_ValidArgumentAs_Country_ShouldReturnRedirectionToRouteResult()
        {
            ICountryService fakeService = new FakeCountryService();
            // Arrange
            CountryController cc = new CountryController(fakeService);
            Country country = new Country()
            {
                Id = 1,
                Name = "India"
            };

            // Act
            var result = cc.Edit(country);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }
        [TestMethod]
        public void Edit_InValidArgumentAs_InvalidId_ShouldReturnHttpNotFoundResult()
        {
            ICountryService fakeService = new FakeCountryService();
            // Arrange
            CountryController cc = new CountryController(fakeService);
            int Id = 0;

            // Act
            var result = cc.Edit(Id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }
        [TestMethod]
        public void Edit_ValidArgumentAs_Id_ShouldReturnViewResult()
        {
            ICountryService fakeService = new FakeCountryService();
            // Arrange
            CountryController cc = new CountryController(fakeService);
            int Id = 1;

            // Act
            var result = cc.Edit(Id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void Delete_InValidArgumentAs_InvalidId_ShouldReturnHttpNotFoundResult()
        {
            ICountryService fakeService = new FakeCountryService();
            // Arrange
            CountryController cc = new CountryController(fakeService);
            int Id = 0;

            // Act
            var result = cc.Delete(Id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }
        [TestMethod]
        public void Delete_ValidArgumentAs_Id_ShouldReturnViewResult()
        {
            ICountryService fakeService = new FakeCountryService();
            // Arrange
            CountryController cc = new CountryController(fakeService);
            int Id = 1;

            // Act
            var result = cc.Delete(Id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void Delete_ValidArgumentAs_IdAndFormCollection_ShouldReturnRedirectionToRouteResult()
        {
            ICountryService fakeService = new FakeCountryService();
            // Arrange
            CountryController cc = new CountryController(fakeService);
            int Id = 1;
            FormCollection data = null;
            // Act
            var result = cc.Delete(Id, data);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }
    }
}
