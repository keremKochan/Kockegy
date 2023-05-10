using System;
using System.Collections.Generic;
using System.Linq;
using EntityLayer.Entities;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccessLayer.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Satis> Satis { get; set; }
        public DbSet<Sepet> Sepets { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Kullanici> Kullanicis { get; set; }
    }
}
