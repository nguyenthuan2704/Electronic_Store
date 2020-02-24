using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Electronic_Store.Models;
using System.Data.Entity;
using PagedList;
using System.Security.Cryptography;
using System.Text;

namespace Electronic_Store.Controllers
{
    public class HomeController : Controller
    {
        private electronic_storeEntities db = new electronic_storeEntities();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.cpu = db.products.OrderByDescending(x=>x.id).Where(x => x.category_id == 2 && x.status == true).Take(3).ToList();
            ViewBag.vga = db.products.OrderByDescending(x => x.id).Where(x => x.category_id == 4 && x.status == true).Take(3).ToList();
            ViewBag.cases = db.products.OrderByDescending(x => x.id).Where(x => x.category_id == 7 && x.status == true).Take(3).ToList();
            ViewBag.categories = db.categories.ToList();
            return View();
        }

        public ActionResult Detail_Category(int id, int page = 1, int pageSize = 9)
        {
            ViewBag.categories = db.categories.ToList();
            List<product> products = db.products.Where(x => x.category_id == id).ToList();
            PagedList<product> model = new PagedList<product>(products, page, pageSize);
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.categories = db.categories.ToList();
            return View();
        }
        [HttpGet]
        public ActionResult Contact_Us()
        {
            ViewBag.categories = db.categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Contact_Us(contact contact)
        {
            if(ModelState.IsValid)
            {
                contact.created_at = DateTime.Now;
                contact.status = true;
                db.contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Contact_Us");
            }
        }

        public ActionResult Product(int page = 1, int pageSize = 9)
        {
            ViewBag.categories = db.categories.ToList();
            List<product> products = db.products.ToList();
            PagedList<product> model = new PagedList<product>(products, page, pageSize);
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            ViewBag.categories = db.categories.ToList();
            ViewBag.images = db.upload_images.Where(x => x.product_id.Equals(id)).ToList();
            var product = db.products.Find(id);
            return View("Detail",product);
        }

        public ActionResult Header()
        {
            ViewBag.categories = db.categories.ToList();
            return PartialView();
        }

        public ActionResult Menu_Right()
        {
            ViewBag.categories = db.categories.ToList();
            return PartialView();
        }
        [HttpGet]
        public ActionResult Search(string keyword)
        {
            ViewBag.categories = db.categories.ToList();
            ViewBag.Error = "Không tìm thấy sản phẩm!";
            if (!String.IsNullOrEmpty(keyword))
            {
                ViewBag.products = db.products.Where(s => s.name.Contains(keyword)).ToList();
            }
            return View();
        }

        public ActionResult Cart()
        {
            ViewBag.categories = db.categories.ToList();
            return View();
        }

        public ActionResult Buy(int id)
        {
            if(Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { product = db.products.Find(id), quanlity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExits(id);
                if(index != -1)
                {
                    cart[index].quanlity++;
                }
                else
                {
                    cart.Add(new Item { product = db.products.Find(id), quanlity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Cart");
        }

        private int isExits(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].product.id.Equals(id))
                    return i;
            return -1;
        }

        public ActionResult Remove(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExits(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Cart");
        }

        public ActionResult Clear()
        {
            //List<Item> cart = (List<Item>)Session["cart"];
            //cart.Clear();
            Session.Clear();
            return RedirectToAction("Cart");
        }

        public ActionResult Update(FormCollection fc)
        {
            string[] quanlities = fc.GetValues("soluong");
            List<Item> cart = (List<Item>)Session["cart"];
            for(int i = 0; i<cart.Count;i++)
                cart[i].quanlity = Convert.ToInt32(quanlities[i]);
            Session["cart"] = cart;
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult Register(customer customers)
        {
            ViewBag.categories = db.categories.ToList();
            if (ModelState.IsValid)
            {
                var encrypt = HashSHA1Decryption(customers.password);
                var encrypts = HashSHA1Decryption(customers.confirmpassword);
                customers.password = encrypt;
                customers.confirmpassword = encrypts;
                customers.status = true;
                db.customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return PartialView("Header");
            }
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

        public JsonResult SaveData(customer model)
        {
            model.status = true;
            db.customers.Add(model);
            db.SaveChanges();
            return Json("Registration Successfull", JsonRequestBehavior.AllowGet);
        }

        public JsonResult Login(customer model)
        {
            string result = "Fail";
            var UserDetails = db.customers.Where(x => x.email == model.email && x.password == model.password).FirstOrDefault();
            if(UserDetails == null)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session["Username"] = UserDetails.fullname;
                result = "Login Successfull";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("Username");
            return RedirectToAction("Index");
        }
    }
}