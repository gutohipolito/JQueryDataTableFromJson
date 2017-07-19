using System.Collections.Generic;
using System.Web.Mvc;

namespace JQueryDataTableFromJson.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Data()
        {
            var data = new
            {
                data = new List<object>
                {
                    new { id = 1, name = "John"},
                    new {id = 2, name = "Peter"},
                    new {id = 3, name = "Ben"},
                    new {id = 4, name = "Clark"},
                    new {id = 5, name = "Lois"},
                    new {id = 6, name = "Kara"}
                }
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}