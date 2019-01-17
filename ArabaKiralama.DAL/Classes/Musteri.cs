using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaKiralama.DAL.Classes
{
    public class Musteri
    {
        public int MusteriID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string MusteriAd { get; set; }
        public string MusteriSoyad { get; set; }
        public DateTime MusteriDogumtarihi { get; set; }
        public string MusteriTcno { get; set; }
        public string MusteriTelefon { get; set; }
        public string MusteriCinsiyet { get; set; }
        public DateTime MusteriEhliyetalis { get; set; }
        public string MusteriMail { get; set; }
        public string MusteriAdres { get; set; }
        public string MusteriKartadı { get; set; }
        public string MusteriKartno { get; set; }
        public DateTime MusteriKartsonkullanmatarihi { get; set; }
        public string MusteriKartCvc { get; set; }



    }
}
