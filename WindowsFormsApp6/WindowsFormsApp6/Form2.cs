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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gayanii\Documents\SupperMarket.mdf;Integrated Security=True;Connect Timeout=30");

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void populate()
        {
            try
            {
                Con.Open();
                String MyQuery = "select * from UserTable1";
                SqlDataAdapter da = new SqlDataAdapter(MyQuery,Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                UserGV.DataSource = ds.Tables[0];
                Con.Close();
                

            }
            catch
            {

            }
        }

        

        private void tb4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into UserTable1 values ('" + tb1.Text + "','" + tb2.Text + "','" + tb3.Text + "','" + tb4.Text + "' )", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Added");
                Con.Close();
                populate();
            }
            catch
            { 
                MessageBox.Show("Error");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tb1.Text = UserGV.SelectedRows[0].Cells[0].Value.ToString();
            tb2.Text = UserGV.SelectedRows[0].Cells[1].Value.ToString();
            tb3.Text = UserGV.SelectedRows[0].Cells[2].Value.ToString();
            tb4.Text = UserGV.SelectedRows[0].Cells[3].Value.ToString();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
                  populate() ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(tb4.Text == " ")
            {
                MessageBox.Show("Enter The User Phone Number");
            }
            else
            {
                Con.Open();
                String Myquery = "delete from UserTable1 where PhoneNo =  '" + tb4.Text +"'";
                SqlCommand cmd = new SqlCommand(Myquery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Deleted");
                Con.Close();
                populate();
            }
        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE UserTable1 set UserName ='"+tb1.Text+"', FullName = '"+tb2.Text+"' , PassWord = '"+tb3.Text+"' where PhoneNo ='"+tb4.Text+"'",Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Updated");
                Con.Close();
                populate();
            }
            catch
            {
                MessageBox.Show("Error");
            }

        }
    }
}
