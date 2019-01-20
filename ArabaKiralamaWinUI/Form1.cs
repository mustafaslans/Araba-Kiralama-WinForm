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
    public partial class Form1 : Form
    {
        #region Instances
        MusteriRepository mr = new MusteriRepository();
        AdminRepository ar = new AdminRepository();
        ArabaContext ac = new ArabaContext();
        AdminForm af = new AdminForm();
        GirisForm gf = new GirisForm();
        Musteri m;
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grpkayit.Visible = false;
            cmbcinsiyet.DisplayMember = "Description";
            cmbcinsiyet.ValueMember = "Value";
            cmbcinsiyet.DataSource = Enum.GetValues(typeof(CinsiyetEnum));
            this.ActiveControl = txtgirisuser;            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            grpgiris.Visible = false;
            grpkayit.Visible = true;
            this.ActiveControl = txtkytuser;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grpgiris.Visible = true;
            grpkayit.Visible = false;
            this.ActiveControl = txtgirisuser;
        }
        public void User()
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonyenikayit_Click(object sender, EventArgs e)
        {
            #region Kayıt Kontrol
            if (string.IsNullOrEmpty(txtkytuser.Text))
            {
                MessageBox.Show("Kullanıcı adı giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtkytsifre.Text))
            {
                MessageBox.Show("Şifre giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtkytsifreonay.Text))
            {
                MessageBox.Show("Şifre onay giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtkytad.Text))
            {
                MessageBox.Show("Adınızı giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtkytsoyad.Text))
            {
                MessageBox.Show("Soyadınızı giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtkyttcno.Text))
            {
                MessageBox.Show("Tc no giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtkyttelefon.Text))
            {
                MessageBox.Show("Telefon numaranızı giriniz");
                return;
            }
            if (string.IsNullOrEmpty(txtkytemail.Text))
            {
                MessageBox.Show("E-mailinizi giriniz");
                return;
            }                      
            if (string.IsNullOrEmpty(richtxtkytadres.Text))
            {
                MessageBox.Show("E-mailinizi giriniz");
                return;
            }
            #endregion
            #region Musteri Kayıt
            if (txtkytsifre.Text == txtkytsifreonay.Text)
            {
                mr.Ekle(new Musteri
                {
                    Username = txtkytuser.Text,
                    Password = txtkytsifre.Text,
                    MusteriAd = txtkytad.Text,
                    MusteriSoyad = txtkytsoyad.Text,
                    MusteriTcno = txtkyttcno.Text,
                    MusteriTelefon = txtkyttelefon.Text,
                    MusteriCinsiyet = cmbcinsiyet.Text,
                    MusteriDogumtarihi = datekytdogum.Value,
                    MusteriEhliyetalis = datekytehliyet.Value,
                    MusteriAdres = richtxtkytadres.Text
                });
                Helper.Temizle(this.Controls, grpkayit);
                MessageBox.Show("Kayıt başarılı");
            }
            else
            {
                MessageBox.Show("Şifreler uyuşmuyor");
            }
                
            #endregion        
        }
       
        private void buttongiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtgirisuser.Text))
            {
                MessageBox.Show("Kullanıcı adı giriniz..");
                return;
            }
            else if (string.IsNullOrEmpty(txtgirissifre.Text))
            {
                MessageBox.Show("Şifre giriniz..");
                return;
            }
            else
            {
                var q = from mus in ac.Musteriler
                        where mus.Username == txtgirisuser.Text && mus.Password == txtgirissifre.Text
                        select new
                        {
                            mus.Username
                        }.Username;

                if (q.FirstOrDefault() != null)
                {

                    string muss = q.FirstOrDefault();
                    if (muss == (txtgirisuser.Text))
                    {  
                        gf.GirisMus(txtgirisuser.Text, txtgirissifre.Text);
                        MusteriForm mf = new MusteriForm();
                        mf.txtgncuser.Text = txtgirisuser.Text;
                        mf.label21.Text = txtgirisuser.Text;
                        mf.Show();
                        this.Hide();
                    }                   
                }              
            }

            if (string.IsNullOrEmpty(txtgirisuser.Text))
            {
                MessageBox.Show("Kullanıcı adı giriniz..");
                return;
            }
            else if (string.IsNullOrEmpty(txtgirissifre.Text))
            {
                MessageBox.Show("Şifre giriniz..");
                return;
            }
            else
            {
                var q1 = from adm in ac.Adminler
                        where adm.Username == txtgirisuser.Text && adm.Password == txtgirissifre.Text
                        select new
                        {
                            adm.Username
                        }.Username;

                if (q1.FirstOrDefault() != null)
                {

                    string admm = q1.FirstOrDefault();
                    if (admm == (txtgirisuser.Text))
                    {
                        gf.GirisAdm(txtgirisuser.Text, txtgirissifre.Text);
                        AdminForm af = new AdminForm();
                        af.Show();
                        this.Hide();
                    }                   
                }
            }            
        }
    }
}
