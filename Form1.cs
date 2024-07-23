using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace stajornek16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-FOREST;Initial Catalog=MyDatabase;Integrated Security=True");

        private void verigoster()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from ornekfirma", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["adsoyad"].ToString();
                ekle.SubItems.Add(oku["firma"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verigoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Insert into ornekfirma (adsoyad,firma,telefon) Values ('" + txtad.Text.ToString() + "', '" + txtfirma.Text.ToString() + "','"+txttelefon.Text.ToString()+"')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verigoster();
        }
    }
}
