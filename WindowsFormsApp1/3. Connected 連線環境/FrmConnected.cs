using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Security;
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

            this.tabControl1.SelectedIndex = 3;
            //=======================

            this.pictureBox1.AllowDrop = true;
           
            this.pictureBox1.DragEnter += PictureBox1_DragEnter;
            this.pictureBox1.DragDrop += PictureBox1_DragDrop;

            //==============================
            this.flowLayoutPanel1.AllowDrop = true;
            this.flowLayoutPanel1.DragEnter += FlowLayoutPanel1_DragEnter;
            this.flowLayoutPanel1.DragDrop += FlowLayoutPanel1_DragDrop;

        }

        private void FlowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            for (int i=0; i<= files.Length-1; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Image = Image.FromFile(files[i]);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Width = 120;
                pic.Height = 80;

                pic.Click += Pic_Click;
                this.flowLayoutPanel1.Controls.Add(pic);
            }
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            f.BackgroundImage = ((PictureBox) sender).Image;
            f.BackgroundImageLayout = ImageLayout.Stretch;
            f.Show();
        }

        private void FlowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void PictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

        }
        private void PictureBox1_DragDrop(object sender, DragEventArgs e)
        {
           string[] files = (string[])  e.Data.GetData(DataFormats.FileDrop);

            this.pictureBox1.Image = Image.FromFile(files[0]);

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

        private void button8_Click(object sender, EventArgs e)
        {

            //Insert 
            try
            {
                string userName = this.textBox1.Text;
                string password = this.textBox2.Text;
                password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");// System.Web.Configuration.FormsAuthPasswordFormat.SHA1.ToString());

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
        //for FormsAuthentication.HashPasswordForStoringInConfigFile  過時 Solution
        public string ComputeHash(string value)
        {
            //MD5 algorithm = MD5.Create();
            SHA1 algorithm = SHA1.Create();
            byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
            string hashString = "";
            for (int i = 0; i < data.Length; i++)
            {
                hashString += data[i].ToString("x2").ToUpperInvariant();
            }
            return hashString; //"abcd" =>81FE8BFE87576C3ECB22426F8E57847382917ACF
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();

                    string UserName = textBox1.Text;
                    string Password = textBox2.Text;

                    //=====================
                    System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
                    byte[] buf = new byte[15];
                    rng.GetBytes(buf); //要將在密碼編譯方面強式的隨機位元組填入的陣列。 
                    string salt = Convert.ToBase64String(buf);

                    Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Password + salt, "sha1");
                    //======================

                    command.CommandText = "Insert into MyMember (UserName, Password, Salt) values (@UserName, @Password, @Salt)";
                    command.Connection = conn;

                    command.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = UserName;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = Password;
                    command.Parameters.Add("@Salt", SqlDbType.NVarChar).Value = salt;

                    conn.Open();

                    command.ExecuteNonQuery();

                    MessageBox.Show("Insert successfully");
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.myMemberTableAdapter1.Insert("ppp", "PPP", "xxx");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //Aggregaion - Sum , Max, Min, Avg.....

            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;

                    conn.Open();

                    command.CommandText = "Select Sum(UnitPrice) from Products";
                    this.listBox2.Items.Add($"Sum UnitPrice = {command.ExecuteScalar():c2}");

                    command.CommandText = "Select Max(UnitPrice) from Products";
                    this.listBox2.Items.Add("Max UnitPrice =" + command.ExecuteScalar());

                    command.CommandText = "Select Min(UnitPrice) from Products";
                    this.listBox2.Items.Add("Min UnitPrice =" + command.ExecuteScalar());

                    command.CommandText = "Select Avg(UnitPrice) from Products";
                    this.listBox2.Items.Add("Avg UnitPrice =" + command.ExecuteScalar());

                    command.CommandText = "Select Count(*) from Products";
                    this.listBox2.Items.Add("Count UnitPrice =" + command.ExecuteScalar());
                   
                    //command.CommandText = "Select Median(UnitPrice) from Products";
                    //this.listBox2.Items.Add("Median UnitPrice =" + command.ExecuteScalar());

                } //conn.Close();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = "Select * from Categories;" +
                        "Select * from Products";
                    conn.Open();

                    SqlDataReader dataReader =  command.ExecuteReader();

                    while (
                        dataReader.
                        Read
                        ())
                    {
                        this.listBox1.
                            Items.
                            Add
                            (
                            dataReader
                            ["CategoryName"]);
                    }
                    //============================
                    dataReader.NextResult();

                    while (dataReader.Read())
                    {
                        this.listBox2.Items.Add(dataReader["ProductName"]);
                    }
                } //conn.Close();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string s = "sdf" +
                "dsf             sdfd" +
                "sfds";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string SqlCommandText =
"CREATE TABLE[dbo].[MyImageTable](" +
"[ImageID][int] IDENTITY(1, 1) NOT NULL," +
"[Description] [text] NULL," +
"[Image] [image] NULL," +
"CONSTRAINT[PK_MyImageTable] PRIMARY KEY CLUSTERED" +
"(" +
"[ImageID] ASC" +
")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]" +
") ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]";

            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = SqlCommandText;
                   
                    conn.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Create MyImageTable Successfully");
                  
                } //conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
           

            this.openFileDialog1.Filter = "(*.jpg)|*.jpg|(*.bmp)|*.bmp|Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = Image.FromFile(this.openFileDialog1.FileName);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            //Insert 
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "Insert into MyImageTable(Description, Image) values (@Desc,@Image)";
                    command.Connection = conn;
                    //=============================
                    byte[] bytes = null;//= { 1, 3 };

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    bytes = ms.GetBuffer();

                    //=============================
                    command.Parameters.Add("@Desc", SqlDbType.Text).Value = this.textBox4.Text;
                    command.Parameters.Add("@Image", SqlDbType.Image).Value = bytes;
                   
                  
                    conn.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Insert Image successfully");


                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            //Select
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "select * from MyImageTable";
                    command.Connection = conn;

                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    this.listBox3.Items.Clear();
                    this.listBox4.Items.Clear();  //List<int> IDs

                    while (dataReader.Read())
                    {
                        this.listBox3.Items.Add(dataReader["ImageID"] + "-" + dataReader["Description"]);
                        this.listBox4.Items.Add(dataReader["ImageID"]);
                    }

                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int imageID = (int) this.listBox4.Items[this.listBox3.SelectedIndex];
            ShowImage(imageID);
        }

        private void ShowImage(int imageID)
        {
            //Select
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"select * from MyImageTable where ImageID={imageID}";
                    command.Connection = conn;

                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        //=======================
                        dataReader.Read();
                       
                        byte[] bytes = (byte[])dataReader["Image"];
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                        this.pictureBox2.Image = Image.FromStream(ms);

                        //=======================
                    }
                    else
                    {
                        MessageBox.Show("No Record");
                    }
                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                this.pictureBox2.Image = this.pictureBox2.ErrorImage;
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            //Select
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "select * from MyImageTable";
                    command.Connection = conn;

                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    this.listBox5.Items.Clear();
                    while (dataReader.Read())
                    {
                        MyImage myImage = new MyImage();
                        myImage.ImageID = (int) dataReader["ImageID"];
                        myImage.ImageDesc = dataReader["Description"].ToString();
                      
                        this.listBox5.Items.Add(myImage);
                    }

                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int imageID = ((MyImage) this.listBox5.SelectedItem).ImageID; //this.listBox5.Items[this.listBox5.SelectedIndex].ImageID;
            ShowImage(imageID);
        }

        private void button28_Click(object sender, EventArgs e)
        {

            //Insert 
            try
            {
              
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;

                    conn.Open();

                     command.CommandText = "Insert into Region(RegionID, RegionDescription) values (100,'xxxxx')";
                   command.ExecuteNonQuery();

                    //exception
                    command.CommandText = "Insert into Region(RegionID, RegionDescription) values (100,'kjkjk')";
                    command.ExecuteNonQuery();

                    command.CommandText = "Insert into Region(RegionID, RegionDescription) values (101,'yyyyy')";
                    command.ExecuteNonQuery();

                    MessageBox.Show("Insert Region successfully");


                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            SqlTransaction txn = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(Settings.Default.NorthwindConnectionString);

                SqlCommand command = new SqlCommand();
                command.Connection = conn;

                conn.Open();
                txn = conn.BeginTransaction();

                command.Transaction = txn;

                command.CommandText = $"Insert into Region (RegionID, RegionDescription) values (100, 'xxx')";
                command.ExecuteNonQuery();

                //exception
                command.CommandText = $"Insert into Region (RegionID, RegionDescription) values (100, 'yyy')";
                command.ExecuteNonQuery();

                command.CommandText = $"Insert into Region (RegionID, RegionDescription) values (101, 'yyy')";
                command.ExecuteNonQuery();

                MessageBox.Show("Insert Region successfully");

                txn.Commit();

            }
            catch (Exception ex)
            {
                txn.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        #region Test DTC 分散式交易

        void TestDTC()
        {
            //以前 分散式交易用 COM+
            //現在用  TransactionScope
            try
            {

                using (TransactionScope scope = new TransactionScope())
                {

                    //'測試不同DB　DTC 用
                    //'觀察　Transaction.Current.TransactionInformation.DistributedIdentifier　變化

                    using (global::System.Data.SqlClient.SqlConnection conn1 = new System.Data.SqlClient.SqlConnection(Settings.Default.NorthwindConnectionString))
                    {
                        conn1.Open();


                        ShowCurrentTransaction();

                        SqlCommand command1 = new SqlCommand();
                        command1.Connection = conn1;
                        //command1.CommandText = "...."
                        //command1.ExecuteNonQuery();

                        conn1.Close();

                    }


                    //'測試不同DB　DTC 用
                    //'觀察　Transaction.Current.TransactionInformation.DistributedIdentifier　變化

                    using (SqlConnection conn1 = new SqlConnection(Settings.Default.NorthwindConnectionString))
                    {
                        using (SqlCommand myCommand = new SqlCommand())
                        {
                            myCommand.Connection = conn1;

                            conn1.Open();

                            ShowCurrentTransaction();

                            //Restore database to near it's original condition so sample will work correctly.
                            myCommand.CommandText = "DELETE FROM Region WHERE (RegionID = 100) OR (RegionID = 101)";
                            myCommand.ExecuteNonQuery();

                            //Insert the first record.
                            myCommand.CommandText = "Insert into Region (RegionID, RegionDescription) VALUES (100, 'MidWestern')";
                            myCommand.ExecuteNonQuery();


                            myCommand.CommandText = "Insert into Region (RegionID, RegionDescription) VALUES (100, 'MidWestern')";
                            myCommand.ExecuteNonQuery();

                            //Insert the second record.
                            myCommand.CommandText = "Insert into Region (RegionID, RegionDescription) VALUES (101, 'MidEastern')";
                            myCommand.ExecuteNonQuery();

                        }
                    }

                    MessageBox.Show("trans. Successfully");

                    scope.Complete();

                }   // call TransactionScope.Dispose()  //如果 TransactionScope 物件一開始就建立了交易，則由交易管理員認可交易的實際作業，

            }

            catch (TransactionException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {

                MessageBox.Show("trans. roll back " + ex.Message);
            }
        }
        private void ShowCurrentTransaction()
        {

            //Transaction.Current
            string s = "transaction.Current.IsolationLevel: " + Transaction.Current.IsolationLevel.ToString() + Environment.NewLine +
                    "TransactionInformation.CreationTime: " + Transaction.Current.TransactionInformation.CreationTime + Environment.NewLine +
                    "TransactionInformation.Status: " + Transaction.Current.TransactionInformation.Status.ToString() + Environment.NewLine +
                    "TransactionInformation.DistributedIdentifier: " + Transaction.Current.TransactionInformation.DistributedIdentifier.ToString() + Environment.NewLine +
                    "TransactionInformation.LocalIdentifier: " + Transaction.Current.TransactionInformation.LocalIdentifier.ToString();
            MessageBox.Show(s);


        }



        private void button82_Click(object sender, EventArgs e)
        {
            TestDTC();
        }



        private void button33_Click(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                    {

                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = conn;
                            conn.Open();

                            command.CommandText = "Delete from Region where RegionID=100 or RegionID = 101";
                            command.ExecuteNonQuery();

                            command.CommandText = "Insert into Region (RegionID, RegionDescription) Values (100, 'xxx')";
                            command.ExecuteNonQuery();


                            //Exception
                            //===================
                            command.CommandText = "Insert into Region (RegionID, RegionDescription) Values (100, 'xxx')";
                            command.ExecuteNonQuery();
                            //===================

                            command.CommandText = "Insert into Region (RegionID, RegionDescription) Values (101, 'xxx')";
                            command.ExecuteNonQuery();
                        }
                    }
                    scope.Complete();

                } // 則由交易管理員認可交易的實際作業，
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button84_Click(object sender, EventArgs e)
        {
            CommittableTransaction tx = null;
            try
            {

                using (tx = new CommittableTransaction())
                {
                    using (SqlConnection conn1 = new SqlConnection(Settings.Default.NorthwindConnectionString))
                    {

                        using (SqlCommand myCommand = new SqlCommand())
                        {

                            myCommand.Connection = conn1;

                            conn1.Open();
                            conn1.EnlistTransaction(tx);


                            //Restore database to near it's original condition so sample will work correctly.
                            myCommand.CommandText = "DELETE FROM Region WHERE (RegionID = 100) OR (RegionID = 101)";
                            myCommand.ExecuteNonQuery();

                            //Insert the first record.
                            myCommand.CommandText = "Insert into Region (RegionID, RegionDescription) VALUES (100, 'MidWestern')";
                            myCommand.ExecuteNonQuery();


                            //測試交易失敗用
                            //Insert the first record.
                            myCommand.CommandText = "Insert into Region (RegionID, RegionDescription) VALUES (100, 'MidWestern')";
                            myCommand.ExecuteNonQuery();


                            //Insert the second record.
                            myCommand.CommandText = "Insert into Region (RegionID, RegionDescription) VALUES (101, 'MidEastern')";
                            myCommand.ExecuteNonQuery();

                            tx.Commit();

                            MessageBox.Show("trans. Successfully");
                        }
                    }
                }

            }
            catch (TransactionException ex)
            {
                MessageBox.Show(ex.Message);
                tx.Rollback();
            }
            catch (Exception ex)
            {

                MessageBox.Show("trans. roll back " + ex.Message);
            }
        }



        private void button82_Click_1(object sender, EventArgs e)
        {
            TestDTC();
        }

        #endregion

    }


}
class MyImage : Object
{
    //class var.
    internal int ImageID;
    internal string ImageDesc;
    
    //TODO ....
    //Property get set

    //public override string ToString()
    //{
    //    return this.ImageDesc;
    //}

}