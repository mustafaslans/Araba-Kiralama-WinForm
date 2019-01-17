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
    public class ModelRepository : IModel
    {
        ArabaContext _ac;
        public ModelRepository()
        {
            _ac = new ArabaContext();
        }
        public void Ekle(Model item)
        {
            _ac.Modeller.Add(item);
            _ac.SaveChanges();
        }
        public ICollection<Model> GetAll()
        {
            return _ac.Modeller.ToList();
        }
        public Model GetById(int id)
        {
            return _ac.Modeller.Where(x => x.ModelID == id).FirstOrDefault();
        }
        public void Guncelle(Model item)
        {
            Model updated = _ac.Modeller.Find(item.ModelID);
            _ac.Entry(updated).CurrentValues.SetValues(item);
            _ac.SaveChanges();
        }
        public void Sil(int itemId)
        {
            _ac.Modeller.Remove(_ac.Modeller.Find(itemId));
            _ac.SaveChanges();
        }
    }
}
