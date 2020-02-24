using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Electronic_Store.Models;
using System.Data.Entity;

namespace Electronic_Store.Areas.Admin.Controllers
{

    public class CategoryController : Controller
    {
        electronic_storeEntities db = new electronic_storeEntities();
        // GET: Admin/Category
        public ActionResult Index()
        {
            ViewBag.categorys = db.categories.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult Add_Category()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_Category(category category)
        {
            if(ModelState.IsValid)
            {
                db.categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Add_Category");
            }
        }

        [HttpGet]
        public ActionResult Update_Category(int id)
        {
            var category = db.categories.Find(id);
            return View("Update_Category",category);
        }
        [HttpPost]
        public ActionResult Update_Category(category category)
        {
            if(ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Update_Category");
            }
        }
        public ActionResult Delete_Category(int id)
        {
            var category = db.categories.Find(id);
            db.categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}