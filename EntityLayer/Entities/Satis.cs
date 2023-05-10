
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace EntityLayer.Entities
{
    public class Satis
    {
        public int Id { get; set; }
        [Display(Name = "Ürün")]
        public int UrunId { get; set; }
        public virtual Urun Urun { get; set; }
        [Display(Name = "Adet")]
        public int Adet { get; set; }
        [Display(Name = "Tutar")]
        public int Ucret { get; set; }
        [Display(Name = "Tarih")]
        public DateTime Tarih { get; set; }
        [Display(Name = "Resim")]
        public string Resim { get; set; }
        [Display(Name = "Kullanıcı")]
        public int UserId { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}