using PersonelMvcUI.Models.EntittyFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonelMvcUI.ViewModels
{
    public class PersonelFormViewModel
    {
        [Display(Name = "Departmanlar")]
        public IEnumerable<Departman> Departmanlar { get; set; }
        public Personel Personel { get; set; }
        public Personel Id { get; set; }
        public Nullable<int> DepartmanId { get; set; }
        [Display(Name = "İsim")]
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Nullable<int> Maas { get; set; }
        public Nullable<System.DateTime> DogumTarihi { get; set; }
        public bool Cinsiyet { get; set; }
        public bool EvliMi { get; set; }

        public virtual Departman Departman { get; set; }
    }
}