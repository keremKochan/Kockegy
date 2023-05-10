using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Yorum
    {
        public int Id { get; set; }
        [DisplayName("Yorum")]
        public string Icerik { get; set; }
        [DisplayName("Ürün")]
        public int UrunId { get; set; }
        public virtual Urun Urun { get; set; }

        [DisplayName("Kullanıcı")]
        public int KullaniciId { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public DateTime Tarih { get; set; }    
    }
}
