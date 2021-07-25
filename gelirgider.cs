using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Pansiyon_uygulaması
{
    public partial class frmgelirgider : Form
    {
        public frmgelirgider()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-GK97UIA;Initial Catalog=Pansiyon;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {

            int personel;
            personel = Convert.ToInt16(textBox1.Text);
            lblpers.Text = (personel * 1500).ToString();

            int sonuc;
            sonuc = Convert.ToInt32(lblkasa.Text) - (Convert.ToInt32(lblpers.Text) + Convert.ToInt32(lblalınanurun.Text) + Convert.ToInt32(lblalınanurun1.Text) + Convert.ToInt32(lblalınanurun2.Text) + Convert.ToInt32(lblfatura.Text) + Convert.ToInt32(lblfatura1.Text) + Convert.ToInt32(lblfatura2.Text));
            lblsonuc.Text = sonuc.ToString();
        }


        private void gelirgider_Load(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select sum(Ucret) as toplam from Musteriekle", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblkasa.Text = oku["toplam"].ToString();

            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select sum(Gida) as toplam1 from Stoklar", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                lblalınanurun.Text = oku2["toplam1"].ToString();

            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select sum(Icecek) as toplam2 from Stoklar", baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                lblalınanurun1.Text = oku3["toplam2"].ToString();

            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select sum(Cerezler) as toplam3 from Stoklar", baglanti);
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                lblalınanurun2.Text = oku4["toplam3"].ToString();

            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select sum(Elektrik) as toplam4 from Faturalar", baglanti);
            SqlDataReader oku5 = komut5.ExecuteReader();
            while (oku5.Read())
            {
                lblfatura.Text = oku5["toplam4"].ToString();

            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select sum(Su) as toplam5 from Faturalar", baglanti);
            SqlDataReader oku6 = komut6.ExecuteReader();
            while (oku6.Read())
            {
                lblfatura1.Text = oku6["toplam5"].ToString();

            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("Select sum(Internet) as toplam6 from Faturalar", baglanti);
            SqlDataReader oku7 = komut7.ExecuteReader();
            while (oku7.Read())
            {
                lblfatura2.Text = oku7["toplam6"].ToString();

            }
            baglanti.Close();


            int personel;
            personel = Convert.ToInt16(textBox1.Text);
            lblpers.Text = (personel * 1500).ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
