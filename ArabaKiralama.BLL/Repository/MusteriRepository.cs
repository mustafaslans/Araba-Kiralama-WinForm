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
    public class MusteriRepository : IMusteri
    {
        ArabaContext _ac;
        public MusteriRepository()
        {
            _ac = new ArabaContext();
        }
        public void Ekle(Musteri item)
        {
            _ac.Musteriler.Add(item);
            _ac.SaveChanges();
        }
        public ICollection<Musteri> GetAll()
        {
            return _ac.Musteriler.ToList();
        }
        public Musteri GetById(int id)
        {
            return _ac.Musteriler.Where(x => x.MusteriID == id).FirstOrDefault();
        }
        public void Guncelle(Musteri item)
        {
            Musteri updated = _ac.Musteriler.Find(item.MusteriID);
            _ac.Entry(updated).CurrentValues.SetValues(item);
            _ac.SaveChanges();
        }
        public void Sil(int itemId)
        {
            _ac.Musteriler.Remove(_ac.Musteriler.Find(itemId));
            _ac.SaveChanges();
        }
    }
}
