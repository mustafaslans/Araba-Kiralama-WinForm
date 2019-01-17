using ArabaKiralama.BLL.Repository;
using ArabaKiralama.DAL;
using ArabaKiralama.DAL.Classes;
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
        Musteri guncellenecekmusteri;       
        Musteri m;
        #endregion
        public void MusteriDataDoldur()
        {
         
            var result = from mus in ac.Musteriler
                         where label21.Text == mus.Username
                         select mus;
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
            
            sidepanel.Top = buttonmusteriprofil.Top;
            sidepanel.Left = panel1.Left;
            grparabasec.Hide();
            grpodeme.Hide();
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
            if (m.MusteriMail.Contains(txtgncemail.Text))
            {
                MessageBox.Show("E-mail adresi mevcut");
                return;
            }
            DateTime bTarih = Convert.ToDateTime(DateTime.Now.Year);
            DateTime kTarih = Convert.ToDateTime(dategncdogum.Value.Year);
            TimeSpan Sonuc = bTarih - kTarih;
            if (Convert.ToInt32(Sonuc) < 18)
            {
                MessageBox.Show("Yaşınız uygun değil");
                return;
            }
            if (string.IsNullOrEmpty(richtxtgncadres.Text))
            {
                MessageBox.Show("E-mailinizi giriniz");
                return;
            }
            #endregion
            #region Musteri Guncelle
            if (txtgncsifre.Text == txtgncsifreonay.Text)
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
            }
            else
            {
                MessageBox.Show("Şifreler uyuşmuyor");
            } 
            #endregion
            Helper.Temizle(this.Controls, grpprofil);
            MusteriDataDoldur();
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
                int a = Convert.ToInt32(label19.Text) * Convert.ToInt32(datagridarabasec.SelectedRows[0].Cells[8].Value);
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

        }
    }
}
