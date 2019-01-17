using ArabaKiralama.DAL;
using ArabaKiralama.DAL.Classes;
using ArabaKiralama.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaKiralama.BLL.Repository
{
    public class ArabaRepository : IAraba
    {
        ArabaContext _ac;
        public ArabaRepository()
        {
            _ac = new ArabaContext();
        }
        public void Ekle(Araba item)
        {
            _ac.Arabalar.Add(item);
            _ac.SaveChanges();
        }
        public ICollection<Araba> GetAll()
        {
            return _ac.Arabalar.ToList();
        }
        public Araba GetById(int id)
        {
            return _ac.Arabalar.Where(x => x.ArabaID == id).FirstOrDefault();
        }
        public void Guncelle(Araba item)
        {
            Araba updated = _ac.Arabalar.Find(item.ArabaID);
            _ac.Entry(updated).CurrentValues.SetValues(item);
            _ac.SaveChanges();
        }
        public void Sil(int itemId)
        {
            _ac.Arabalar.Remove(_ac.Arabalar.Find(itemId));
            _ac.SaveChanges();
        }
    }
}
