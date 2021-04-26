using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ghadir.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public ActionResult Index()
        {
            return View();
        }
        public T GetSession<T>(string name)
        {
            if (Session[name] == null) return default;
            return (T)Session[name];
        }
    }
}