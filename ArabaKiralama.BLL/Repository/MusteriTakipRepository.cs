using ArabaKiralama.DAL;
using ArabaKiralama.DAL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaKiralama.BLL.Repository
{
    public class MusteriTakipRepository
    {
        ArabaContext _ac;
        public MusteriTakipRepository()
        {
            _ac = new ArabaContext();
        }
        public void Ekle(MusteriTakip item)
        {
            _ac.MusteriTakipler.Add(item);
            _ac.SaveChanges();
        }
        public ICollection<MusteriTakip> GetAll()
        {
            return _ac.MusteriTakipler.ToList();
        }
        public MusteriTakip GetById(int id)
        {
            return _ac.MusteriTakipler.Where(x => x.MusteriTakipID == id).FirstOrDefault();
        }
        public void Guncelle(MusteriTakip item)
        {
            MusteriTakip updated = _ac.MusteriTakipler.Find(item.MusteriTakipID);
            _ac.Entry(updated).CurrentValues.SetValues(item);
            _ac.SaveChanges();
        }
        public void Sil(int itemId)
        {
            _ac.MusteriTakipler.Remove(_ac.MusteriTakipler.Find(itemId));
            _ac.SaveChanges();
        }
    }
}
