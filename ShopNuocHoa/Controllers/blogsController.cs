using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopNuocHoa.Models;

namespace ShopNuocHoa.Controllers
{
    public class blogsController : Controller
    {
        public ShopDB db = new ShopDB();

        // GET: blogs
        public ActionResult Index()
        {
            var blogs = db.blogs.Include(b => b.blog_category);
            return View(blogs.ToList());
        }
        
        public PartialViewResult Blog()
        {
            var list = db.blogs.Take(3).ToList();
            return PartialView(list);
        }
        // GET: blogs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            blog blog = db.blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: blogs/Create
        public ActionResult Create()
        {
            ViewBag.id_blogcate = new SelectList(db.blog_category, "id_blogcate", "name_blogcate");
            return View();
        }

        // POST: blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_blog,name_blog,image,Title,id_blogcate")] blog blog)
        {
            if (ModelState.IsValid)
            {
                db.blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_blogcate = new SelectList(db.blog_category, "id_blogcate", "name_blogcate", blog.id_blogcate);
            return View(blog);
        }

        // GET: blogs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            blog blog = db.blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_blogcate = new SelectList(db.blog_category, "id_blogcate", "name_blogcate", blog.id_blogcate);
            return View(blog);
        }

        // POST: blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_blog,name_blog,image,Title,id_blogcate")] blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_blogcate = new SelectList(db.blog_category, "id_blogcate", "name_blogcate", blog.id_blogcate);
            return View(blog);
        }

        // GET: blogs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            blog blog = db.blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            blog blog = db.blogs.Find(id);
            db.blogs.Remove(blog);
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
