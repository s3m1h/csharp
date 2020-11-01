using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.SQLite;
namespace yeni_proje_otomasyon
{
    public partial class Form1 : Form
    {
        SQLiteConnection con = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
        SQLiteDataAdapter da;
        SQLiteCommand cmd;
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataPanel.Controls.Clear();
            Market myForm = new Market();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            dataPanel.Controls.Add(myForm);
            myForm.Show();
            //this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            dataPanel.Controls.Clear();
            Market myForm = new Market();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            dataPanel.Controls.Add(myForm);
            myForm.Show();


        }

        private void Urunler_Click(object sender, EventArgs e)
        {
            dataPanel.Controls.Clear();
            Satıs myForm = new Satıs();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            dataPanel.Controls.Add(myForm);
            myForm.Show();
            //this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
