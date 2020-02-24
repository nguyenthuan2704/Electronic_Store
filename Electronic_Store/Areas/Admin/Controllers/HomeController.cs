using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Electronic_Store.Models;
using System.Data.Entity;
using PagedList;
using System.Collections.ObjectModel;

namespace Electronic_Store.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private electronic_storeEntities db = new electronic_storeEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Chart()
        {
            return View();
        }

        public ActionResult Product(int page = 1, int pageSize = 9)
        {
            List<product> products = db.products.ToList();
            PagedList<product> model = new PagedList<product>(products, page, pageSize);
            return View(model);
        }

        public ActionResult Delete_Product(int id)
        {
            var product = db.products.Find(id);
            var upload_images = db.upload_images.Where(x => x.product_id == id).FirstOrDefault();
            db.products.Remove(product);
            db.upload_images.Remove(upload_images);
            db.SaveChanges();
            return RedirectToAction("Product");
        }

        [HttpGet]
        public ActionResult Add_Product()
        {
            //var categories = db.categories.ToList();
            //var products = db.products.ToList();
            //var category_list = from cat in categories join pro in products on cat.id equals pro.category_id select new { CategoryID = pro.category_id, CategoryName = cat.name };
            //var list_category = category_list.ToList();
            var list_category = db.categories.ToList();
            SelectList list = new SelectList(list_category, "id", "name");
            ViewBag.categorys = list;
            return View();
        }

        [HttpPost]
        public ActionResult Add_Product(product product,upload_images upload_images, HttpPostedFileBase photo, HttpPostedFileBase[] photos)
        {
            if(ModelState.IsValid)
            {
                if (photo != null)
                {

                    photo.SaveAs(Server.MapPath("~/Public/images/" + photo.FileName));
                    product.images = photo.FileName;
                }
                else
                {
                    string picture = "no-image.jpg";
                    product.images = picture;
                }
                if (photos != null)
                {
                    List<string> files = new List<string>();
                    foreach (var pictures in photos)
                    {
                        pictures.SaveAs(Server.MapPath("~/Public/images/" + pictures.FileName));
                        //files.Add(pictures.FileName);
                        upload_images.url_images = pictures.FileName;
                    }
                }
                else
                {
                    string no_picture = "no-image.jpg";
                    upload_images.url_images = no_picture;
                }
                upload_images.product_id = product.id;
                db.products.Add(product);
                db.upload_images.Add(upload_images);
                db.SaveChanges();
                return RedirectToAction("Product");
            }
            else
            {
                return View("Add_Product");
            }
            //if (photo != null)
            //{

            //    photo.SaveAs(Server.MapPath("~/Public/images/" + photo.FileName));
            //    product.images = photo.FileName;
            //}
            //else
            //{
            //    string picture = "no-image.jpg";
            //    product.images = picture;
            //}
            //if (photos != null)
            //{
            //    List<string> files = new List<string>();
            //    foreach (var pictures in photos)
            //    {
            //        pictures.SaveAs(Server.MapPath("~/Public/images/" + pictures.FileName));
            //        //files.Add(pictures.FileName);
            //        upload_images.url_images = pictures.FileName;
            //    }
            //}
            //else
            //{
            //    string no_picture = "no-image.jpg";
            //    upload_images.url_images = no_picture;
            //}
            //upload_images.product_id = product.id;
            //db.products.Add(product);
            //db.upload_images.Add(upload_images);
            //db.SaveChanges();
            //return RedirectToAction("Product");
        }

        [HttpGet]
        public ActionResult Update_Product(int id)
        {
            var product = db.products.Find(id);
            var list_category = db.categories.ToList();
            SelectList list = new SelectList(list_category, "id", "name");
            ViewBag.categorys = list;
            return View("Update_Product", product);
        }

        [HttpPost]
        public ActionResult Update_Product(product product, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    photo.SaveAs(Server.MapPath("~/Public/images/" + photo.FileName));
                    product.images = photo.FileName;
                }
                else
                {
                    var picture = product.images;
                    product.images = picture;
                }
                //product.category_id = product.category.id;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Product");
            }
            else
            {
                return View("Update_Product");
            }
            //if (photo != null)
            //{
            //    photo.SaveAs(Server.MapPath("~/Public/images/" + photo.FileName));
            //    product.images = photo.FileName;
            //}
            //else
            //{
            //    //string picture = "no-image.jpg";
            //    var picture = product.images;
            //    product.images = picture;
            //}
            //product.category_id = product.category.id;
            //db.Entry(product).State = EntityState.Modified;
            //db.SaveChanges();
            //return RedirectToAction("Product");
        }
    }
}