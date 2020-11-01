using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace yeni_proje_otomasyon
{
    public partial class UyeKaydi : Form
    {
        SQLiteConnection con = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
        SQLiteDataAdapter da;
        SQLiteCommand cmd;
        DataSet ds;
        public UyeKaydi()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SQLiteCommand("insert into Kgiris(Adi,Soyadi,Kadi,Rol,Sifre) Values(@adi,@soyadi,@kadi,@rol,@sifre)", con);
            cmd.Parameters.AddWithValue("@adi", textBox1.Text);
            cmd.Parameters.AddWithValue("@soyadi", textBox2.Text);
            cmd.Parameters.AddWithValue("@rol", comboBox1.Text);
            cmd.Parameters.AddWithValue("@kadi", textBox4.Text);
            cmd.Parameters.AddWithValue("@sifre", Convert.ToInt32(textBox3.Text));
            // cmd.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.ToString("dd-MM-yyyy"));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Başarılı.");
            this.Close();
        }

        private void UyeKaydi_Load(object sender, EventArgs e)
        {
        //    if (!File.Exists("MyDatabase.sqlite"))
        //    {
        //        SQLiteConnection.CreateFile("MyDatabase.sqlite");

        //        string sql = @"CREATE TABLE Kgiris(
        //                       ID INTEGER PRIMARY KEY AUTOINCREMENT ,
        //                       Adi        TEXT      NOT NULL,
        //                       Soyadi       TEXT    NOT NULL,
        //                       KAdi       TEXT    NOT NULL,                                         
        //                       Rol          TEXT     NOT NULL,
        //                       Sifre           INT      NOT NULL
                            
        //                    );
        //                    ";
        //        con = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
        //        con.Open();
        //        cmd = new SQLiteCommand(sql, con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        }
    }
}
