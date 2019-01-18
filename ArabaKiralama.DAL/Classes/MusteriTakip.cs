using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaKiralama.DAL.Classes
{
    public class MusteriTakip
    {
        public int MusteriTakipID { get; set; }
        public int MusteriId { get; set; }
        public string MusteriAdi { get; set; }
        public string MusteriSoyadi { get; set; }
        public string MusteriTelefon { get; set; }
        public string ArabaMarka { get; set; }
        public string ArabaModel { get; set; }
        public int ArabaID { get; set; }
        public Musteri Muste { get; set; }
        public Araba Arab { get; set; }
    }
}
