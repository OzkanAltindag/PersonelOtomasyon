using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsnlTkp.BL
{
    public interface Irepository<T>
    {
        void Insert(T item);
        void Update(Int64 Tcno);
        void Delete(int TcNo);
        List<T> selectAll();
    }
}
