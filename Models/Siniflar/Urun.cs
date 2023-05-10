using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kockegy.Models.Siniflar
{
    public class Urun
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Kategori Kategori { get; set; }


}
}