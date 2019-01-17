using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaKiralama.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Ekle(T item);
        void Guncelle(T item);
        void Sil(int item);
        T GetById(int id);
        ICollection<T> GetAll();
    }
}
