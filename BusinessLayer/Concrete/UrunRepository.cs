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
    public class UrunRepository:GenericRepository<Urun>
    {
        DataContext db = new DataContext();
        public List<Urun> GetPopulerUrun()
        {
            return db.Uruns.Where(x=>x.Populer == true).ToList();
        }
    }
}
