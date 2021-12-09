using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonelMvcUI.Models.EntittyFramework;
using System.Data.Entity;
using PersonelMvcUI.ViewModels;

namespace PersonelMvcUI.Controllers
{
    
    public class PersonelController : Controller
    {
        PersonelDBEntities db = new PersonelDBEntities();
        // GET: Personel
        [Authorize(Roles = "A,U,E")]
        public ActionResult Index()
        {
            var model = db.Personel.Include(x=>x.Departman).ToList();
            var z = db.Personel.ToList();
            return View(model);
        }
        [Authorize(Roles = "A,E")]
        public ActionResult Sil(int id)
        {
            var silinecekPersonel = db.Personel.Find(id);
            if (silinecekPersonel == null)
                return HttpNotFound();
            db.Personel.Remove(silinecekPersonel);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        [Authorize(Roles = "A,E")]
        public ActionResult Yeni()
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personel = new Personel()
            };
            return View("PersonelForm",model);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                var model = new PersonelFormViewModel()
                {
                    Departmanlar = db.Departman.ToList(),
                    Personel=personel

                };
                return View("PersonelForm",model);
            }
            if (personel.Id==0)
            {
                db.Personel.Add(personel);
            }
            else //Güncelleme
            {
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A,E")]
        public ActionResult Guncelle(int id)
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personel = db.Personel.Find(id)
            };
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("PersonelForm",model);

        }
        public ActionResult PersonelleriListele(int id)
        {
            var model = db.Personel.Where(x => x.DepartmanId == id).ToList();
            return PartialView(model);
        }
        public int? ToplamMaas()
        {
            return db.Personel.Sum(x=>x.Maas);
        }
    }
}