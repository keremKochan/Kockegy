using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityLayer.Entities
{
    public class Kategori
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "Ad")]
        [StringLength(50, ErrorMessage = "Maksimum 50 Karakter Olmalıdır.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "Açıklama")]
        [StringLength(50, ErrorMessage = "Maksimum 50 Karakter Olmalıdır.")]
        public string Aciklama { get; set; }
        public virtual List<Urun> Urunler { get; set; }
    }
}