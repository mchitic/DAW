using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProiect.Models;

namespace WebApplicationProiect.Controllers
{
    public class ProdusController : Controller
    {
        private  ProdusDBContext db = new ProdusDBContext();

        public ActionResult Show(int id)
        {
            Produs produs1 = db.Produse.Find(id);
            // Convert image to byte array  
            byte[] byteData = produs1.ImageFile;
            //Convert byte arry to base64string   
            string imreBase64Data = Convert.ToBase64String(byteData);
            string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            //Passing image data in viewbag to view  
            ViewBag.ImageData = imgDataURL;
            ViewBag.Produsul = produs1;
            return View();
        }

        public ActionResult Index()
        {
            var produse1 = from produs in db.Produse
                           select produs;
            string[] terms = new string[400];
            int i = 0;
            foreach (var prod in produse1)
            {
                byte[] byteData = prod.ImageFile;
                //Convert byte arry to base64string   
                string imreBase64Data = Convert.ToBase64String(byteData);
                string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
                //Passing image data in viewbag to view  
                terms[i] = imgDataURL;
                i++;

            }
            ViewBag.ImageData = terms;
            ViewBag.Produse12 = produse1;
            return View();
        }

        // GET: Add Produs
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        //POST: Add Produs
        [HttpPost]
        public ActionResult Add(Produs ProdusModel, HttpPostedFileBase ImageFile1)
        {
            if (ImageFile1 != null)
            {
                ProdusModel.ImageFile = new byte[ImageFile1.ContentLength];
                ImageFile1.InputStream.Read(ProdusModel.ImageFile, 0, ImageFile1.ContentLength);
             

            }
            db.Produse.Add(ProdusModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Produs prd1 = db.Produse.Find(id);
            db.Produse.Remove(prd1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Produs prd2 = db.Produse.Find(id);
            ViewBag.ProdusulDeEditat = prd2;
            return View();
        }

        [HttpPut]
        public ActionResult Edit(int id, Produs requestProd)
        {
            try
            {
                Produs produs_de_editat = db.Produse.Find(id);
                if (TryUpdateModel(produs_de_editat))
                {
                    produs_de_editat.Title = requestProd.Title;
                    produs_de_editat.Description = requestProd.Description;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}