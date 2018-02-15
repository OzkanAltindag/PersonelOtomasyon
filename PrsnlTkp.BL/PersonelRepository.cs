using PrsnlTkp.DAL;
using PrsnlTkp.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsnlTkp.BL
{
 public   class PersonelRepository : Irepository<PersonelBilgi>

    {
        PersonelTakipEntities db = new PersonelTakipEntities();

        public void Delete(Int64 TcNo)
        {
            db.PersonelBilgi.Remove((db.PersonelBilgi.Find(TcNo)));
            db.SaveChanges();
           
        }

        public void Insert(PersonelBilgi item)
        {
            db.PersonelBilgi.Add(item);
            db.SaveChanges();
        }

        public List<PersonelBilgi> selectAll()
        {
            return db.PersonelBilgi.ToList();
        }

        public void Update(Int64 Tcno)
           
        {
            PersonelBilgi updated = db.PersonelBilgi.Find(Tcno);
            db.Entry(updated).CurrentValues.SetValues(Tcno);
            db.SaveChanges();
            
        }
        public List<PersonelBilgi> selectbytcno(Int64 tcno)
        {
            return db.PersonelBilgi.Where(f => f.TcKimlikNo == tcno).ToList();

        }

        public void Delete(int TcNo)
        {
            
        }

        public void Update(PersonelBilgi item)
        {
            throw new NotImplementedException();
        }
    }
}
