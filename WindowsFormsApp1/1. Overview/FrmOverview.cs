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

namespace WindowsFormsApp1._1._Overview
{
    public partial class FrmOverview : Form
    {
        public FrmOverview()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Step 1: SqlConnection
            //Step 2: SqlCommand
            //Step 3: SqlDataReader
            //Step 4: UI Control
 
            try
            {
               SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
                conn.Open();

                SqlCommand command = new SqlCommand("select * from Products", conn);

                // new SqlDataReader();
                SqlDataReader dataReader =  command.ExecuteReader();

                this.listBox1.Items.Clear();

                while( dataReader.Read())
                {
                    this.listBox1.Items.Add(dataReader["ProductName"]);
                }
               
                //MessageBox.Show(dataReader["ProductName"].ToString());

                //..........
                conn.Close();

                MessageBox.Show("successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
    }
}
