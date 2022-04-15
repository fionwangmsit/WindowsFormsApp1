using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace Starter
{
  
    public partial class FrmConnected : Form
    {
        public FrmConnected()
        {
            InitializeComponent();

            //divide and conquer
            //
            this.listView1.View = View.Details;
            LoadCountryToComboBox();
            CreateListViewColumns();

            this.tabControl1.SelectedIndex = 1;

        }

        private void CreateListViewColumns()
        {
           
            //Select 
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select * from Customers", conn);

                    SqlDataReader dataReader = command.ExecuteReader();

                    DataTable table = dataReader.GetSchemaTable();
                    this.dataGridView1.DataSource = table;

                    for (int i=0; i<= table.Rows.Count-1; i++)
                    {
                        this.listView1.Columns.Add(table.Rows[i][0].ToString());
                    }

                    this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


               } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadCountryToComboBox()
        {
            //Select 
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select distinct Country from Customers", conn);

                    SqlDataReader dataReader = command.ExecuteReader();

                    this.comboBox1.Items.Clear();
                    while (dataReader.Read())
                    {
                        this.comboBox1.Items.Add(dataReader["Country"]);
                    }
                    this.comboBox1.SelectedIndex = 0;

                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           //Select 
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();                 
                    command.CommandText = $"select * from Customers where country='{this.comboBox1.Text}'";
                    command.Connection = conn;

                    SqlDataReader dataReader = command.ExecuteReader();

                    this.listView1.Items.Clear();
                   
                    Random r = new Random();
                    while (dataReader.Read())
                    {
                        
                       ListViewItem lvi =   this.listView1.Items.Add(dataReader[0].ToString());

                        lvi.ImageIndex = r.Next(0, this.ImageList1.Images.Count);
                      
                        if (lvi.Index % 2 == 0)
                        {
                            lvi.BackColor = Color.Orange;
                        }
                       else
                        {
                            lvi.BackColor = Color.LightGray;
                        }
                        
                       
                        for (int i=1; i<= dataReader.FieldCount-1;i++)
                        {
                            if (dataReader.IsDBNull(i) ) 
                            {
                                lvi.SubItems.Add("空值");
                            }
                            else
                            {
                                lvi.SubItems.Add(dataReader[i].ToString());
                            }
                           
                        }
                    }
               } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.treeView1.Nodes.Add("xxx");
        }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.LargeIcon;
        }

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.SmallIcon;
        }

        private void detailsViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.Details;
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
             //Insert 
            try
            {
                string userName = this.textBox1.Text;
                string password = this.textBox2.Text;

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"Insert into MyMember(UserName, Password) values ('{userName}', '{password}')";
                    command.Connection = conn;
 
                    conn.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Insert Member successfully");


                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Select
            string userName = this.textBox1.Text;
            string password = this.textBox2.Text;
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"select * from MyMember where UserName='{userName}' and Password='{password}'";
                    command.Connection = conn;
                    
                    MessageBox.Show(command.CommandText);

                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                  
                    if ( dataReader.HasRows)
                    {
                        MessageBox.Show("會員登入成功");
                    }
                    else
                    {
                        MessageBox.Show("會員登入失敗");
                    }
                    

                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
   
            //Insert 
            try
            {
                string userName = this.textBox1.Text;
                string password = this.textBox2.Text;

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "Insert into MyMember(UserName, Password) values (@UserName,@Password)";
                    command.Connection = conn;

                    command.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = userName;
                    //command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = password;
                   
                    SqlParameter p1 = new SqlParameter();
                    p1.ParameterName = "@Password";
                    p1.SqlDbType = SqlDbType.NVarChar;
                    p1.Size = 40;
                    p1.Value = password;
                    //p1.Direction = ParameterDirection.Input;

                    command.Parameters.Add(p1);

                    conn.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Insert Member successfully");


                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {  //Insert 
            try
            {
                string userName = this.textBox1.Text;
                string password = this.textBox2.Text;

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "InsertMember";
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = userName;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = password;

                    //=================
                    SqlParameter p1 = new SqlParameter();
                    p1.ParameterName = "@Return_Value";
                    p1.Direction = ParameterDirection.ReturnValue;

                    command.Parameters.Add(p1);

                    //=================
                    conn.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Insert Member successfully MemberID = " + p1.Value);


                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
