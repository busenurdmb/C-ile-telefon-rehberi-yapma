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

namespace TelefonRehber
{
    public partial class SteelBlue : Form
    {
        public SteelBlue()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-493DFJA\SQLEXPRESS;Initial Catalog=TelRehber;Integrated Security=True");
        void listele()
        {
           
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TblRehber", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void TEMİZLE()
        {
            txtıd.Text = "";
            txtad.Text = " ";
            txtsoyad.Text = "";
            msktxtbox.Text = " ";
            txtmail.Text = "";
            txtfoto.Text = " ";
            pictureBox2.ImageLocation = " ";



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'telRehberDataSet2.TblRehber' table. You can move, or remove it, as needed.
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TblRehber (AD,SOYAD,TELEFON ,MAİL,FOTOĞRAF) values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3",msktxtbox.Text);
            komut.Parameters.AddWithValue("@p4", txtmail.Text);
            komut.Parameters.AddWithValue("@p5", txtfoto.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("TELEFON EKLENDİ");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;
            txtfoto.Text = openFileDialog1.FileName;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtıd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            msktxtbox.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtmail.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtfoto.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

            pictureBox2.ImageLocation = txtfoto.Text;
            




        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult onay = new DialogResult();
            onay = MessageBox.Show("BU NUMARAYI SİLMEK İSTEDİĞİNİZDEN EMİNMİSİNİZ ?", "UYARI", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand kmt = new SqlCommand("delete from TblRehber where ID=@P1", baglanti);
                kmt.Parameters.AddWithValue("@P1", txtıd.Text);
                kmt.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("TELEFON SİLİNDİ");
            }
            if (onay == DialogResult.No)
            {
                MessageBox.Show("TELEFON SİLİNMEDİ :)");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update  TblRehber set AD=@p1 ,SOYAD=@p2,TELEFON=@p3 ,MAİL=@p4,FOTOĞRAF=@p5 where ID=@p6", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", msktxtbox.Text);
            komut.Parameters.AddWithValue("@p4", txtmail.Text);
            komut.Parameters.AddWithValue("@p5", txtfoto.Text);
            komut.Parameters.AddWithValue("@p6", txtıd.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("GÜNCELLEME İŞLEMİ GERÇEKLEŞTİ");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TEMİZLE();
        }
    }
}
