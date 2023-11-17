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

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            string UserName=Uname.Text;
            string PassWord=Pword.Text;

            try
            {
                

                {
                    UserName = Uname.Text;
                    PassWord=Pword.Text;

                    Form2 frm = new Form2();
                    frm.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Uname.Text = " ";
            Pword.Text = "";
        }
    }
}
