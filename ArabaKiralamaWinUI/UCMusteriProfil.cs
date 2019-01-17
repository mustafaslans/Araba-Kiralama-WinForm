using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArabaKiralama.BLL.Repository;
using ArabaKiralama.DAL.Classes;
using ArabaKiralama.DAL;

namespace ArabaKiralamaWinUI
{
    public partial class UCMusteriProfil : UserControl
    {
        #region Instances
        MusteriRepository mr = new MusteriRepository();
        ArabaContext ac = new ArabaContext();
        Musteri m;
        Form1 f1;
        #endregion

        public void MusteriDataDoldur()
        {
            var result = from mus in ac.Musteriler
                         where f1.txtgirisuser.Text == mus.Username
                         select new
                         {
                             mus.MusteriID
                         };
            dataGridmusteriprofil.DataSource = mr.GetById(Convert.ToInt32(result));
        }
        public UCMusteriProfil()
        {
            InitializeComponent();
        }
        private void UCMusteriProfil_Load(object sender, EventArgs e)
        {
            MusteriDataDoldur();          
        }

        private void buttonyenikayit_Click(object sender, EventArgs e)
        {
            mr.Guncelle(new Musteri
            {
                Username = txtgncuser.Text,
                Password = txtgncsifre.Text,
                MusteriAd = txtgncad.Text,
                MusteriSoyad = txtgncsoyad.Text,
                MusteriTcno = txtgnctcno.Text,
                MusteriTelefon = txtgnctelefon.Text,
                MusteriCinsiyet = cmbcinsiyet.Text,
                MusteriDogumtarihi = dategncdogum.Value,
                MusteriEhliyetalis = dategncehliyet.Value,
                MusteriAdres = richtxtgncadres.Text
            });
            Helper.ArabaTemizle(this.Controls);
            MusteriDataDoldur();
        }

        private void buttonmusteriprofilsil_Click(object sender, EventArgs e)
        {
            if (dataGridmusteriprofil.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridmusteriprofil.SelectedRows[0].Cells[0].Value);
                mr.Sil(id);
            }
        }
    }
}
