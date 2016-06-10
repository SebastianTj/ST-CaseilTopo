using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace il_Topolino.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult KlantDetails(int id)
        {
            ViewBag.Message = "Your klant details page.";
            ViewBag.klant_id = id;

            return View();
        }

        public ActionResult KlantList()
        {
            ViewBag.Message = "Your klant list page.";

            return View();
        }

        public ActionResult KlantCreate()
        {
            ViewBag.Message = "Your klant create page.";

            return View();
        }

        public ActionResult KlantDelete(int id)
        {
            ViewBag.Message = "Your klant delete page.";
            ViewBag.klant_id = id;

            return View();
        }

        public ActionResult KlantEdit(int id)
        {
            ViewBag.Message = "Your klant edit page.";
            ViewBag.klant_id = id;

            return View();
        }


    }
}