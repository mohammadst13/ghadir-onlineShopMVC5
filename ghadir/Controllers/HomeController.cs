using ghadir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ghadir.Controllers
{
    public class HomeController : Controller
    {
        MyContext db = new MyContext();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.isHome = true;
            return View(db.Products.ToList());
        }
    }
}