using AdaugareProduse.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdaugareProduse.Controllers
{
    public class ProduseController : Controller
    {
        private ProdusDBContext db = new ProdusDBContext();

        public ActionResult Index()
        {
            var produse = db.Produse.Include("Categorie");
            ViewBag.Produse = produse;

            return View();
        }

        public ActionResult Show(int id)
        {
            Produs produs = db.Produse.Find(id);
            ViewBag.Produs = produs;
            ViewBag.Categorie = produs.Categorie;

            return View();
        }

        public ActionResult New()
        {
            var categorii = from categorie in db.Categorii select categorie;
            ViewBag.Categorii = categorii;

            return View();
        }

        [HttpPost]
        public ActionResult New(Produs produs)
        {
            try
            {
                db.Produse.Add(produs);
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
            Produs produs = db.Produse.Find(id);
            ViewBag.Produs = produs;
            ViewBag.Categorie = produs.Categorie;
            var categorii = from categorie in db.Categorii select categorie;
            ViewBag.Categorii = categorii;

            return View();
        }

        [HttpPut]
        public ActionResult Edit(int id, Produs requestProdus)
        {
            try
            {
                Produs produs = db.Produse.Find(id);
                if (TryUpdateModel(produs))
                {
                    produs.Titlu = requestProdus.Titlu;
                    produs.Descriere = requestProdus.Descriere;
                    produs.Pret = requestProdus.Pret;
                    produs.IdCategorie = requestProdus.IdCategorie;
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
            Produs produs = db.Produse.Find(id);
            db.Produse.Remove(produs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}