using ArabaKiralama.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaKiralamaWinUI
{
    public class GirisForm
    {
        #region Instances
        ArabaContext ac = new ArabaContext();
        MusteriForm mf = new MusteriForm();
        AdminForm af = new AdminForm();
        Form1 f1;
        #endregion
        public bool GirisMus(string username, string sifre)
        {

            var q = from mus in ac.Musteriler
                    where mus.Username == username && mus.Password == sifre
                    select mus;
            if (q.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GirisAdm(string username, string sifre)
        {

            var q = from adm in ac.Adminler
                    where adm.Username == username && adm.Password == sifre
                    select adm;
            if (q.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
