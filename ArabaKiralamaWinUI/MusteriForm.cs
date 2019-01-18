using ArabaKiralama.BLL.Repository;
using ArabaKiralama.DAL;
using ArabaKiralama.DAL.Classes;
using ArabaKiralamaWinUI.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArabaKiralamaWinUI
{
    public partial class MusteriForm : Form
    {
        #region Instances
        MusteriRepository mr = new MusteriRepository();
        ArabaContext ac = new ArabaContext();
        MusteriTakipRepository mtr = new MusteriTakipRepository();
        Musteri guncellenecekmusteri;       
        Musteri m;
        #endregion
        public void MusteriDataDoldur()
        {
          
            dataGridmusteriprofil.Update();
            dataGridmusteriprofil.RefreshEdit();
            var result = ac.Musteriler.Where(x => x.Username == label21.Text);
            dataGridmusteriprofil.DataSource = null;
            dataGridmusteriprofil.DataSource = result.ToList();

            var re = from a in ac.Markalar
                     where a.MarkaAdi == label21.Text
                     select a.ArabaId;
            
        }
        public void MusteriGuncelDoldur()
        {
            var result = ac.Musteriler.Where(x => x.Username == label21.Text);
            dataGridmusteriprofil.DataSource = result.ToList();

        }
        public MusteriForm()
        {
            InitializeComponent();
            datesonkullan.Format = DateTimePickerFormat.Custom;
            datesonkullan.CustomFormat = "MM/yyyy";
        }

        private void MusteriForm_Load(object sender, EventArgs e)
        {
            var result = from arb in ac.Arabalar
                         join mar in ac.Markalar on arb.ArabaID equals mar.ArabaId
                         join mod in ac.Modeller on mar.MarkaID equals mod.MarkaId
                         select new
                         {
                             arb.ArabaID,
                             mar.MarkaAdi,
                             mod.ModelAdi,
                             arb.UretimYili,
                             arb.Yakit,
                             arb.Vites,
                             arb.Klima,
                             arb.ArabaKm,
                             arb.MotorHacmi,
                             arb.Fiyat
                         };
            datagridarabasec.DataSource = result.ToList();
            sidepanel.Top = buttonmusteriprofil.Top;
            sidepanel.Left = panel1.Left;
            grparabasec.Hide();
            grpodeme.Hide();
            cmbcinsiyet.DisplayMember = "Description";
            cmbcinsiyet.ValueMember = "Value";
            cmbcinsiyet.DataSource = Enum.GetValues(typeof(CinsiyetEnum));
            if (ac.Musteriler == null)
            {
                return;
            }
            else
            {
                MusteriDataDoldur();
            }
            
        }
        private void buttonmustericikis_Click(object sender, EventArgs e)
        {
            sidepanel.Top = buttonmustericikis.Top;
            sidepanel.Left = panel1.Left;
            this.Close();
        }

        private void buttonmusteriarabalar_Click(object sender, EventArgs e)
        {
            sidepanel.Top = buttonmusteriarabalar.Top;
            sidepanel.Left = panel1.Left;
            grpprofil.Hide();
            grparabasec.Show();
            grpodeme.Hide();
        }

        private void buttonmusteriodeme_Click(object sender, EventArgs e)
        {
            sidepanel.Top = buttonmusteriodeme.Top;
            sidepanel.Left = panel1.Left;
            grpprofil.Hide();
            grparabasec.Hide();
            grpodeme.Show();
        }

        private void buttonmusteriprofil_Click(object sender, EventArgs e)
        {
            sidepanel.Top = buttonmusteriprofil.Top;
            sidepanel.Left = panel1.Left;
            grparabasec.Hide();
            grpprofil.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonyenikayit_Click(object sender, EventArgs e)
        {
            #region Kayıt Kontrol
            if (string.IsNullOrEmpty(txtgncuser.Text))
            {
                MessageBox.Show("Kullanıcı adı giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtgncsifre.Text))
            {
                MessageBox.Show("Şifre giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtgncsifreonay.Text))
            {
                MessageBox.Show("Şifre onay giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtgncad.Text))
            {
                MessageBox.Show("Adınızı giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtgncsoyad.Text))
            {
                MessageBox.Show("Soyadınızı giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtgnctcno.Text))
            {
                MessageBox.Show("Tc no giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtgnctelefon.Text))
            {
                MessageBox.Show("Telefon numaranızı giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtgncemail.Text))
            {
                MessageBox.Show("E-mailinizi giriniz");
                return;
            }           
            //DateTime bTarih = Convert.ToDateTime(DateTime.Now.Year);
            //DateTime kTarih = Convert.ToDateTime(dategncdogum.Value.Year);
            //TimeSpan Sonuc = bTarih - kTarih;
            //if (Convert.ToInt32(Sonuc) < 18)
            //{
            //    MessageBox.Show("Yaşınız uygun değil");
            //    return;
            //}
            if (string.IsNullOrEmpty(richtxtgncadres.Text))
            {
                MessageBox.Show("E-mailinizi giriniz");
                return;
            }
            #endregion           
            #region Musteri Guncelle
            if (txtgncsifre.Text == txtgncsifreonay.Text)
            {
                guncellenecekmusteri.Username = txtgncuser.Text;
                guncellenecekmusteri.Password = txtgncsifre.Text;
                guncellenecekmusteri.MusteriAd = txtgncad.Text;
                guncellenecekmusteri.MusteriSoyad = txtgncsoyad.Text;
                guncellenecekmusteri.MusteriTcno = txtgnctcno.Text;
                guncellenecekmusteri.MusteriTelefon = txtgnctelefon.Text;
                guncellenecekmusteri.MusteriCinsiyet = cmbcinsiyet.Text;
                guncellenecekmusteri.MusteriDogumtarihi = dategncdogum.Value;
                guncellenecekmusteri.MusteriEhliyetalis = dategncehliyet.Value;
                guncellenecekmusteri.MusteriAdres = richtxtgncadres.Text;
                mr.Guncelle(guncellenecekmusteri);
  
            }
            else
            {
                MessageBox.Show("Şifreler uyuşmuyor");
            }
            #endregion          
            Helper.Temizle(this.Controls, grpprofil);
           
            dataGridmusteriprofil.Refresh();
            MusteriGuncelDoldur();

        }

        private void buttonmusteriprofilsil_Click(object sender, EventArgs e)
        {
            if (dataGridmusteriprofil.SelectedRows.Count > 0)
            {
                mr.Sil(Convert.ToInt32(dataGridmusteriprofil.SelectedRows[0].Cells[0].Value));
            }
            MusteriDataDoldur();
            Helper.Temizle(this.Controls, grpprofil);
        }

        private void dataGridmusteriprofil_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridmusteriprofil.SelectedRows.Count > 0)
            {
                guncellenecekmusteri = mr.GetById(Convert.ToInt32(dataGridmusteriprofil.SelectedRows[0].Cells[0].Value));
                txtgncsifre.Text = guncellenecekmusteri.Password;
                txtgncad.Text = guncellenecekmusteri.MusteriAd;
                txtgncsoyad.Text = guncellenecekmusteri.MusteriSoyad;
                txtgnctcno.Text = guncellenecekmusteri.MusteriTcno;
                txtgnctelefon.Text = guncellenecekmusteri.MusteriTelefon;
                cmbcinsiyet.Text = guncellenecekmusteri.MusteriCinsiyet;
                txtgncemail.Text = guncellenecekmusteri.MusteriMail;
                dategncdogum.Value = guncellenecekmusteri.MusteriDogumtarihi;
                dategncehliyet.Value = guncellenecekmusteri.MusteriEhliyetalis;
                richtxtgncadres.Text = guncellenecekmusteri.MusteriAdres;
            }
        }

        private void bttnhesapla_Click(object sender, EventArgs e)
        {
            if (datagridarabasec.SelectedRows.Count > 0)
            {
                DateTime bTarih = Convert.ToDateTime(dateTimePicker2.Text);
                DateTime kTarih = Convert.ToDateTime(dateTimePicker1.Text);
                TimeSpan Sonuc = bTarih - kTarih;
                label19.Text = Sonuc.TotalDays.ToString();
                int a = Convert.ToInt32(label19.Text) * Convert.ToInt32(datagridarabasec.SelectedRows[0].Cells[6].Value);
                label20.Text = a.ToString();
            }
            else
            {
                MessageBox.Show("Lütfen önce seçim yapınız");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //Police p = new Police();
            //if (checkBox1.Checked)
            //    p.Show();
            //else
            //    p.Hide();
        }

        private void bttnode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtkartadi.Text))
            {
                MessageBox.Show("İsim Soyisim giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtkartno.Text))
            {
                MessageBox.Show("Kart no giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtcvc.Text))
            {
                MessageBox.Show("Cvc kodunu giriniz");
                return;
            }
            guncellenecekmusteri.MusteriKartadı = txtkartadi.Text;
            guncellenecekmusteri.MusteriKartno = txtkartno.Text;
            guncellenecekmusteri.MusteriKartsonkullanmatarihi = datesonkullan.Value;
            guncellenecekmusteri.MusteriKartCvc = txtcvc.Text;
            mr.Guncelle(guncellenecekmusteri);

            mtr.Ekle(new MusteriTakip
            {
                MusteriId = Convert.ToInt32(dataGridmusteriprofil.CurrentRow.Cells[0].Value),
                MusteriAdi = dataGridmusteriprofil.CurrentRow.Cells[3].Value.ToString(),
                MusteriSoyadi = dataGridmusteriprofil.CurrentRow.Cells[4].Value.ToString(),
                MusteriTelefon = dataGridmusteriprofil.CurrentRow.Cells[7].Value.ToString(),
                ArabaID = Convert.ToInt32(datagridarabasec.CurrentRow.Cells[0].Value),
                ArabaMarka = datagridarabasec.CurrentRow.Cells[1].Value.ToString(),
                ArabaModel = datagridarabasec.CurrentRow.Cells[2].Value.ToString(),
            });


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
