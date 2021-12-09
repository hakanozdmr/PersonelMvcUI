using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonelMvcUI.ViewModels
{
    public class KullaniciCreateViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Kullancı Adı ")]
        public string Ad { get; set; }
        [Display(Name ="Şifre")]
        public string Sifre { get; set; }
        [Display(Name = "Rol")]
        public string Rol { get; set; }

    }
}