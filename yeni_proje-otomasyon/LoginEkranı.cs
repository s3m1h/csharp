using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace yeni_proje_otomasyon
{
    public partial class Login : Form
    {
        SQLiteConnection con = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
        SQLiteDataAdapter da;
        SQLiteCommand cmd;
        DataSet ds;
        

        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            
            //string user = textBox1.Text;
            //string pass = textBox2.Text;

            SQLiteDataReader dr;
            con.Open();
            using (cmd = new SQLiteCommand("select * from Kgiris Where Kadi=@kadi and Sifre=@sifre", con))
            {
                cmd.Parameters.AddWithValue("@kadi", textBox1.Text);
                cmd.Parameters.AddWithValue("@sifre", textBox2.Text);
                using (dr = cmd.ExecuteReader()) {

                    if (dr.Read())
                    {

                        MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız.");
                        Form1 sayfa = new Form1();
                        sayfa.Show();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
                    }
                    con.Close();
                }
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UyeKaydi form = new UyeKaydi();
            form.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifreDegistir form = new SifreDegistir();
            form.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (!File.Exists("MyDatabase.sqlite"))
            {
                //SQLiteConnection.CreateFile("Veritabani.sqlite");

                string sql = @"
                                CREATE TABLE Urunler(
                               ID INTEGER PRIMARY KEY AUTOINCREMENT ,
                               Adi        TEXT      NOT NULL,
                               Kodu       TEXT    NOT NULL,
                               Fiyati       TEXT    NOT NULL,                                         
                               Adedi          TEXT     NOT NULL
                            );
                                CREATE TABLE Kgiris(
                               ID INTEGER PRIMARY KEY AUTOINCREMENT ,
                               Adi        TEXT      NOT NULL,
                               Soyadi       TEXT    NOT NULL,
                               KAdi       TEXT    NOT NULL,                                         
                               Rol          TEXT     NOT NULL,
                               Sifre           INT      NOT NULL
                            
                            );
                            ";
                con = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                con.Open();
                cmd = new SQLiteCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
