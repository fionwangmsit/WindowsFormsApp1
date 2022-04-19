using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Transactions;

using WindowsFormsApp1.Properties;

namespace Demo
{
    public partial class FrmTransactionIsolation : Form
    {
        public FrmTransactionIsolation()
        {
            InitializeComponent();
        }




 #region "transaction Isolation"
 
        
        //'IsolationLevel.RepeatableRead
        //'==========================================
        //'查詢中 所使用的所有資料都會遭到鎖定，
        //'以免其他的使用者更新資料，
        //'但是其他使用者還是可以在資料集中插入新的幽靈資料列並於稍後在目前交易中讀入此資料。
        SqlTransaction tx = null;
        private void button86_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conn1 = new SqlConnection(Settings.Default.MyNWConnectionString);
                using (SqlCommand myCommand = new SqlCommand())
                {

                    myCommand.Connection = conn1;

                    conn1.Open();

                    tx = conn1.BeginTransaction(System.Data.IsolationLevel.RepeatableRead);
                    myCommand.Transaction = tx;


                    myCommand.CommandText = "select * from products";
                    SqlDataReader dr;
                    dr = myCommand.ExecuteReader();

                    this.listBox8.Items.Clear();

                    while (dr.Read())
                    {
                        this.listBox8.Items.Add(dr["ProductName"]);

                    }
                    dr.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //     'IsolationLevel.Serializable
        //'=========================================
        //'在資料集中加上某個範圍的鎖定，以免其他使用者在交易完成前更新或插入資料料至資料集。
        //'這是四個隔離等級中限制最嚴格的一種。由於同時發生性較低，因此只會在必要時才會使用此選項。
        //'此選項與在交易的所有 SELECT 陳述式中將所有資料表設定為HOLDLOCK具有相同的效果。

        private void button87_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conn1 = new SqlConnection(Settings.Default.MyNWConnectionString);

                using (SqlCommand myCommand = new SqlCommand())
                {

                    myCommand.Connection = conn1;

                    conn1.Open();

                    tx = conn1.BeginTransaction(System.Data.IsolationLevel.Serializable);
                    myCommand.Transaction = tx;


                    myCommand.CommandText = "select * from products";
                    SqlDataReader dr;
                    dr = myCommand.ExecuteReader();
                    this.listBox8.Items.Clear();
                    while (dr.Read())
                    {
                        this.listBox8.Items.Add(dr["ProductName"]);

                    }
                    dr.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button89_Click(object sender, EventArgs e)
        {
            tx.Commit();
        }

        private void button91_Click(object sender, EventArgs e)
        {
            tx.Rollback();
        }

        private void button126_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn1 = new SqlConnection(Settings.Default.MyNWConnectionString);

                using (SqlCommand myCommand = new SqlCommand())
                {

                    myCommand.Connection = conn1;

                    conn1.Open();

                    tx = conn1.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
                    myCommand.Transaction = tx;


                    myCommand.CommandText = "select * from products";
                    SqlDataReader dr;
                    dr = myCommand.ExecuteReader();

                    this.listBox8.Items.Clear();

                    while (dr.Read())
                    {
                        this.listBox8.Items.Add(dr["ProductName"]);

                    }
                    dr.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Button11_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn1 = new SqlConnection(Settings.Default.MyNWConnectionString);

                using (SqlCommand myCommand = new SqlCommand())
                {

                    myCommand.Connection = conn1;

                    conn1.Open();

                    tx = conn1.BeginTransaction(System.Data.IsolationLevel.RepeatableRead);
                    myCommand.Transaction = tx;


                    myCommand.CommandText = "update Products set ProductName = '@@@@' where ProductID=1";


                    myCommand.ExecuteNonQuery();



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            tx.Rollback();
        }
  
        private void button127_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conn1 = new SqlConnection(Settings.Default.MyNWConnectionString);

                using (SqlCommand myCommand = new SqlCommand())
                {

                    myCommand.Connection = conn1;

                    conn1.Open();

                    tx = conn1.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    myCommand.Transaction = tx;


                    myCommand.CommandText = "select * from products";
                    SqlDataReader dr;
                    dr = myCommand.ExecuteReader();

                    this.listBox8.Items.Clear();

                    while (dr.Read())
                    {
                        this.listBox8.Items.Add(dr["ProductName"]);

                    }
                    dr.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

 #endregion



    }
}