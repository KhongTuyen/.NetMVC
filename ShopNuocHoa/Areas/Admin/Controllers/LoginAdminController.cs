using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopNuocHoa.Models;
namespace ShopNuocHoa.Areas.Admin.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: Admin/Login
        ShopDB db = new ShopDB();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string username, string password)
        {

            var admin = db.accounts.Where(p => p.username == username && p.passwords == password).FirstOrDefault();


            if (admin == null)
            {

                ViewBag.error = "-Invalid username or password !";

                return View("Index");
            }
            if (admin.rol == false)
            {

                ViewBag.error = "-Invalid username or password !";

                return View("Index");
            }
            else
            {

                Session["admin"] = admin.name;
                return RedirectToAction("Index","Dashboard");
            }

        }
        public ActionResult Logout()
        {
            Session["admin"] = null;
            return RedirectToAction("Index", "LoginAdmin");
        }
    }
}