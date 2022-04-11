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

            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.SelectedIndex = 1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Step 1: SqlConnection
            //Step 2: SqlCommand
            //Step 3: SqlDataReader
            //Step 4: UI Control

            {
                int iiii=0;

                iiii = iiii + 1;
            }

            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
                conn.Open();

                SqlCommand command = new SqlCommand("select * from Products", conn);

                // new SqlDataReader();
                SqlDataReader dataReader =  command.ExecuteReader();

                this.listBox1.Items.Clear();

                while( dataReader.Read())
                {
                    // syntax sugar 語法糖 for  string.Format(..)
                    string s = $"{dataReader["ProductName"], -40} - {dataReader["UnitPrice"]:c2}"; 
                    this.listBox1.Items.Add(s);
                }
                //ex.Message  "當目前沒有資料時，嘗試讀取無效。"  
                //MessageBox.Show(dataReader["ProductName"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                    //....
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Step 1: SqlConnection
            //Step 2: SqlDataAdapter
            //Step 3: DataSet          - In memory DB
            //Step 4: UI Control       - DataGridView - Table

            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");

            SqlDataAdapter adapter = new SqlDataAdapter("select * from Products", conn);
            
            DataSet ds = new DataSet();

            //Fill() 方法 自動化 Auto Connected DB:  conn.Open() => SqlCommand.Execute("select ...") => while  DataReader.Read() =>........ conn.Close()
            adapter.Fill(ds);

            this.dataGridView1.DataSource = ds.Tables[0];
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");

            SqlDataAdapter adapter = new SqlDataAdapter("select * from categories", conn);

            DataSet ds = new DataSet();

            //Fill() 方法 自動化 Auto Connected DB:  conn.Open() => SqlCommand.Execute("select ...") => while  DataReader.Read() =>........ conn.Close()
            adapter.Fill(ds);

            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True");

            SqlDataAdapter adapter = new SqlDataAdapter("select * from Production.ProductPhoto", conn);

            DataSet ds = new DataSet();

            //Fill() 方法 自動化 Auto Connected DB:  conn.Open() => SqlCommand.Execute("select ...") => while  DataReader.Read() =>........ conn.Close()
            adapter.Fill(ds);

            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");

            SqlDataAdapter adapter = new SqlDataAdapter("select * from Products where UnitPrice > 30", conn);

            DataSet ds = new DataSet();

            //Fill() 方法 自動化 Auto Connected DB:  conn.Open() => SqlCommand.Execute("select ...") => while  DataReader.Read() =>........ conn.Close()
            adapter.Fill(ds);

            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {

            //Fill() 方法 自動化 Auto Connected DB:  conn.Open()
            //=> SqlCommand.Execute("select ...") =>
            //while  DataReader.Read() =>........ conn.Close()
            
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
           
            this.dataGridView2.DataSource = this.nwDataSet1.Products;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.categoriesTableAdapter1.Fill(this.nwDataSet1.Categories);

            this.dataGridView2.DataSource = this.nwDataSet1.Categories;
        }
    }
}


class class1
{
    class class2
    {

    }
}
