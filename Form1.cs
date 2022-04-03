using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balthazard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Değişkenler

        Panel panel = new Panel();

        string ciktiUstExBox, veriUstExBox, ciktiAltExBox, veriAltExBox, ciktiDigerBox, veriDigerBox;
        string veriKazaTarihi, ciktiTarihler;
        string veriKazaOrani = string.Empty;
        string veriDogumTarihi = string.Empty;

        bool seniliteVeri = false;
        bool sekmeButonu = false;
        bool ilklik = true;

        DateTime anlikTarih;

        #endregion


        #region Hesaplamalar Ve Metotlara Geçiş

        private void tabanFrm_Load(object sender, EventArgs e)
        {
            secim1.Checked = false;
            secim2.Checked = false;
            secim3.Checked = false;
            metinKutusu1.Select();
        }

        private void ustexBox_TextChanged(object sender, EventArgs e)
        {
            metinKutusu1.Select();
        }

        private void altexBox_TextChanged(object sender, EventArgs e)
        {
            metinKutusu2.Select();
        }

        private void digerBox_TextChanged(object sender, EventArgs e)
        {
            metinKutusu3.Select();
        }

        private void ustexBox_Click(object sender, EventArgs e)
        {
            metinKutusu1.Select();
        }

        private void altexBox_Click(object sender, EventArgs e)
        {
            metinKutusu2.Select();
        }

        private void digerBox_Click(object sender, EventArgs e)
        {
            metinKutusu3.Select();
        }

        private void ustExBtn_Click(object sender, EventArgs e)
        {
            metinKutusu1.Select();
        }

        private void altExBtn_Click(object sender, EventArgs e)
        {
            metinKutusu2.Select();
        }

        private void digerBtn_Click(object sender, EventArgs e)
        {
            metinKutusu3.Select();
        }

        private void ustexBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Motor();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void altexBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Motor();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{TAB}");
            }
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void digerBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Motor();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{TAB}");
            }
        }

        private void silBtn_Click(object sender, EventArgs e)
        {
            metinKutusu1.Text = string.Empty;
            metinKutusu2.Text = string.Empty;
            metinKutusu3.Text = string.Empty;
            sonucBox.Text = string.Empty;
            nihaiBox.Text = string.Empty;
            secim1.Checked = false;
            secim2.Checked = false;
            secim3.Checked = false;
            seniliteBtn.Checked = false;

            ilklik = true;

            if (!sekmeButonu)
            {
                veriUstExBox = string.Empty;
                veriAltExBox = string.Empty;
                veriDigerBox = string.Empty;
            }
            else
            {
                veriKazaOrani = string.Empty;
                veriKazaTarihi = string.Empty;
                veriDogumTarihi = string.Empty;
            }
        }

        private void sekmeBtn_Click(object sender, EventArgs e)
        {
            if (sekmeButonu)
            {
                seniliteBtn.Enabled = true;
                metinKutusu1.Text = string.Empty;
                metinKutusu2.Text = string.Empty;
                metinKutusu3.Text = string.Empty;
                sonucBox.Text = string.Empty;
                nihaiBox.Text = string.Empty;

                sekmeButonu = false;

                metinKutusu1.Text = veriUstExBox;
                metinKutusu2.Text = veriAltExBox;
                metinKutusu3.Text = veriDigerBox;

                sekmeBtn.Text = "Extremite v.b.";
                secim1.Text = "Üst Ekstremite";
                secim2.Text = "Alt Ekstremite";
                secim3.Text = "Diğer";

                if (!metinKutusu1.Text.Equals(string.Empty) || !metinKutusu2.Text.Equals(string.Empty) || !metinKutusu3.Text.Equals(string.Empty))
                {
                    Motor();
                }
            }
            else
            {
                seniliteBtn.Enabled = false;
                metinKutusu1.Text = string.Empty;
                metinKutusu2.Text = string.Empty;
                metinKutusu3.Text = string.Empty;
                sonucBox.Text = string.Empty;
                nihaiBox.Text = string.Empty;

                sekmeButonu = true;

                metinKutusu1.Text = veriKazaOrani;
                metinKutusu2.Text = veriKazaTarihi;
                metinKutusu3.Text = veriDogumTarihi;

                sekmeBtn.Text = "Cetvel - E";
                secim1.Text = "Engel Oranı";
                secim2.Text = "Kaza Tarihi";
                secim3.Text = "Doğum Tarihi";

                if (!metinKutusu1.Text.Equals(string.Empty) || !metinKutusu2.Text.Equals(string.Empty) || !metinKutusu3.Text.Equals(string.Empty))
                {
                    Motor();
                }
            }
        }

        private void hesaplaBtn_Click(object sender, EventArgs e)
        {
            Motor();
        }

        private void seniliteBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (!sekmeButonu)
            {
                if (seniliteVeri && !seniliteBtn.Checked && !veriDogumTarihi.Equals(string.Empty))
                {
                    seniliteVeri = false;
                    seniliteBtn.Checked = false;
                    veriDogumTarihi = string.Empty;
                    MessageBox.Show("Şahıs senilite sınırının üstündedir!");
                }
                if (!seniliteVeri && seniliteBtn.Checked && !veriDogumTarihi.Equals(string.Empty))
                {
                    seniliteVeri = true;
                    seniliteBtn.Checked = true;
                    veriDogumTarihi = string.Empty;
                    MessageBox.Show("Şahıs senilite için yeterince yaşlı değil!");
                }
            }
        }

        public void Motor()
        {
            sonucBox.Text = string.Empty;
            nihaiBox.Text = string.Empty;

            if (!sekmeButonu)
            {
                veriUstExBox = string.Empty;
                veriAltExBox = string.Empty;
                veriDigerBox = string.Empty;

                if (!metinKutusu1.Text.Equals(string.Empty))
                {
                    veriUstExBox = metinKutusu1.Text.ToString();
                    ciktiUstExBox = panel.UstExPanel(veriUstExBox);
                }
                if (!metinKutusu2.Text.Equals(string.Empty))
                {
                    veriAltExBox = metinKutusu2.Text.ToString();
                    ciktiAltExBox = panel.AltExPanel(veriAltExBox);
                }
                if (!metinKutusu3.Text.Equals(string.Empty))
                {
                    veriDigerBox = metinKutusu3.Text.ToString();
                    ciktiDigerBox = panel.DigerPanel(veriDigerBox);
                }

                if (!veriKazaOrani.Equals(panel.NihaiyetTranformatoru()))
                    veriKazaOrani = string.Empty;

                if (seniliteBtn.Checked)
                    seniliteVeri = true;
                else
                    seniliteVeri = false;

                ilklik = false;
                panel.SeniliteFormGirdi(seniliteVeri);
            }
            else
            {
                veriKazaOrani = string.Empty;
                veriKazaTarihi = string.Empty;
                veriDogumTarihi = string.Empty;

                if (metinKutusu1.Text.Equals(string.Empty))
                {
                    if (panel.NihaiyetTranformatoru().Equals(string.Empty))
                        metinKutusu1.Text = string.Empty;
                    else
                        metinKutusu1.Text = panel.NihaiyetTranformatoru();
                }
                else
                {
                    if (!metinKutusu1.Text.Equals(panel.NihaiyetTranformatoru()))
                    {
                        veriUstExBox = string.Empty;
                        veriAltExBox = string.Empty;
                        veriDigerBox = string.Empty;
                    }
                }
                veriKazaOrani = metinKutusu1.Text;

                if (!metinKutusu3.Text.Equals(string.Empty))
                {
                    veriDogumTarihi = metinKutusu3.Text.ToString();

                    if (metinKutusu2.Text.Equals(string.Empty))
                    {
                        anlikTarih = DateTime.Now;
                        veriKazaTarihi = anlikTarih.ToShortDateString();
                        metinKutusu2.Text = veriKazaTarihi;

                        nihaiBox.Text = ("(Kaza tarihi olarak bilgisayarın anlık tarihi kullanılmıştır.)");
                    }
                    else
                    {
                        veriKazaTarihi = metinKutusu2.Text.ToString();
                    }
                }
                else
                {
                    veriKazaTarihi = string.Empty;
                    veriDogumTarihi = string.Empty;
                    metinKutusu2.Text = string.Empty;
                }

                ciktiTarihler = panel.Tarihler(veriKazaOrani, veriKazaTarihi, veriDogumTarihi);
                veriKazaOrani = string.Empty;

                seniliteVeri = panel.SeniliteFormCikti();
                if (seniliteVeri)
                {
                    if (!seniliteBtn.Checked)
                    {
                        seniliteVeri = true;

                        if (!ilklik)
                            MessageBox.Show("Şahıs senilite sınırının üstündedir!");
                    }
                    seniliteBtn.Checked = true;
                }
                else
                {
                    if (seniliteBtn.Checked)
                    {
                        seniliteVeri = false;

                        if (!ilklik)
                            MessageBox.Show("Şahıs senilite için yeterince yaşlı değil!");
                    }
                    seniliteBtn.Checked = false;
                }
            }

            #endregion

            #region Uyarı Ve Çıktılar

            if (!sekmeButonu)
            {
                if (!metinKutusu1.Text.Equals(string.Empty))
                    sonucBox.Text += ciktiUstExBox;
                else if (secim1.Checked && metinKutusu1.Text.Equals(string.Empty))
                    MessageBox.Show("Lütfen bir oran girin!");

                if (!metinKutusu2.Text.Equals(string.Empty))
                {
                    if (!metinKutusu1.Text.Equals(string.Empty))
                    {
                        sonucBox.Text += Environment.NewLine;
                        sonucBox.Text += Environment.NewLine;
                    }
                    sonucBox.Text += ciktiAltExBox;
                }
                else if (secim2.Checked && metinKutusu2.Text.Equals(string.Empty))
                    MessageBox.Show("Lütfen bir oran girin!");

                if (!metinKutusu3.Text.Equals(string.Empty))
                {
                    if (!metinKutusu1.Text.Equals(string.Empty) || !metinKutusu2.Text.Equals(string.Empty))
                    {
                        sonucBox.Text += Environment.NewLine;
                        sonucBox.Text += Environment.NewLine;
                    }
                    sonucBox.Text += ciktiDigerBox;
                }
                else if (secim3.Checked && metinKutusu3.Text.Equals(string.Empty))
                    MessageBox.Show("Lütfen bir oran girin!");
                nihaiBox.Text = panel.NihaiOran();
            }
            else
            {
                if (!metinKutusu3.Text.Equals(string.Empty))
                    sonucBox.Text += ciktiTarihler;
            }
            #endregion
        }
    }
}
#region Yama Notları
/*
 * Versiyon 1.0.0 (30.03.2021)
 * 3 tablo kullnarak genel oran hesaplaması yapan program yaratıldı
 
 * Versiyon 1.1 (30.03.2021)
 * Form boyu 600 yapıldı
 * sonucBox'tan tek metin zorunluluğu kaldırılıp 3 metne de aynı anda yazım izni verildi
 * Bunu yapmak yerine nihaniBox'ta ki sayısal oranları isimleriyle vermek için Insert methodu ve terimList listesi kullanıldıysa da müşterinin isteği doğrultusunda vaz geçildi( tek metne dönmek istenirse sonucBox yazdıran if şartlarına && ...Btn.Chacked şartı koyularak geri getirelebilir.
 
 * Versiyon 1.2 (07.07.2021)
 * 2 Textbox eklenerek doğum ve kaza tarihi arasındaki yıl farkından yaş hesaplama özelliği getirildi.
 * İcon değiştirildi.
 
 * Versiyon 2.0 (13.07.2021)
 * Eklenen iki textbox kaldırıldı ve E Cetvelini kullanabilmek için 2. sekme oluştuşturuldu.
 * Mevcut textboxların ismi "metinkutusu" şeklinde değiştirilerek 2 sekmede de veri çekilebilmesi sağlandı.
 * Senilite metodu sayısı "SeniliteFormGirdi", "SeniliteFormCikti" ve "SenilitePanel" olacak şekilde 3'e çıkarıldı ve sınıflar arası perfornmans sağlandı
 * Alt, Üst Ekstremite ve Diğer Oran'ının hesaplamaları "OranHesaplayici" isminde tek bir metotda bağlandı. 
 */
#endregion