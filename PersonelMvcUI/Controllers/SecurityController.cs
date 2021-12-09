using PersonelMvcUI.Models.EntittyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonelMvcUI.Controllers
{
    [AllowAnonymous]

    public class SecurityController : Controller
    {
        
        PersonelDBEntities db = new PersonelDBEntities();
        
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanici kullanici)
        {
            int count = 0;
            var newCount = Session["count"];
            if (newCount != null)
            {
                count = (int)newCount;
            }
            var kullaniciInDb = db.Kullanici.FirstOrDefault(x => x.Ad == kullanici.Ad && x.Sifre == kullanici.Sifre);
            if (kullaniciInDb != null)
            {
                FormsAuthentication.SetAuthCookie(kullaniciInDb.Ad, false);
                return RedirectToAction("Index","Home");
            }
            else
            {
                count++;
                Session.Add("count", count);
                ModelState.AddModelError("", "Geçersiz Kullanıcı Adı veya Şifre " + "(" + count + ") kere yanlış girdiniz.");
               
                return View();
               
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        
    }
   
}