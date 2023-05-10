using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class KategoriRepository : GenericRepository<Kategori>
    {
        DataContext db = new DataContext();
        public List<Urun> KategoriDetays(int id)
        {
            return db.Uruns.Where(x => x.KategoriId == id).ToList();

        }

    }
}
