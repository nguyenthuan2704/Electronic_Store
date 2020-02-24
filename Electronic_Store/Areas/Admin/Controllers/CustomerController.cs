using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Electronic_Store.Models;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;

namespace Electronic_Store.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        electronic_storeEntities db = new electronic_storeEntities();
        // GET: Admin/Customer
        public ActionResult Customer()
        {
            ViewBag.customers = db.customers.ToList();
            return View();
        }

        public ActionResult Delete_Customer(int id)
        {
            var customer = db.customers.Find(id);
            db.customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Customer");
        }
    }
}