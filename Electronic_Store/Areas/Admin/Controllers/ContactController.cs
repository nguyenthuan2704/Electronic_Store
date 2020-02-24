using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Electronic_Store.Models;
using System.Data.Entity;

namespace Electronic_Store.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        electronic_storeEntities db = new electronic_storeEntities();
        // GET: Admin/Contact
        public ActionResult Contact()
        {
            ViewBag.contact = db.contacts.ToList();
            return View();
        }
        [HttpGet]
        public ActionResult Reply_Contact(int id)
        {
            var reply = db.contacts.Find(id);
            return View("Reply_Contact", reply);
        }
        [HttpPost]
        public ActionResult Reply_Contact()
        {
            return View();
        }
        public ActionResult Delete_Contact(int id)
        {
            var contact = db.contacts.Find(id);
            db.contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Contact");
        }

        [HttpGet]
        public ActionResult Detail_Contact(int id)
        {
            var contact = db.contacts.Find(id);
            return View("Detail_Contact", contact);
        }
        [HttpPost]
        public ActionResult Detail_Contact(contact contact)
        {
            contact.status = false;
            db.Entry(contact).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Contact");
        }
    }
}