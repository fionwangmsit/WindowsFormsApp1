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
using System.Configuration;
using WindowsFormsApp1.Properties;
using System.Threading;

namespace Starter

{
    public partial class FrmSqlConnection : Form
    {
        public FrmSqlConnection()
        {
            InitializeComponent();

            this.tabPage1.BackColor = Settings.Default.MyBackColor;
            this.tabControl1.SelectedIndex = 2;

            //=====================
            //作業提示
            for (int i=0; i<=4; i++)
            {
                LinkLabel x = new LinkLabel();

                x.Text = "Taipei " + i;
                x.Left = 5;
                x.Top = 30 * i;
                x.Tag = i;  //ID

                x.Click += X_Click;
                x.MouseMove += X_MouseMove;
               
                this.panel1.Controls.Add(x);
            }
        }

        private void X_MouseMove(object sender, MouseEventArgs e)
        {
            //e.X
            //e.Y
        }

        private void X_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(  ((LinkLabel)sender).Text +" - " + ((LinkLabel)sender).Tag);

           // LinkLabel x = (LinkLabel)sender;

           LinkLabel x = sender as LinkLabel;
            if (x != null)
            {
                MessageBox.Show(x.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           
            //Step 1: SqlConnection
            //Step 2: SqlCommand
            //Step 3: SqlDataReader
            //Step 4: UI Control

 
            string connString = "Data Source=.;Initial Catalog=Northwind;Integrated Security=True";

            try
            {
                //syntax sugar  語法糖 using (....) {  }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select * from Products", conn);

                    SqlDataReader dataReader = command.ExecuteReader();

                    this.listBox1.Items.Clear();
                    while (dataReader.Read())
                    {
                        // syntax sugar 語法糖 for  string.Format(..)
                        string s = $"{dataReader["ProductName"],-40} - {dataReader["UnitPrice"]:c2}";
                        this.listBox1.Items.Add(s);
                    }
                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string connString = "Data Source=.;Initial Catalog=Northwind;User ID=sa;Password=sa";

            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connString);
                conn.Open();

                SqlCommand command = new SqlCommand("select * from Products", conn);

                // new SqlDataReader();
                SqlDataReader dataReader = command.ExecuteReader();

                this.listBox1.Items.Clear();

                while (dataReader.Read())
                {
                    // syntax sugar 語法糖 for  string.Format(..)
                    string s = $"{dataReader["ProductName"],-40} - {dataReader["UnitPrice"]:c2}";
                    this.listBox1.Items.Add(s);
                }

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

        private void button12_Click(object sender, EventArgs e)
        {

            //Step 1: SqlConnection
            //Step 2: SqlCommand
            //Step 3: SqlDataReader
            //Step 4: UI Control


            string connString = "Data Source=.;Initial Catalog=Northwind;Integrated Security=True";

            try
            {
                //syntax sugar  語法糖 using (....) {  }
                SqlConnection conn = null;
               
                using (conn = new SqlConnection(connString))
                {
                    conn.Open();
                    
                    MessageBox.Show(conn.State.ToString());

                    SqlCommand command = new SqlCommand("select * from Products", conn);

                    SqlDataReader dataReader = command.ExecuteReader();

                    this.listBox1.Items.Clear();
                    while (dataReader.Read())
                    {
                        // syntax sugar 語法糖 for  string.Format(..)
                        string s = $"{dataReader["ProductName"],-40} - {dataReader["UnitPrice"]:c2}";
                        this.listBox1.Items.Add(s);
                    }
                  
                } // Auto conn.Close()=>conn.Dispose()  // 釋放 System.ComponentModel.Component 所使用的所有資源。

                MessageBox.Show(conn.State.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
           string connString= ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.NorthwindConnectionString"].ConnectionString;
      
            try
            {
                //syntax sugar  語法糖 using (....) {  }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select * from Products", conn);

                    SqlDataReader dataReader = command.ExecuteReader();

                    this.listBox1.Items.Clear();
                    while (dataReader.Read())
                    {
                        // syntax sugar 語法糖 for  string.Format(..)
                        string s = $"{dataReader["ProductName"],-40} - {dataReader["UnitPrice"]:c2}";
                        this.listBox1.Items.Add(s);
                    }
                } // Auto conn.Close()=>conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button58_Click(object sender, EventArgs e)
        {
            try
            {
                //加密

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConfigurationSection section = config.Sections["connectionStrings"];
                section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                config.Save();
                MessageBox.Show("加密成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button59_Click(object sender, EventArgs e)
        {
            try
            {
                //解密
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConfigurationSection section = config.Sections["connectionStrings"];
                section.SectionInformation.UnprotectSection();
                config.Save();

                MessageBox.Show("解密成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connString = Settings.Default.MyNWConnectionString;

            try
            {
                //syntax sugar  語法糖 using (....) {  }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select * from Products", conn);

                    SqlDataReader dataReader = command.ExecuteReader();

                    this.listBox1.Items.Clear();
                    while (dataReader.Read())
                    {
                        // syntax sugar 語法糖 for  string.Format(..)
                        string s = $"{dataReader["ProductName"],-40} - {dataReader["UnitPrice"]:c2}";
                        this.listBox1.Items.Add(s);
                    }
                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.MyBackColor =  this.tabPage1.BackColor=  this.colorDialog1.Color;

                Settings.Default.Save(); //save to config 檔案
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\shared\ADO.NET\WindowsFormsApp1\WindowsFormsApp1\Database1.mdf;Integrated Security=True";

            try
            {
                //syntax sugar  語法糖 using (....) {  }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select * from MyTable", conn);

                    SqlDataReader dataReader = command.ExecuteReader();

                    this.listBox1.Items.Clear();
                    while (dataReader.Read())
                    {
                        // syntax sugar 語法糖 for  string.Format(..)
                        string s = $"{dataReader["UserName"]} - {dataReader["Password"]}";
                        this.listBox1.Items.Add(s);
                    }
                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connString = Settings.Default.MyLocalDB; //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            try
            {
                //syntax sugar  語法糖 using (....) {  }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select * from MyTable", conn);

                    SqlDataReader dataReader = command.ExecuteReader();

                    this.listBox1.Items.Clear();
                    while (dataReader.Read())
                    {
                        // syntax sugar 語法糖 for  string.Format(..)
                        string s = $"{dataReader["UserName"]} - {dataReader["Password"]}";
                        this.listBox1.Items.Add(s);
                    }
                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"(LocalDB)\MSSQLLocalDB";
            builder.AttachDBFilename = Application.StartupPath + @"\Database1.mdf";
            builder.IntegratedSecurity = true;

           // MessageBox.Show(builder.ConnectionString);

            try
            {
                //syntax sugar  語法糖 using (....) {  }

                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select * from MyTable", conn);

                    SqlDataReader dataReader = command.ExecuteReader();

                    this.listBox1.Items.Clear();
                    while (dataReader.Read())
                    {
                        // syntax sugar 語法糖 for  string.Format(..)
                        string s = $"{dataReader["UserName"]} - {dataReader["Password"]}";
                        this.listBox1.Items.Add(s);
                    }
                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            this.tabPage1.BackColor = Settings.Default.MyBackColor;
        }

        private void button11_Click(object sender, EventArgs e)
        {

            string connString = Settings.Default.NorthwindConnectionString;

            try
            {
                //syntax sugar  語法糖 using (....) {  }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.StateChange += Conn_StateChange;
                 
                    conn.Open();

                    SqlCommand command = new SqlCommand("select * from Products", conn);

                    SqlDataReader dataReader = command.ExecuteReader();

                    this.listBox2.Items.Clear();
                    while (dataReader.Read())
                    {
                        // syntax sugar 語法糖 for  string.Format(..)
                        string s = $"{dataReader["ProductName"],-40} - {dataReader["UnitPrice"]:c2}";
                        this.listBox2.Items.Add(s);
                    }
                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Conn_StateChange(object sender, StateChangeEventArgs e)
        {
            //this.toolStripStatusLabel1.Text = e.CurrentState.ToString();
            this.statusStrip1.Items[0].Text = e.CurrentState.ToString();
            this.statusStrip1.Items[1].Text = DateTime.Now.ToLongTimeString();


            Application.DoEvents();

            Thread.Sleep(700);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.productsTableAdapter1.Connection.ConnectionString);

            this.productsTableAdapter1.Connection.StateChange += Conn_StateChange;

            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            this.dataGridView1.DataSource = this.nwDataSet1.Products;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int[] nums = new int[100];

            SqlConnection[] conns = new SqlConnection[100];
            
            for(int i=0; i<= conns.Length-1; i++)
            {
                conns[i] = new SqlConnection(Settings.Default.NorthwindConnectionString);
                conns[i].Open();


                this.label3.Text = $"{i + 1}";
                Application.DoEvents();
                Thread.Sleep(100);

            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            //Pooling =True
            const int MAX = 100;

            SqlConnection[] conns = new SqlConnection[MAX];
            SqlDataReader[] dataReaders = new SqlDataReader[MAX];

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Settings.Default.NorthwindConnectionString);
            builder.MaxPoolSize = MAX;
            builder.ConnectTimeout = 2;
            builder.Pooling = true;

            System.Diagnostics.Stopwatch watcher1 = new System.Diagnostics.Stopwatch();
            watcher1.Start();
            for (int i = 0; i <= conns.Length - 1; i++)
            {
                conns[i] = new SqlConnection();

                conns[i].ConnectionString = builder.ConnectionString;
                conns[i].Open();


                SqlCommand command = new SqlCommand("Select * from Products", conns[i]);

                dataReaders[i] = command.ExecuteReader();

                while (dataReaders[i].Read())
                {
                    this.listBox3.Items.Add(dataReaders[i]["ProductName"]);
                }

                conns[i].Close();  //Return to POOL
            }

            watcher1.Stop();
            this.label1.Text = watcher1.Elapsed.TotalSeconds.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //Pooling =false
            const int MAX = 100;

            SqlConnection[] conns = new SqlConnection[MAX];
            SqlDataReader[] dataReaders = new SqlDataReader[MAX];

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Settings.Default.NorthwindConnectionString);
            builder.MaxPoolSize = MAX;
            builder.ConnectTimeout = 2;
            builder.Pooling = false;

            System.Diagnostics.Stopwatch watcher1 = new System.Diagnostics.Stopwatch();
            watcher1.Start();
            for (int i = 0; i <= conns.Length - 1; i++)
            {
                conns[i] = new SqlConnection();

                conns[i].ConnectionString = builder.ConnectionString;
                conns[i].Open();


                SqlCommand command = new SqlCommand("Select * from Products", conns[i]);

                dataReaders[i] = command.ExecuteReader();

                while (dataReaders[i].Read())
                {
                    this.listBox3.Items.Add(dataReaders[i]["ProductName"]);
                }

                conns[i].Close();  //NOT Return to POOL
            }
            watcher1.Stop();
            this.label2.Text = watcher1.Elapsed.TotalSeconds.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            const int MAXPoolSize = 200;

            SqlConnection[] conns = new SqlConnection[MAXPoolSize];

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Settings.Default.MyAWConnctionString);
            builder.MaxPoolSize = MAXPoolSize;
            builder.ConnectTimeout = 1;

            for (int i = 0; i <= conns.Length-1 ; i++)
            {
                conns[i] = new SqlConnection(builder.ConnectionString);
                conns[i].Open();


                this.label3.Text = $"{i + 1}";
                Application.DoEvents();
                Thread.Sleep(10);

            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;

            try

            {
                string connString = "Data Source=.;Initial Catalog=Northwindxxx;Integrated Security=True";

                conn = new SqlConnection(connString);

                SqlCommand command = new SqlCommand("Select * from Products", conn);
                SqlDataReader dr = null;
                conn.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox2.Items.Add(dr["ProductName"]);
                }

                this.comboBox2.SelectedIndex = 0;
            }


            catch (SqlException ex)
            {
                //ex.Number
                string s = "";
                for (int i = 0; i <= ex.Errors.Count - 1; i++)
                {
                    //$"{}{}{}"
                    s += string.Format("{0} : {1}", ex.Errors[i].Number, ex.Errors[i].Message) + Environment.NewLine;
                }
                MessageBox.Show("error count:" + ex.Errors.Count + Environment.NewLine + s);
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
                    conn.Dispose();
                }
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            string connString = "Data Source=.;Initial Catalog=Northwindxx;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);

            SqlCommand command = new SqlCommand("Select * from Products", conn);
            SqlDataReader dr = null;

            try
            {
                conn.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox2.Items.Add(dr["ProductName"]);
                }

                this.comboBox2.SelectedIndex = 0;
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 17:
                        MessageBox.Show("Wrong Server");
                        break;
                    case 4060:
                        MessageBox.Show("Wrong DataBase");
                        break;
                    case 18456:
                        MessageBox.Show("Wrong User");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
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
                    conn.Dispose();
                }
            }
        }
    }
}
