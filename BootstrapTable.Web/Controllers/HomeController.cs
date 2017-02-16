using BootstrapTable.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapTable.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() { return View(); }
        public ActionResult Basic() { return View(); }
        public ActionResult Paged() { return View(); }
        public ActionResult Menus() { return View(); }
        public ActionResult Links() { return View(); }
        public ActionResult Sorting() { return View(); }
        public ActionResult TableStyles() { return View(); }
        public ActionResult ColumnStyles() { return View(); }
        public ActionResult Toolbar() { return View(); }
        public ActionResult Search() { return View(); }
        public ActionResult Extensions() { return View(); }
        public ActionResult Checkboxes() { return View(); }

        private List<Person> PeopleSource()
        {
            return new List<Person>
            {
                new Person { Id = 1, FirstName = "Odysseus", LastName = "Kirkland", Email = "fermentum@Proinvelnisl.net", BirthDate = DateTime.Parse("06/06/2000", CultureInfo.CurrentCulture), Location = "Eritrea", },
                new Person { Id = 2, FirstName = "Jocelyn", LastName = "Mccall", Email = "Nullam.lobortis@Fuscefermentum.ca", BirthDate = DateTime.Parse("09/09/1949", CultureInfo.CurrentCulture), Location = "Bolivia", },
                new Person { Id = 3, FirstName = "Lael", LastName = "Trujillo", Email = "enim.Suspendisse.aliquet@nec.com", BirthDate = DateTime.Parse("09/09/1991", CultureInfo.CurrentCulture), Location = "Sri Lanka", },
                new Person { Id = 4, FirstName = "Chelsea", LastName = "Mcgee", Email = "magna.et@dolornonummyac.co.uk", BirthDate = DateTime.Parse("07/07/1960", CultureInfo.CurrentCulture), Location = "Hungary", },
                new Person { Id = 5, FirstName = "Connor", LastName = "Pope", Email = "In.tincidunt@eu.com", BirthDate = DateTime.Parse("07/07/1987", CultureInfo.CurrentCulture), Location = "Albania", },
                new Person { Id = 6, FirstName = "Dustin", LastName = "Arnold", Email = "ante.Nunc@Pellentesquetincidunttempus.com", BirthDate = DateTime.Parse("04/04/1946", CultureInfo.CurrentCulture), Location = "Lithuania", },
                new Person { Id = 7, FirstName = "Tatum", LastName = "Dale", Email = "turpis.egestas.Aliquam@atauctor.edu", BirthDate = DateTime.Parse("05/05/1981", CultureInfo.CurrentCulture), Location = "South Africa", },
                new Person { Id = 8, FirstName = "Priscilla", LastName = "Roach", Email = "at.fringilla@risus.com", BirthDate = DateTime.Parse("05/05/1984", CultureInfo.CurrentCulture), Location = "Lebanon", },
                new Person { Id = 9, FirstName = "Cade", LastName = "Smith", Email = "auctor.velit.eget@egetvolutpat.edu", BirthDate = DateTime.Parse("03/03/1978", CultureInfo.CurrentCulture), Location = "New Zealand", },
                new Person { Id = 10, FirstName = "James", LastName = "Frank", Email = "purus.Nullam@iderat.co.uk", BirthDate = DateTime.Parse("07/07/1954", CultureInfo.CurrentCulture), Location = "Norfolk Island", },
            };
        }

        public JsonResult GetPeopleData()
        {
            System.Threading.Thread.Sleep(1000);
            return Json(PeopleSource(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPeoplePaged(int offset, int limit, string search, string sort, string order)
        {
            var people = PeopleSource();
            var model = new
            {
                total = people.Count(),
                rows = people.Skip((offset / limit) * limit).Take(limit),
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPeopleSearch(int offset, int limit, string search, string sort, string order)
        {
            var people = PeopleSource().AsQueryable()
                .WhereIf(!string.IsNullOrEmpty(search), o =>
                    o.Email.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                    o.FirstName.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                    o.LastName.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                    o.Location.Contains(search, StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(sort ?? "LastName", order)
                .ToList();

            var model = new
            {
                total = people.Count(),
                rows = people.Skip((offset / limit) * limit).Take(limit),
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MenuAction(int id)
        {
            if (Request.IsAjaxRequest())
                return JavaScript("alert('MenuAction id = " + id + "')");
            else
                return View("MenuAction", id);
        }

        public ActionResult TableAction(int[] ids)
        {
            if (ids != null)
                return Json(new { result = string.Join(", ", ids) });
            else
                return Json(new { result = "Nothing selected!" });
        }
    }
}