﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kockegy.Models.Siniflar
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Urun> Products { get; set; }
    }

}