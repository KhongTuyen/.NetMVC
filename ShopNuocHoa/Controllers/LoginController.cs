using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopNuocHoa.Models;
namespace ShopNuocHoa.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        ShopDB db = new ShopDB();
        account acc = new account();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {

            var users = db.accounts.Where(p => p.username == username && p.passwords == password ).FirstOrDefault();
            
           
            if (users == null )
            {
                
                ViewBag.error = "-Invalid username or password !";

                return View("Index");
            }
            if (users.rol == true)
            {

                ViewBag.error = "-Invalid username or password !";

                return View("Index");
            }
            else
             {              
                
                    Session["user"] = users.name;
                    return RedirectToAction("Index", "Home");                           
            }
            
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            Session["Cart"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}