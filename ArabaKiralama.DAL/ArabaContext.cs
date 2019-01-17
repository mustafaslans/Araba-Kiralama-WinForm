using ArabaKiralama.DAL.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaKiralama.DAL
{
    public class ArabaContext : DbContext
    {
        public DbSet<Araba> Arabalar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Model> Modeller { get; set; }
        public DbSet<Admin> Adminler { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
    }
}
