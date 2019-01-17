using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArabaKiralamaWinUI
{
    public static class Helper
    {
        public static void Temizle(Control.ControlCollection koleksiyon, GroupBox a)
        {
            foreach (Control c in koleksiyon)
            {
                if(c is GroupBox)
                {
                    foreach (Control item in a.Controls)
                    {
                        if (item is TextBox)
                        {
                            TextBox txt = (TextBox)item;
                            txt.Clear();
                        }
                        else if (item is DateTimePicker)
                        {
                            DateTimePicker dt = (DateTimePicker)item;
                            dt.Value = DateTime.Now;
                        }                        
                        else if (item is RichTextBox)
                        {
                            RichTextBox rc = (RichTextBox)item;
                            rc.Clear();
                        }
                        else if (item is ComboBox)
                        {
                            ComboBox cmb = (ComboBox)item;
                            cmb.SelectedIndex = 0;
                        }
                    }
                }               
            }
        }

        public static void AdminTemizle(Control.ControlCollection koleksiyon)
        {
            foreach (Control c in koleksiyon)
            {
                if (c is TextBox)
                {
                    TextBox txt = (TextBox)c;
                    txt.Clear();
                }
            }
        }

        public static void ArabaTemizle(Control.ControlCollection koleksiyon)
        {
            foreach (Control item in koleksiyon)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    txt.Clear();
                }
                else if (item is DateTimePicker)
                {
                    DateTimePicker dt = (DateTimePicker)item;
                    dt.Value = DateTime.Now;
                }
                else if (item is RichTextBox)
                {
                    RichTextBox rc = (RichTextBox)item;
                    rc.Clear();
                }
                else if (item is ComboBox)
                {
                    ComboBox cmb = (ComboBox)item;
                    cmb.SelectedIndex = 0;
                }
            }
        }
    }
}
