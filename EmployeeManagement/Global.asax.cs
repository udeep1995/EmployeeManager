using EmployeeManagement.Model;
using EmployeeManagement.Service;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;

namespace EmployeeManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var container = new UnityContainer();
            container.RegisterType<ICountryService, CountryService>();
            container.RegisterType<IPersonService, PersonService>();
            container.RegisterType<IEmployeeContext, EmployeeContext>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));


            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<EmployeeContext>(null);
        }
    }
}
