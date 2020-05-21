using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;

namespace CoronaCanliTakipSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //global tanımladık
        XElement root;
        private void Form1_Load(object sender, EventArgs e)
        {
            //internetten veriyi aldık
            XDocument doc = XDocument.Load("https://opendata.ecdc.europa.eu/covid19/casedistribution/xml");
            root = doc.Root;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //türkiye için verileri al
            if (checkBox1.Checked==true)
            {
                //anlık olarak bilgi almak için kullanılan kod
                List<XElement> xusabugun = root.Elements()
                .Where(s => s.Element("geoId").Value == "TR" && 
                DateTime.Parse(s.Element("dateRep").Value).Date == DateTime.Now.Date)
                .ToList();
                XDocument newDocTR = XDocument.Parse("<root></root>");
                XElement newRootTR = newDocTR.Root;
                newRootTR.Add(xusabugun);
                newRootTR.Save("Turkiye.xml");
                MessageBox.Show("Türkiye verileri kaydedildi!", "BAŞARILI!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (radioButton1.Checked == true)
            {
                //tr değerini çektik
                var trDegerler = root.Elements().Where(s => s.Element("geoId").Value == "TR");
                //tr zamanları tersten sıralıyor
                var sirali = trDegerler.OrderByDescending(s => DateTime.Parse(s.Element("dateRep").Value));
                //son 5 zamanı alıyor
                var son5 = sirali.Take(5);
                //son 5 olanı chart tablosuna ekliyoruz
                foreach (var item in son5)
                {
                    chart1.Series["Hasta"].Points
                        .AddXY(item.Element("dateRep").Value, int.Parse(item.Element("cases").Value));

                    chart1.Series["Ölüm"].Points
                       .AddXY(item.Element("dateRep").Value, int.Parse(item.Element("deaths").Value));
                }
            }
            else if (radioButton2.Checked==true)
            {
                MessageBox.Show("Türkiye verileri grafik ile gösterilmeyecek!","GRAFİK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Türkiye verileri kaydedilemedi!", "HATA!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //amerika için verileri al
            if (checkBox2.Checked==true)
            {
                //anlık olarak bilgi almak için kullanılan kod
                List<XElement> xusabugun = root.Elements()
                .Where(s => s.Element("geoId").Value == "US" && 
                DateTime.Parse(s.Element("dateRep").Value).Date == DateTime.Now.Date)
                .ToList();
                XDocument newDocUsa = XDocument.Parse("<root></root>");
                XElement newRootUsa = newDocUsa.Root;
                newRootUsa.Add(xusabugun);
                newRootUsa.Save("ABD.xml");
                MessageBox.Show("ABD verileri kaydedildi!", "BAŞARILI!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (radioButton3.Checked==true)
            {
                //ABD değerini çektik
                var trDegerler = root.Elements().Where(s => s.Element("geoId").Value == "US");
                //ABD zamanları tersten sıralıyor
                var sirali = trDegerler.OrderByDescending(s => DateTime.Parse(s.Element("dateRep").Value));
                //son 5 zamanı alıyor
                var son5 = sirali.Take(5);
                //son 5 olanı chart tablosuna ekliyoruz
                foreach (var item in son5)
                {
                    chart1.Series["Hasta"].Points
                        .AddXY(item.Element("dateRep").Value, int.Parse(item.Element("cases").Value));

                    chart1.Series["Ölüm"].Points
                       .AddXY(item.Element("dateRep").Value, int.Parse(item.Element("deaths").Value));
                }
            }
            else if (radioButton4.Checked==true)
            {
                MessageBox.Show("ABD verileri grafik ile gösterilmeyecek!", "GRAFİK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ABD verileri kaydedilemedi!", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //italya için verileri al
            if (checkBox3.Checked==true)
            {
                //anlık olarak bilgi almak için kullanılan kod
                List<XElement> xusabugun = root.Elements()
               .Where(s => s.Element("geoId").Value == "IT" &&
               DateTime.Parse(s.Element("dateRep").Value).Date == DateTime.Now.Date)
               .ToList();
                XDocument newDocIT = XDocument.Parse("<root></root>");
                XElement newRootIT = newDocIT.Root;
                newRootIT.Add(xusabugun);
                newRootIT.Save("Italya.xml");
                MessageBox.Show("İtalya verileri kaydedildi!", "BAŞARILI!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (radioButton5.Checked==true)
            {
                var trDegerler = root.Elements().Where(s => s.Element("geoId").Value == "IT");
                //IT zamanları tersten sıralıyor
                var sirali = trDegerler.OrderByDescending(s => DateTime.Parse(s.Element("dateRep").Value));
                //son 5 zamanı alıyor
                var son5 = sirali.Take(5);
                //son 5 olanı chart tablosuna ekliyoruz
                foreach (var item in son5)
                {
                    chart1.Series["Hasta"].Points
                        .AddXY(item.Element("dateRep").Value, int.Parse(item.Element("cases").Value));

                    chart1.Series["Ölüm"].Points
                       .AddXY(item.Element("dateRep").Value, int.Parse(item.Element("deaths").Value));
                }
            }
            else if (radioButton6.Checked==true)
            {
                MessageBox.Show("İtalya verileri grafik ile gösterilmeyecek!", "GRAFİK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("İtalya verileri kaydedilemedi!", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //İspanya için verileri al
            if (checkBox3.Checked == true)
            {
                //anlık olarak bilgi almak için kullanılan kod
                List<XElement> xusabugun = root.Elements()
               .Where(s => s.Element("geoId").Value == "ES" &&
               DateTime.Parse(s.Element("dateRep").Value).Date == DateTime.Now.Date)
               .ToList();
                XDocument newDocES = XDocument.Parse("<root></root>");
                XElement newRootES = newDocES.Root;
                newRootES.Add(xusabugun);
                newRootES.Save("Ispanya.xml");
                MessageBox.Show("İspanya verileri kaydedildi!", "BAŞARILI!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (radioButton7.Checked==true)
            {
                var trDegerler = root.Elements().Where(s => s.Element("geoId").Value == "ES");
                //ES zamanları tersten sıralıyor
                var sirali = trDegerler.OrderByDescending(s => DateTime.Parse(s.Element("dateRep").Value));
                //son 5 zamanı alıyor
                var son5 = sirali.Take(5);
                //son 5 olanı chart tablosuna ekliyoruz
                foreach (var item in son5)
                {
                    chart1.Series["Hasta"].Points
                        .AddXY(item.Element("dateRep").Value, int.Parse(item.Element("cases").Value));

                    chart1.Series["Ölüm"].Points
                       .AddXY(item.Element("dateRep").Value, int.Parse(item.Element("deaths").Value));
                }
            }
            else if (radioButton8.Checked==true)
            {
                MessageBox.Show("İspanya verileri grafik ile gösterilmeyecek!", "GRAFİK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("İspanya verileri Kaydedilemedi!", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
