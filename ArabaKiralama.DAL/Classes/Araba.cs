using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaKiralama.DAL.Classes
{
    public class Araba
    {
        public int ArabaID { get; set; }
        public Marka ArabaMarka { get; set; }
        public Model ArabaModel { get; set; }
        public string UretimYili { get; set; }
        public string ArabaKm { get; set; }
        public string MotorHacmi { get; set; }
        public int Fiyat { get; set; }
        public string Yakit { get; set; }
        public string Vites { get; set; }
        public string Klima { get; set; }
        public int? MusteriTakipId { get; set; }
    }
}
