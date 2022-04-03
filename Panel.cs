using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balthazard
{
    internal class Panel
    {
        #region Değişkenler

        Tablo tablo = new Tablo();

        List<float> nihaiList = new List<float>();
        List<float> oranList = new List<float>();

        string[] dogumTarihiTutucu, kazaTarihiTutucu;
        string[] oranTutucu, kazaOraniTutucu;

        string metin, tablos, koken;
        bool senilite;
        int yas;
        float transver;

        #endregion

        #region Hesaplayıcılar

        public string UstExPanel(string girdi)
        {
            if (girdi.Length > 3)
                metin = ("Şahsın toplam üst ekstremite engel oranının balthazard formülüne göre ");
            else
                metin = ("Şahsın toplam üst ekstremite engel oranının ");

            tablos = string.Empty;
            koken = ("ustEx");

            return OranHesaplayici(girdi, metin, tablos, koken);
        }

        public string AltExPanel(string girdi)
        {
            if (girdi.Length > 3)
                metin = ("Şahsın toplam alt ekstremite engel oranının balthazard formülüne göre ");
            else
                metin = ("Şahsın toplam alt ekstremite engel oranının ");

            tablos = string.Empty;
            koken = ("altEx");

            return OranHesaplayici(girdi, metin, tablos, koken);
        }

        public string DigerPanel(string girdi)
        {
            if (girdi.Length > 3)
                metin = ("Şahsın engel oranının balthazard formülüne göre ");
            else
                metin = ("Şahsın engel oranının ");

            tablos = string.Empty;
            koken = ("diger");

            return OranHesaplayici(girdi, metin, tablos, koken);
        }

        public string OranHesaplayici(string girdi, string metin, string tablos, string koken)
        {
            StringBuilder stbil = new StringBuilder();

            float lokalOran, genelOran;

            int iletici;

            try
            {
                lokalOran = 0;
                genelOran = 0;
                oranTutucu = new string[girdi.Length];
                oranTutucu = girdi.Split('+');

                stbil.Append(metin);

                foreach (string item in oranTutucu)
                {
                    iletici = Convert.ToInt32(item);
                    if (iletici < 1 || iletici > 99)
                    {
                        System.Windows.Forms.MessageBox.Show("1'den küçük veya 99'dan büyük bir oran olamaz!");
                        break;
                    }
                    else
                        oranList.Add(iletici);
                }
                oranList.Sort();
                oranList.Reverse();

                for (int i = 0; i < oranList.Count; i++)
                {
                    if (i == oranList.Count - 1)
                    {
                        if (oranList.Count == 1)
                            continue;
                        else
                            stbil.Append("%" + oranList[i].ToString() + " = ");
                    }
                    else
                        stbil.Append("%" + oranList[i].ToString() + " + ");
                }
                if (oranList.Count > 1)
                {
                    if (koken.Equals("diger"))
                        foreach (float oran in oranList)
                            genelOran = tablo.Balthazard(oran);
                    else
                    {
                        foreach (float oran in oranList)
                            lokalOran = tablo.Balthazard(oran);

                        if (koken.Equals("ustEx"))
                            genelOran = tablo.Tablo2_3Ust(lokalOran);
                        if (koken.Equals("altEx"))
                            genelOran = tablo.Tablo3_2Alt(lokalOran);

                    }
                }
                else
                {
                    if (koken.Equals("diger"))
                        genelOran = oranList[0];
                    else
                    {
                        lokalOran = oranList[0];
                        if (koken.Equals("ustEx"))
                            genelOran = tablo.Tablo2_3Ust(oranList[0]);
                        if (koken.Equals("altEx"))
                            genelOran = tablo.Tablo3_2Alt(oranList[0]);
                    }
                }
                nihaiList.Add(genelOran);

                Array.Clear(oranTutucu, 0, oranTutucu.Length);
                oranList.Clear();
                tablo.balthazardList.Clear();

                if (!koken.Equals("diger"))
                {
                    stbil.Append("%" + lokalOran.ToString() + " olduğu, Tablo-3.2'den tüm engel oranının ");
                }
                stbil.Append("%" + genelOran.ToString() + " olduğu kanaatine varılmıştır.");

                return stbil.ToString();
            }
            catch (Exception)
            {

                System.Windows.Forms.MessageBox.Show("Lütfen fazlalığı silin!");
            }

            return string.Empty;
        }

        public string Tarihler(string kazaOrani, string kazaTarihi, string dogumTarihi)
        {
            StringBuilder stbil = new StringBuilder();

            DateTime sonucYil = new DateTime();
            DateTime dogum, kaza;
            TimeSpan yillar;

            int dogumGun = 0;
            int dogumAy = 0;
            int dogumYil = 0;
            int kazaGun = 0;
            int kazaAy = 0;
            int kazaYil = 0;

            int artikSayac = 0;
            int oranCevirici = 0;
            int iletici;

            try
            {
                if (dogumTarihi.Equals(string.Empty))
                    System.Windows.Forms.MessageBox.Show("Doğum tarihi olmadan işlem yapılamaz!");

                dogumTarihiTutucu = new string[3];
                dogumTarihiTutucu = dogumTarihi.Split('.', ',', '-', '_', '/');
                dogumGun = Convert.ToInt32(dogumTarihiTutucu[0]);
                dogumAy = Convert.ToInt32(dogumTarihiTutucu[1]);
                dogumYil = Convert.ToInt32(dogumTarihiTutucu[2]);

                if (dogumYil < 100 && dogumYil > 20)
                    dogumYil += 1900;
                else if (dogumYil < 21)
                    dogumYil += 2000;
                if (dogumGun < 1 || dogumGun > 31)
                    System.Windows.Forms.MessageBox.Show("Günü en fazla 31 olarak girebilirsiniz!");

                if (dogumAy == 2)
                {
                    if (dogumYil % 4 == 0)
                    {
                        if (dogumGun > 29)
                            System.Windows.Forms.MessageBox.Show("Günü en fazla 29 olarak girebilirsiniz!");
                    }
                    else
                    {
                        if (dogumGun > 28)
                            System.Windows.Forms.MessageBox.Show("Günü en fazla 28 olarak girebilirsiniz!");
                    }
                }
                else if (dogumAy == 4 || dogumAy == 6 || dogumAy == 9 || dogumAy == 11)
                {
                    if (dogumGun > 30)
                        System.Windows.Forms.MessageBox.Show("Günü en fazla 30 olarak girebilirsiniz!");
                }
                if (dogumAy < 1 || dogumAy > 12)
                    System.Windows.Forms.MessageBox.Show("Ayı en fazla 12 olarak girebilirsiniz!");

                dogum = new DateTime(dogumYil, dogumAy, dogumGun);
                if (dogum > DateTime.Now)
                    System.Windows.Forms.MessageBox.Show("Gelecek zamanlı bir doğum tarihi girilemez!");

                kazaTarihiTutucu = new string[3];
                kazaTarihiTutucu = kazaTarihi.Split('.', ',', '-', '_', '/');
                kazaGun = Convert.ToInt32(kazaTarihiTutucu[0]);
                kazaAy = Convert.ToInt32(kazaTarihiTutucu[1]);
                kazaYil = Convert.ToInt32(kazaTarihiTutucu[2]);

                if (kazaYil < 100 && kazaYil > 20)
                    kazaYil += 1900;
                else if (kazaYil < 21)
                    kazaYil += 2000;


                if (kazaGun < 1 || kazaGun > 31)
                    System.Windows.Forms.MessageBox.Show("Günü en fazla 31 olarak girebilirsiniz!");
                if (kazaAy == 2)
                {
                    if (kazaYil % 4 == 0)
                    {
                        if (kazaGun > 29)
                            System.Windows.Forms.MessageBox.Show("Günü en fazla 29 olarak girebilirsiniz!");
                    }
                    else
                    {
                        if (kazaGun > 28)
                            System.Windows.Forms.MessageBox.Show("Günü en fazla 28 olarak girebilirsiniz!");
                    }
                }
                else if (kazaAy == 4 || kazaAy == 6 || kazaAy == 9 || kazaAy == 11)
                {
                    if (kazaGun > 30)
                        System.Windows.Forms.MessageBox.Show("Günü en fazla 30 olarak girebilirsiniz!");
                }
                if (kazaAy < 1 || kazaAy > 12)
                    System.Windows.Forms.MessageBox.Show("Ayı en fazla 12 olarak girebilirsiniz!");
                kaza = new DateTime(kazaYil, kazaAy, kazaGun);

                if (kaza < dogum)
                    System.Windows.Forms.MessageBox.Show("Kaza tarihi doğum tarihinden küçük olamaz!");
                if (kaza > DateTime.Now)
                {
                    System.Windows.Forms.MessageBox.Show("Gelecek zamanlı bir kaza tarihi girilemez!");
                    kazaTarihi = string.Empty;
                }

                yillar = kaza - dogum;
                for (int i = dogumYil; i < kazaYil; i++)
                {
                    if (i % 4 == 0)
                        artikSayac++;
                }

                sonucYil.AddDays(artikSayac);
                yas = (sonucYil + yillar).Year - 1;
                if (!kazaOrani.Equals(string.Empty))
                {
                    kazaOraniTutucu = new string[kazaOrani.Length];
                    kazaOraniTutucu = kazaOrani.Split('+');

                    foreach (string item in kazaOraniTutucu)
                    {
                        iletici = Convert.ToInt32(item);
                        if (iletici < 1 || iletici > 100)
                        {
                            System.Windows.Forms.MessageBox.Show("Oran 0 ve 100 arasında olmalıdır!");
                            break;
                        }
                        else
                            oranList.Add(iletici);
                    }

                    if (oranList.Count > 1)
                    {
                        foreach (float oran in oranList)
                            oranCevirici = Convert.ToInt32(tablo.Balthazard(oran));
                    }
                    else
                        oranCevirici = Convert.ToInt32(kazaOrani);

                    if (oranCevirici > 0)
                    {
                        float cikti = tablo.E_Cetveli(oranCevirici, yas);
                        stbil.Append("E Cetvelin'de " + yas.ToString() + " yaşa göre meslekte kazanma gücü kayıp oranı %" + cikti.ToString());
                        if (cikti % 1 != 0)
                            cikti *= 10;
                        cikti %= 10;

                        switch (cikti)
                        {
                            case 40:
                                stbil.Append("'tır.");
                                break;

                            case 3:
                            case 100:
                                stbil.Append("'dür.");
                                break;

                            case 9:
                            case 10:
                            case 30:
                                stbil.Append("'dur.");
                                break;

                            case 6:
                            case 60:
                            case 90:
                                stbil.Append("'dır.");
                                break;

                            default:
                                stbil.Append("'dir.");
                                break;
                        }
                    }
                    Array.Clear(kazaOraniTutucu, 0, kazaOraniTutucu.Length);
                    oranList.Clear();
                    tablo.balthazardList.Clear();
                }

                else
                    stbil.Append(yas.ToString());
                if (kaza > DateTime.Now)
                    stbil.Clear();
                if (yas > 64)
                    senilite = true;
                else
                    senilite = false;
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Lütfen girdileri düzenleyip yeniden deneyin!");
            }

            return stbil.ToString();
        }

        #endregion

        #region Senilite

        public void SeniliteFormGirdi(bool seniliteVeri)
        {
            if (seniliteVeri)
                senilite = true;
            else
                senilite = false;
        }

        public bool SeniliteFormCikti()
        {
            return senilite;
        }

        public bool SenilitePanel()
        {
            if (senilite)
                nihaiList.Add(10);

            return senilite;
        }

        #endregion

        #region Nihayetçiler


        public string NihaiOran()
        {
            StringBuilder stbil = new StringBuilder();
            float nihaiOran = 0;
            transver = 0;

            SenilitePanel();

            if (nihaiList.Count > 1)
            {
                stbil.Append("Şahsın toplam engel oranının balthazard formülüne göre toplandığında ");
                if (senilite)
                {
                    stbil.Append("ve 65 yaş üzeri olduğundan senilite payı ile ");
                }
                nihaiList.Sort();
                nihaiList.Reverse();
                for (int i = 0; i < nihaiList.Count; i++)
                {
                    if (i == nihaiList.Count - 1)
                    {
                        if (nihaiList.Count == 1)
                        {
                            continue;
                        }
                        else
                        {
                            stbil.Append("%" + nihaiList[i].ToString() + " = ");
                        }
                    }
                    else
                    {
                        stbil.Append(nihaiList[i].ToString() + " + ");
                    }
                }
                foreach (float oran in nihaiList)
                {
                    nihaiOran = tablo.Balthazard(oran);
                }
                senilite = false;
                transver = nihaiOran;

                tablo.balthazardList.Clear();
                nihaiList.Clear();
                stbil.Append("%" + nihaiOran.ToString() + " olduğu kanaatine varılmıştır.");
            }
            else
            {
                transver = nihaiList[0];

                stbil.Clear();
                nihaiList.Clear();
            }

            return stbil.ToString();
        }

        public string NihaiyetTranformatoru()
        {
            if (transver == 0)
                return string.Empty;
            else
                return transver.ToString();
        }

        #endregion
    }
}
