using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1._4._Disconnected_離線_DataSet;

namespace Starter
{
    public partial class FrmDisConnected_離線DataSet : Form
    {
        public FrmDisConnected_離線DataSet()
        {
            InitializeComponent();
            this.categoriesTableAdapter1.Fill(this.nwDataSet1.Categories);

            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            this.dataGridView7.DataSource = this.nwDataSet1.Products;

        }

        private void Button30_Click(object sender, EventArgs e)
        {
            // this.dataGridView1.DataSource = this.nwDataSet1.Categories;
            
            this.dataGridView1.DataSource = this.nwDataSet1;
            this.dataGridView1.DataMember = "Categories";

        }

        private void Button29_Click(object sender, EventArgs e)
        {
            this.dataGridView7.AllowUserToAddRows = false;
        }

        private void Button28_Click(object sender, EventArgs e)
        {
            this.dataGridView7.Columns[1].Frozen = true;

            this.dataGridView7.Rows[3].Frozen = true;

        }

        private void Button26_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.dataGridView7.CurrentCell.Value.ToString());
        }

        private void Button27_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.dataGridView7.CurrentRow.Cells[1].Value.ToString());

        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( e.ColumnIndex == 0)
            {
                int ProductID = (int) this.dataGridView7.CurrentRow.Cells["ProductID"].Value;
                //MessageBox.Show("ProductID = " + ProductID);
                
                FrmProductDetails f = new FrmProductDetails();
                f.ProductID = ProductID;
                f.Text = ProductID.ToString();
                f.Show();
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            this.dataGridView8.DataSource = this.nwDataSet1.Products;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataColumn column1 = new DataColumn("TotalPrice", typeof(decimal));

            column1.Expression = "UnitPrice * UnitsInStock";

            this.nwDataSet1.Products.Columns.Add(column1);

            this.dataGridView8.CellFormatting += dataGridView8_CellFormatting;
        }

       
        private void dataGridView8_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView8.Columns[e.ColumnIndex].Name == "TotalPrice")
            {
                if (e.Value is DBNull || e.Value == null) return;

                decimal Totalprice = (decimal)e.Value;


                e.CellStyle.Format = "c2";

                if (Totalprice > 1000)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmProductsCRUD f = new FrmProductsCRUD();
            f.Show();

        }
    }
}
