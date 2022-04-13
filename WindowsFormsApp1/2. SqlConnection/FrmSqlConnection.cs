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

namespace Starter

{
    public partial class FrmSqlConnection : Form
    {
        public FrmSqlConnection()
        {
            InitializeComponent();

            this.tabPage1.BackColor = Settings.Default.MyBackColor;
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
    }
}
