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
    public class UserController : Controller
    {
        electronic_storeEntities db = new electronic_storeEntities();
        // GET: Admin/User
        public ActionResult Users()
        {
            ViewBag.user = db.users.ToList();
            return View();
        }

        public static string HashSHA1Decryption(string value)
        {
            var shaSHA1 = System.Security.Cryptography.SHA1.Create();
            var inputEncodingBytes = Encoding.ASCII.GetBytes(value);
            var hashString = shaSHA1.ComputeHash(inputEncodingBytes);

            var stringBuilder = new StringBuilder();
            for (var x = 0; x < hashString.Length; x++)
            {
                stringBuilder.Append(hashString[x].ToString("X2"));
            }
            return stringBuilder.ToString();
        }

        public ActionResult Delete_User(int id)
        {
            var user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Users");
        }

        [HttpGet]
        public ActionResult Add_User()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_User(user user, HttpPostedFileBase photo)
        {
            if(ModelState.IsValid)
            {
                if (photo != null)
                {
                    photo.SaveAs(Server.MapPath("/Areas/Admin/Assets/images/" + photo.FileName));
                    user.images = photo.FileName;
                }
                else
                {
                    string picture = "no-image.jpg";
                    user.images = picture;
                }
                var encrypt = HashSHA1Decryption(user.password);
                var encrypts = HashSHA1Decryption(user.confirmpassword);
                user.password = encrypt;
                user.confirmpassword = encrypts;
                user.status = true;
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Users");
            }
            else
            {
                return View("Add_User");
            }
        }
    }
}