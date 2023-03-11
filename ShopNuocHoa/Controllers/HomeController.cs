using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopNuocHoa.Models;
namespace ShopNuocHoa.Controllers
{
    public class HomeController : Controller
    {
        ShopDB db = new ShopDB();

        public ActionResult Index(string search)
        {
            var list = db.products.Take(12).ToList();

            ViewBag.Blog = db.blogs.Take(3).ToList();
            ViewBag.search = search;
            if (!String.IsNullOrEmpty(search))
            {
                list = db.products.Where(p => p.name_product.Contains(search)).ToList();
               
            }

            return View(list);
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
    }
}