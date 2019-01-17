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
    public class MarkaRepository : IMarka
    {
        ArabaContext _ac;
        public MarkaRepository()
        {
            _ac = new ArabaContext();
        }
        public void Ekle(Marka item)
        {
            _ac.Markalar.Add(item);
            _ac.SaveChanges();
        }
        public ICollection<Marka> GetAll()
        {
            return _ac.Markalar.ToList();
        }
        public Marka GetById(int id)
        {
            return _ac.Markalar.Where(x => x.MarkaID == id).FirstOrDefault();
        }
        public void Guncelle(Marka item)
        {
            Marka updated = _ac.Markalar.Find(item.MarkaID);
            _ac.Entry(updated).CurrentValues.SetValues(item);
            _ac.SaveChanges();
        }
        public void Sil(int itemId)
        {
            _ac.Markalar.Remove(_ac.Markalar.Find(itemId));
            _ac.SaveChanges();
        }
    }
}
