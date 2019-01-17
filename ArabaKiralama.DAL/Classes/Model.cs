using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaKiralama.DAL.Classes
{
    public class Model
    {
        public int ModelID { get; set; }
        public string ModelAdi { get; set; }
        public int MarkaId { get; set; }
        public int ArabaId { get; set; }
        public Marka ModelMarka { get; set; }
    }
}
