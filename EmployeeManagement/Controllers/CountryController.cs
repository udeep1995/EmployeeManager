using EmployeeManagement.Model;
using EmployeeManagement.Service;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class CountryController : Controller
    {
        //initialize service object
        CountryService _CountryService;

        public CountryController()
        {
            _CountryService = new CountryService();
        }

        //
        // GET: /Country/
        public ActionResult Index()
        {
            return View(_CountryService.GetAll());
        }

        //
        // GET: /Country/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Country/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Country/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country country)
        {

            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                _CountryService.Create(country);
                return RedirectToAction("Index");
            }
            return View(country);

        }

        //
        // GET: /Country/Edit/5
        public ActionResult Edit(int id)
        {
            Country country = _CountryService.GetById(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        //
        // POST: /Country/Edit/5
        [HttpPost]
        public ActionResult Edit(Country country)
        {

            if (ModelState.IsValid)
            {
                _CountryService.Update(country);
                return RedirectToAction("Index");
            }
            return View(country);

        }

        //
        // GET: /Country/Delete/5
        public ActionResult Delete(int id)
        {
            Country country = _CountryService.GetById(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        //
        // POST: /Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection data)
        {
            Country country = _CountryService.GetById(id);
            _CountryService.Delete(country);
            return RedirectToAction("Index");
        }
    }
}
