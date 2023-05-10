using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace EntityLayer.Entities
{
    public class Kullanici
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "Ad")]
        [StringLength(50, ErrorMessage = "Maksimum 50 Karakter Olmalıdır.")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "Soyad")]
        [StringLength(50, ErrorMessage = "Maksimum 50 Karakter Olmalıdır.")]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "Maksimum 50 Karakter Olmalıdır.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "KullaniciAdi")]
        [StringLength(50, ErrorMessage = "Maksimum 50 Karakter Olmalıdır.")]
        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "Sifre")]
        [StringLength(300, ErrorMessage = "Maksimum 10 Karakter Olmalıdır.")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        [Display(Name = "SifreTekrar")]
        [StringLength(300, ErrorMessage = "Maksimum 10 Karakter Olmalıdır.")]
        [DataType(DataType.Password)]
        public string SifreTekrar { get; set; }
        [StringLength(10, ErrorMessage = "Maksimum 10 Karakter Olmalıdır.")]
        public string Rol { get; set; }
    }
}