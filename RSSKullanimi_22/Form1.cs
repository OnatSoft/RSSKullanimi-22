using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RSSKullanimi_22
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_SozcuHaber_Click(object sender, EventArgs e)
        {
            XmlTextReader xmloku = new XmlTextReader("https://www.cumhuriyet.com.tr/rss");

            while (xmloku.Read())
            {
                if (xmloku.Name == "title")
                {
                    listBox1.Items.Add(xmloku.ReadString().ToString());
                }
            }
        }

        private void btn_MynetHaber_Click(object sender, EventArgs e)
        {
            XmlTextReader xmloku2 = new XmlTextReader("https://www.mynet.com/haber/rss/sondakika");

            while (xmloku2.Read())
            {
                if (xmloku2.Name == "title")
                {
                    listBox2.Items.Add(xmloku2.ReadString());
                }
            }
        }
    }
}
