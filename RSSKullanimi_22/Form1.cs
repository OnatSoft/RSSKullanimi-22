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
        //https://www.cumhuriyet.com.tr/rss
        //http://www.hurriyet.com.tr/rss/gundem

        string Title = "";
        string Url = "";

        private void haberLink(string url)
        {
            try
            {
                XmlTextReader xmloku = new XmlTextReader(url);
                dataGridView1.ColumnCount = 1;
                dataGridView1.Columns[0].Name = "Başlık";

                while (xmloku.Read())
                {

                    if (xmloku.LocalName == "title")
                    {
                        xmloku.Read();
                        Title = xmloku.Value;
                    }

                    dataGridView1.Rows.Add(Title);
                    break;
                }
                xmloku.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Haberi yükleme işleminde bir hata oldu.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void haberGetir(string link)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(link);
                listBox2.Items.Clear();
                while (reader.Read())
                {
                    if (reader.LocalName == "title")
                    {
                        listBox2.Items.Add(reader.ReadString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Haber yüklenirken bir hata oldu.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_MynetHaber_Click(object sender, EventArgs e)
        {
            string url;
            url = textBox1.Text;
            haberLink(url);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string link;
            link = textBox1.Text;
            haberGetir(link);
        }
    }
}
