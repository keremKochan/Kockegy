using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityLayer.Entities
{
    public class Urun
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "Ad")]
        [StringLength(50, ErrorMessage = "Maksimum 50 Karakter Olmalıdır.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "Resim")]
        public string Resim { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "Açıklama")]
        [StringLength(50, ErrorMessage = "Maksimum 50 Karakter Olmalıdır.")]
        public string Aciklama { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "Fiyat")]
        public int Fiyat { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "Stok")]
        public int Stok { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "Onay")]
        public bool Onaylimi { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "Populer")]
        public bool Populer { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "Kategori")]
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }

        public virtual List<Sepet> Sepet { get; set; }
        public virtual List<Satis> Satis { get; set; }
    }
}