using ShopNuocHoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNuocHoa.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShopDB db = new ShopDB();
        // GET: ShoppingCart

        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        // add item in cart
        public ActionResult AddtoCart(string id)
        {
            var pro = db.products.SingleOrDefault(s => s.id_product == id);
            if (pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowtoCart", "ShoppingCart");
        }
        //trang gio hang
        public ActionResult ShowtoCart()
        {

            if (Session["Cart"] == null) return RedirectToAction("CartisNull", "ShoppingCart");

            Cart cart = Session["Cart"] as Cart;

            return View(cart);
        }
        [HttpPost]
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            string id_product = form["id_product"];
            int quantity = int.Parse(form["quantity"]);
            cart.Update_Quantity(id_product, quantity);
            return RedirectToAction("ShowtoCart", "ShoppingCart");
        }
        [HttpPost]
        public ActionResult Remove_Item(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            string id_product = form["id_product"];
            cart.Remove(id_product);
            return RedirectToAction("ShowtoCart", "ShoppingCart");
        }
        public PartialViewResult Total_Quantity()
        {
            int total_quantity = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
            {
                total_quantity = cart.total_quantity();
                ViewBag.count = total_quantity;
                return PartialView("Total_Quantity");
            }
            return PartialView("Total_Quantity");
        }
        public ActionResult CartisNull()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }
       
        public ActionResult Success()
        {
            return View();
        }
        [HttpPost]
        public ActionResult check(FormCollection f) 
        {
            try
            {


                Cart cart = Session["Cart"] as Cart;


                string name = f["name"];
                ViewBag.name = name;
                var phone = f["phone"];
                var email = f["email"];
                var address = f["address"];
                var note = f["note"];


                foreach (var item in cart.Items)
                {

                    checkout check = new checkout();
                    check.date_checkout = DateTime.Now.Date;
                    check.id_checkout = "1";
                    check.payment_infor = name + "," + phone + "," + email + "," + address + "," + note;
                    check.status = "Chờ xử lý";
                    db.checkouts.Add(check);

                }
                db.SaveChanges();
                cart.Clear();
                return RedirectToAction("Success", "ShoppingCart");
            }
            catch
            {
                return Content("Error");
            }
        }
}
}