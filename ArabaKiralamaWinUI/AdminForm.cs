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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArabaKiralamaWinUI
{
    public partial class AdminForm : Form
    {
        #region Panelden Hareket
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion
        #region Instances
        ArabaContext ac = new ArabaContext();
        AdminRepository adr = new AdminRepository();       
        ArabaRepository ar = new ArabaRepository();
        MarkaRepository mrk = new MarkaRepository();
        ModelRepository mr = new ModelRepository();
        MusteriTakipRepository mtr = new MusteriTakipRepository();
        Araba guncellenecekaraba;
        Marka guncellenecekmarka;
        Model guncellenecekmodel;
        #endregion
        #region Metotlar
        public void MusteriTakip()
        {
            var result = from mst in ac.MusteriTakipler
                         select new
                         {
                             mst.MusteriTakipID,
                             mst.MusteriId,
                             mst.MusteriAdi,
                             mst.MusteriSoyadi,
                             mst.MusteriTelefon,
                             mst.ArabaID,
                             mst.ArabaMarka,
                             mst.ArabaModel
                         };
            dataGridmusteritakip.DataSource = result.ToList();
        }
        public void DataGridArabaDoldur()
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
            dataGridaraba.DataSource = result.ToList();
        }
        public void DataGridMusteriDoldur()
        {
            dataGridmusteritakip.DataSource = ac.Musteriler.ToList();
        }

        public void ArabaEkleGuncelleKontrol()
        {
            if (string.IsNullOrEmpty(txtmarka.Text))
            {
                MessageBox.Show("Marka giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txturetim.Text))
            {
                MessageBox.Show("Üretim yılı giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtmodel.Text))
            {
                MessageBox.Show("Model giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtkm.Text))
            {
                MessageBox.Show("Km giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtmotorhacmi.Text))
            {
                MessageBox.Show("Motor hacmi  giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtfiyat.Text))
            {
                MessageBox.Show("Fiyat giriniz");
                return;
            }
        }
        #endregion

        public AdminForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }               
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            #region AdminFormLoad
            sidepanel.Top = buttonadminekle.Top;
            sidepanel.Left = panel1.Left;
            grparabaekle.Hide();
            grpmusteritakip.Hide();
            #endregion
            #region GrpAdminLoad
            datagridadmin.DataSource = ac.Adminler.ToList(); 
            #endregion
            #region GrpArabaLoad
            cmbyakit.DisplayMember = "Description";
            cmbyakit.ValueMember = "Value";
            cmbyakit.DataSource = Enum.GetValues(typeof(YakıtTuruEnum));
            cmbvites.DisplayMember = "Description";
            cmbvites.ValueMember = "Value";
            cmbvites.DataSource = Enum.GetValues(typeof(VitesEnum));
            DataGridArabaDoldur();
            #endregion
            MusteriTakip();
            this.ActiveControl = txtkytadminuser;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sidepanel.Top = button2.Top;
            sidepanel.Left = panel1.Left;
        }

        private void buttonadminekle_Click(object sender, EventArgs e)
        {
            sidepanel.Top = buttonadminekle.Top;
            sidepanel.Left = panel1.Left;
            grpadminekle.Show();
            grparabaekle.Hide();
            grpmusteritakip.Hide();
            this.ActiveControl = txtkytadminuser;
        }

        private void buttonarabalar_Click(object sender, EventArgs e)
        {
            sidepanel.Top = buttonarabalar.Top;
            sidepanel.Left = panel1.Left;
            grpadminekle.Hide();
            grparabaekle.Show();
            grpmusteritakip.Hide();
            this.ActiveControl = txtmarka;

        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sidepanel.Top = button4.Top;
            sidepanel.Left = panel1.Left;
            grpadminekle.Hide();
            grparabaekle.Hide();
            grpmusteritakip.Show();

        }

        private void buttonadmincikis_Click(object sender, EventArgs e)
        {
            sidepanel.Top = buttonadmincikis.Top;
            sidepanel.Left = panel1.Left;
            DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }           
        }

        private void buttonyenikayit_Click(object sender, EventArgs e)
        {
            #region Admin Ekle
            if (string.IsNullOrEmpty(txtkytadminuser.Text))
            {
                MessageBox.Show("Kullanıcı adı giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtkytadminsifre.Text))
            {
                MessageBox.Show("Şifre giriniz");
                return;
            }

            if (txtkytadminsifre.Text == txtkytadminsifreonay.Text)
            {
                adr.Ekle(new Admin
                {
                    Username = txtkytadminuser.Text,
                    Password = txtkytadminsifre.Text
                });
            }
            else
            {
                MessageBox.Show("Şifreler uyuşmuyor");
            }
            #endregion
            datagridadmin.DataSource = ac.Adminler.ToList();
            Helper.Temizle(this.Controls, grpadminekle);
        }

        private void buttonadminsil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Sil", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (datagridadmin.SelectedRows.Count > 0)
                {
                    adr.Sil(Convert.ToInt32(datagridadmin.SelectedRows[0].Cells[0].Value));
                }
                datagridadmin.DataSource = ac.Adminler.ToList();
                Helper.Temizle(this.Controls, grparabaekle);
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            
        }

        private void buttonarabaekle_Click(object sender, EventArgs e)
        {
            #region Araba Ekle
            ar.Ekle(new Araba
            {
                UretimYili = txturetim.Text,
                Yakit = cmbyakit.Text,
                Vites = cmbvites.Text,
                Klima = cmbklima.Text,
                ArabaKm = txtkm.Text,
                MotorHacmi = txtmotorhacmi.Text,
                Fiyat = int.Parse(txtfiyat.Text),               
            });
            int id = ac.Arabalar.OrderByDescending(p => p.ArabaID).FirstOrDefault().ArabaID;
            mrk.Ekle(new Marka
            {
                ArabaId = id,
                MarkaAdi = txtmarka.Text
            });
            int markId = ac.Markalar.OrderByDescending(p => p.MarkaID).FirstOrDefault().MarkaID;
            mr.Ekle(new Model
            {
                MarkaId = markId,
                ModelAdi = txtmodel.Text               
            });
            #endregion
            ArabaEkleGuncelleKontrol();
            Helper.Temizle(this.Controls, grparabaekle);
            DataGridArabaDoldur();
        }

        private void buttonarabagüncelle_Click(object sender, EventArgs e)
        {
            #region Araba Guncelle
            guncellenecekaraba.UretimYili = txturetim.Text;
            guncellenecekaraba.Yakit = cmbyakit.Text;
            guncellenecekaraba.Vites = cmbvites.Text;
            guncellenecekaraba.Klima = cmbklima.Text;
            guncellenecekaraba.ArabaKm = txtkm.Text;
            guncellenecekaraba.MotorHacmi = txtmotorhacmi.Text;
            guncellenecekaraba.Fiyat = int.Parse(txtfiyat.Text);                    
            ar.Guncelle(guncellenecekaraba);           
            #endregion
            ArabaEkleGuncelleKontrol();
            int id = ac.Arabalar.OrderByDescending(p => p.ArabaID).FirstOrDefault().ArabaID;
            var result = (from mar in ac.Markalar
                         where mar.ArabaId == guncellenecekaraba.ArabaID
                         select mar.MarkaID).FirstOrDefault();
            int res = Convert.ToInt32(result);
            guncellenecekmarka = mrk.GetById(res);
            guncellenecekmarka.ArabaId = id;
            guncellenecekmarka.MarkaAdi = txtmarka.Text;
            guncellenecekmarka.MarkaID = Convert.ToInt32(result);
            mrk.Guncelle(guncellenecekmarka);
            int marid = ac.Markalar.OrderByDescending(p => p.MarkaID).FirstOrDefault().MarkaID;
            var result1 = (from mod in ac.Modeller
                         where mod.MarkaId == guncellenecekmarka.MarkaID
                         select mod.ModelID).FirstOrDefault();
            int res2 = Convert.ToInt32(result1);
            guncellenecekmodel = mr.GetById(res2);
            guncellenecekmodel.MarkaId = marid;
            guncellenecekmodel.ModelAdi = txtmodel.Text;
            guncellenecekmodel.ModelID = Convert.ToInt32(result1);
            mr.Guncelle(guncellenecekmodel);
            Helper.Temizle(this.Controls, grparabaekle);
            DataGridArabaDoldur();
        }

        private void buttonarabasil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Sil", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGridaraba.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dataGridaraba.SelectedRows[0].Cells[0].Value);
                    var result = (from res in ac.Markalar
                                  where res.ArabaId == id
                                  select res.MarkaID).FirstOrDefault();
                    int id2 = Convert.ToInt32(result);
                    mrk.Sil(id2);
                    var result2 = (from res2 in ac.Modeller
                                   where res2.MarkaId == id2
                                   select res2.ModelID).FirstOrDefault();
                    int id3 = Convert.ToInt32(result2);
                    mr.Sil(id3);
                    ar.Sil(Convert.ToInt32(dataGridaraba.SelectedRows[0].Cells[0].Value));
                }
                DataGridArabaDoldur();
                Helper.Temizle(this.Controls, grparabaekle);
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            
        }

        private void dataGridaraba_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridaraba.SelectedRows.Count > 0)
            {
                guncellenecekaraba = ar.GetById(Convert.ToInt32(dataGridaraba.SelectedRows[0].Cells[0].Value));
                txtmarka.Text = dataGridaraba.SelectedRows[0].Cells[1].Value.ToString();
                txtmodel.Text = dataGridaraba.SelectedRows[0].Cells[2].Value.ToString();
                txturetim.Text = guncellenecekaraba.UretimYili;
                cmbyakit.SelectedValue = guncellenecekaraba.Yakit;
                cmbvites.SelectedValue = guncellenecekaraba.Vites;
                cmbklima.SelectedValue = guncellenecekaraba.Klima;
                txtkm.Text = guncellenecekaraba.ArabaKm;
                txtmotorhacmi.Text = guncellenecekaraba.MotorHacmi;
                txtfiyat.Text = guncellenecekaraba.Fiyat.ToString();
            }
        }

        private void buttonmusteritakip_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Sil", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGridmusteritakip.SelectedRows.Count > 0)
                {
                    mtr.Sil(Convert.ToInt32(dataGridmusteritakip.SelectedRows[0].Cells[0].Value));
                }
                MusteriTakip();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            
        }
    }
}
