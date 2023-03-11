using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ShopNuocHoa.Models;

namespace ShopNuocHoa.Controllers
{
    public class ProductsController : Controller
    {
        private ShopDB db = new ShopDB();

        // GET: Products
        public ActionResult Index(int? page , int? pagesize,string search)
        {
            var products = db.products.ToList();
            /*var product = db.products.Select(p=>p);*/
            
          
            /* end*/
            pagesize = 8;
            int pagenumber = (page ?? 1);
            if (!String.IsNullOrEmpty(search))
            {
                products = db.products.Where(p => p.name_product.Contains(search)).ToList();
            }

            return View(products.ToPagedList(pagenumber, (int)pagesize));
        }

        [ChildActionOnly]
        public ActionResult Menu( string sort)
        {
            var products = db.products.ToList();
           ViewBag.SortName = string.IsNullOrEmpty(sort) ? "name_desc" : "";
            ViewBag.SortPrice = sort == "Gia" ? "gia_desc" : "new_price";
            /*switch (sort)
            {
                case "name_desc":
                    products = (List<product>)products.OrderByDescending(p => p.name_product);
                    break;
                    *//* case "gia_desc":
                         products = (List<product>)products.OrderBy(x => x.new_price);
                         break;
                     case "Gia":
                         products = (List<product>)products.OrderByDescending(x => x.new_price);
                         break;              
                     default:
                         products = (List<product>)products.OrderBy(x => x.name_product);
                         break;*//*
            }*/

            return PartialView("_AllProduct", products);
        }

        public PartialViewResult Menu_Category()
        {
            var list = db.categories.ToList();
            return PartialView(list);
        }
        public ActionResult ProductByCate(string id)
        {
            var list = db.products.Where(s => s.id_category == id).ToList();
            return View(list);
        }
        public PartialViewResult Blog()
        {
            var list = db.blogs.Take(3).ToList();
            return PartialView(list);
        }

        
        // GET: Products/Details/5
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

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.id_category = new SelectList(db.categories, "id_category", "name_category");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_product,name_product,image,old_price,new_price,quantity,Description,id_category")] product product)
        {
            if (ModelState.IsValid)
            {
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_category = new SelectList(db.categories, "id_category", "name_category", product.id_category);
            return View(product);
        }

        // GET: Products/Edit/5
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

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_product,name_product,image,old_price,new_price,quantity,Description,id_category")] product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_category = new SelectList(db.categories, "id_category", "name_category", product.id_category);
            return View(product);
        }

        // GET: Products/Delete/5
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

        // POST: Products/Delete/5
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
