using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopNuocHoa.Models;
using ShopNuocHoa.Security;

namespace ShopNuocHoa.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private ShopDB db = new ShopDB();

        // GET: Admin/Product
    
        public ActionResult Index()
        {
            var products = db.products.ToList();
           
            return View(products);
        }

        // GET: Admin/Product/Details/5
      
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.id_category = new SelectList(db.categories, "id_category", "name_category");
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_product,name_product,image,old_price,new_price,quantity,Description,id_category")] product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.image = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string Filename = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/Images/" + Filename);
                        f.SaveAs(UploadPath);
                        product.image = Filename;
                    }
                    db.products.Add(product);
                    db.SaveChanges();
                   
                }
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu ! " + e.Message;
                ViewBag.id_category = new SelectList(db.categories, "id_category", "name_category", product.id_category);
                return View(product);
            }
            

            
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_category = new SelectList(db.categories, "id_category", "name_category", product.id_category);
            return View(product);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_product,name_product,image,old_price,new_price,quantity,Description,id_category")] product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {

                        string Filename = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/Images/" + Filename);
                        f.SaveAs(UploadPath);
                        product.image = Filename;
                    }
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                  
                }
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu ! " + e.Message;
                ViewBag.id_category = new SelectList(db.categories, "id_category", "name_category", product.id_category);
                return View(product);
            }
          
            
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
