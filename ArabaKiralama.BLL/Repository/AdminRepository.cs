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
    public class AdminRepository : IAdmin
    {
        ArabaContext _ac;
        public AdminRepository()
        {
            _ac = new ArabaContext();
        }
        public void Ekle(Admin item)
        {
            _ac.Adminler.Add(item);
            _ac.SaveChanges();
        }
        public ICollection<Admin> GetAll()
        {
            return _ac.Adminler.ToList();
        }
        public Admin GetById(int id)
        {
            return _ac.Adminler.Where(x => x.AdminID == id).FirstOrDefault();
        }
        public void Guncelle(Admin item)
        {
            Admin updated = _ac.Adminler.Find(item.AdminID);
            _ac.Entry(updated).CurrentValues.SetValues(item);
            _ac.SaveChanges();
        }
        public void Sil(int itemId)
        {
            _ac.Adminler.Remove(_ac.Adminler.Find(itemId));
            _ac.SaveChanges();
        }
    }
}
