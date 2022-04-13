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
            this.tabControl1.SelectedIndex = this.tabControl1.TabCount - 1;

            //...

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

        private void button9_Click(object sender, EventArgs e)
        {
           this.customersTableAdapter1.Fill(this.nwDataSet1.Customers);
            this.dataGridView2.DataSource = this.nwDataSet1.Customers;
        }

        private void button8_Click(object sender, EventArgs e)
        {
           // this.productsTableAdapter1.Connection.ConnectionString = ".......";
            this.productsTableAdapter1.FillByUnitPrice(this.nwDataSet1.Products, 30);
            this.dataGridView2.DataSource = this.nwDataSet1.Products;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.MyInsertProduct(DateTime.Now.ToString(), true);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Update(this.nwDataSet1.Products);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //this.productsTableAdapter1.Fill(this.nwDataSet1.Products);

            //this.dataGridView3.DataSource = this.nwDataSet1.Products;

            this.categoriesTableAdapter1.Fill(this.nwDataSet1.Categories);

            this.bindingSource1.DataSource = this.nwDataSet1.Categories;
            this.dataGridView3.DataSource = this.bindingSource1;

            // this.label6.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";
            //======================================================
            //Binding
            this.textBox1.DataBindings.Add("Text", this.bindingSource1, "CategoryName");
            this.pictureBox1.DataBindings.Add("Image", this.bindingSource1, "Picture", true);

            this.bindingNavigator1.BindingSource = this.bindingSource1;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //this.bindingSource1.Position += 1;
            this.bindingSource1.MoveNext();
           // this.label6.Text = $"{this.bindingSource1.Position+1} / {this.bindingSource1.Count}";

        }

        private void button13_Click(object sender, EventArgs e)
        {
            //this.bindingSource1.Position -= 1;

            this.bindingSource1.MovePrevious();
           // this.label6.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";

        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.bindingSource1.Position = 0;
           // this.label6.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";

        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.bindingSource1.Position = this.bindingSource1.Count - 1;
           // this.label6.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            this.label6.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";

        }

        private void button17_Click(object sender, EventArgs e)
        {
            FrmTool f = new FrmTool();
            f.Show();
            //f.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.categoriesTableAdapter1.Fill(this.nwDataSet1.Categories);
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            this.customersTableAdapter1.Fill(this.nwDataSet1.Customers);


            this.dataGridView4.DataSource = this.nwDataSet1.Categories;
            this.dataGridView5.DataSource = this.nwDataSet1.Products;
            this.dataGridView6.DataSource = this.nwDataSet1.Customers;
            //==================================

            this.listBox2.Items.Clear();

            for (int i=0; i<= this.nwDataSet1.Tables.Count-1; i++)
            {
                DataTable table = this.nwDataSet1.Tables[i];
                this.listBox2.Items.Add(table.TableName);

                //table.Columns //column schema
                string s = "";
                for (int column=0; column<= table.Columns.Count-1; column++)
                {
                    s += table.Columns[column].ColumnName+" ";
                }
                this.listBox2.Items.Add(s);
               
                //================================
                //table.Rows -Data
                //TODO .....
                for (int row =0; row<=table.Rows.Count-1; row++)
                {
                    //DataRow dr = table.Rows[row];
                    this.listBox2.Items.Add(table.Rows[row][0]);
                }


                this.listBox2.Items.Add("==========================");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //Weak Type - DataRow
            //MessageBox.Show(this.nwDataSet1.Products.Rows[0]["ProductNamex"].ToString());  //C# compiler OK; RunTime Error
            MessageBox.Show(this.nwDataSet1.Products.Rows[0][1].ToString());
            //================================

            //Strong Type - ProductRow
            //MessageBox.Show(this.nwDataSet1.Products[0].ProductNamex);//C# compiler Error
            MessageBox.Show(this.nwDataSet1.Products[0].ProductName);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.nwDataSet1.Products.WriteXml("Products.xml", XmlWriteMode.WriteSchema);

        }

        private void button21_Click(object sender, EventArgs e)
        {

            this.nwDataSet1.Products.Clear();

            this.nwDataSet1.Products.ReadXml("Products.xml");

            this.dataGridView4.DataSource = this.nwDataSet1.Products;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //if ( this.splitContainer2.Panel1Collapsed == true)
            //{
            //    this.splitContainer2.Panel1Collapsed = false;
            //}
            //else
            //{
            //    this.splitContainer2.Panel1Collapsed = true;
            //}    

            this.splitContainer2.Panel1Collapsed = ! this.splitContainer2.Panel1Collapsed;
        }
    }
}


class class1
{
    class class2
    {

    }
}
