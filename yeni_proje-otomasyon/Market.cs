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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace yeni_proje_otomasyon
{
    public partial class Market : Form
    {
        SQLiteConnection con = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
        SQLiteDataAdapter da;
        SQLiteCommand cmd;
        DataSet ds;
        public Market()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
         
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        void GetList()
        {
            da = new SQLiteDataAdapter("Select * From Urunler", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Urunler");
            dataGridView1.DataSource = ds.Tables["Urunler"];
            con.Close();
             
        }
        private void ExecuteQuery(string txtquery)
        {
            //con = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = txtquery;
            cmd.ExecuteNonQuery();
            con.Close();

        }


        private void Market_Load(object sender, EventArgs e)
        {
            //if (!File.Exists("MyDatabase.sqlite"))
            //{
            //    SQLiteConnection.CreateFile("MyDatabase.sqlite");

            //    string sql = @"
            //                    CREATE TABLE Urunler(
            //                   ID INTEGER PRIMARY KEY AUTOINCREMENT ,
            //                   Adi        TEXT      NOT NULL,
            //                   Kodu       TEXT    NOT NULL,
            //                   Fiyati       TEXT    NOT NULL,                                         
            //                   Adedi          TEXT     NOT NULL
            //                );
            //                ";
            //    con = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            //    con.Open();
            //    cmd = new SQLiteCommand(sql, con);
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //}
            GetList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SQLiteCommand("insert into Urunler(Adi,Kodu,Fiyati,Adedi) Values(@adi,@kodu,@fiyati,@adedi)", con);
            cmd.Parameters.AddWithValue("@kodu", textBox1.Text);
            cmd.Parameters.AddWithValue("@adi", textBox2.Text);
            cmd.Parameters.AddWithValue("@fiyati", textBox3.Text);
            cmd.Parameters.AddWithValue("@adedi", numericUpDown1.Text);
            //cmd.Parameters.AddWithValue("@sifre", Convert.ToInt32(textBox3.Text));
            //cmd.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.ToString("dd-MM-yyyy"));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Başarılı.");
            GetList();
        }
        
        private void button1_Click_2(object sender, EventArgs e)
        {
            int sutun = 1;
            int satir = 1;
            Excel.Application ExcelApp = new Excel.Application();
            ExcelApp.Workbooks.Add();
            ExcelApp.Visible = true; 
            ExcelApp.Worksheets[1].Activate();

            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {
                ExcelApp.Cells[satir, sutun + j].Value = dataGridView1.Columns[j].HeaderText;
                //ExcelApp.Cells[satir, sutun + j].Font.Color = System.Drawing.Color.Blue;
                //ExcelApp.Cells[satir, sutun + j].Font.Size = 12;
                //ExcelApp.Cells[satir, sutun + j].ColumnWidth = 20;
                //ExcelApp.Cells[satir, sutun + j].Font.Bold = true;
                //ExcelApp.Cells[satir, sutun + j].Font.Name = "Arial Black";
            }
            satir++;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    ExcelApp.Cells[satir + i, sutun + j].Value = dataGridView1[j, i].Value;
                }

            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label10.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            numericUpDown1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SQLiteCommand("update Urunler set Adi=@adi,Kodu=@kodu,Fiyati=@fiyat,Adedi=@adet  where ID=@id", con);
            //UPDATE Customers SET ContactName = 'Alfred Schmidt', City = 'Frankfurt' WHERE CustomerID = 1;
            cmd.Parameters.AddWithValue("@id", label10.Text);
            cmd.Parameters.AddWithValue("@adi", textBox2.Text);
            cmd.Parameters.AddWithValue("@kodu", textBox1.Text);
            cmd.Parameters.AddWithValue("@fiyat", textBox2.Text);  
            cmd.Parameters.AddWithValue("@adet", textBox2.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GetList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SQLiteCommand("delete from Urunler where ID=@id", con);
            //UPDATE Customers SET ContactName = 'Alfred Schmidt', City = 'Frankfurt' WHERE CustomerID = 1;
            cmd.Parameters.AddWithValue("@id", label10.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GetList();
        }
    }

   
}
