using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PersonelMvcUI.Models.EntittyFramework;
using PersonelMvcUI.ViewModels;

namespace PersonelMvcUI.Controllers
{
    public class DepartmanController : Controller
    {
        PersonelDBEntities db = new PersonelDBEntities();
        // GET: Departman

        [Authorize(Roles = "A,U")]
        
        public ActionResult Index()
        {
            var model = db.Departman.ToList();
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "A,E")]
        public ActionResult Yeni()
        {
            return View("DepartmanForm",new Departman());
        }
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Departman departman)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmanForm");
            }
            MesajViewModel model = new MesajViewModel();
            if (departman.Id == 0)
            {
                db.Departman.Add(departman);
                model.Mesaj = departman.Ad + "  başarıyla eklendi...";
            }
            else
            {
                var guncellenicekDepartman = db.Departman.Find(departman.Id);
                if (guncellenicekDepartman == null)
                {
                    return HttpNotFound();
                }
                    guncellenicekDepartman.Ad = departman.Ad;
                    model.Mesaj = departman.Ad + "  başarıyla güncellendi...";
            }
            db.SaveChanges();
            model.Status = true;
            model.LinkText = "Departman Listesi";
            model.Url = "/Departman";
            return View("_Mesaj",model);
        }
        [Authorize(Roles = "A,E")]
        public ActionResult Guncelle(int id) 
        {
            var model = db.Departman.Find(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View("DepartmanForm");
        }
        [Authorize(Roles = "A,E")]
        public JsonResult Sil(int id)
        {
            var silinecekDepartman = db.Departman.Find(id);
            if (silinecekDepartman == null)
                return null;
            db.Departman.Remove(silinecekDepartman);
            db.SaveChanges();
            return null;

        }
    }
}