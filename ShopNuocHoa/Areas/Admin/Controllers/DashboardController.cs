using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopNuocHoa.Models;
using ShopNuocHoa.Security;

namespace ShopNuocHoa.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        ShopDB db = new ShopDB();
        // GET: Admin/Home
      /*  [IsAdmin]*/
        public ActionResult Index()
        {
            ViewBag.ProductCount = db.products.Count();
            ViewBag.CustomerCount = db.accounts.Count(p=>p.rol == true);
          
            return View();
        }
    }
}