using AdaugareProduse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdaugareProduse.Controllers
{
    public class CategoriiController : Controller
    {
        private ProdusDBContext db = new ProdusDBContext();

        public ActionResult Index()
        {
            var categorii = from categorie in db.Categorii
                            orderby categorie.NumeCategorie
                            select categorie;
            ViewBag.Categorii = categorii;
            return View();
        }

        public ActionResult Show(int id)
        {
            Categorie categorie = db.Categorii.Find(id);
            ViewBag.Categorie = categorie;

            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Categorie categorie)
        {
            try
            {
                db.Categorii.Add(categorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Categorie categorie = db.Categorii.Find(id);
            ViewBag.Categorie = categorie;
            return View();
        }

        [HttpPut]
        public ActionResult Edit(int id, Categorie requestCategorie)
        {
            try
            {
                Categorie categorie = db.Categorii.Find(id);
                if(TryUpdateModel(categorie))
                {
                    categorie.NumeCategorie = requestCategorie.NumeCategorie;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Categorie categorie = db.Categorii.Find(id);
            db.Categorii.Remove(categorie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}