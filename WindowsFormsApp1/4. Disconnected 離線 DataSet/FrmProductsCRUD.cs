using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1._4._Disconnected_離線_DataSet
{
    public partial class FrmProductsCRUD : Form
    {
        public FrmProductsCRUD()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.nWDataSet);

        }

        private void FrmProductsCRUD_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'nWDataSet.Products' 資料表。您可以視需要進行移動或移除。
            this.productsTableAdapter.Fill(this.nWDataSet.Products);

        }

        private void Button15_Click(object sender, EventArgs e)
        {
            this.productsBindingSource.Position += 1;
        }

        bool Flag = true;
        private void Button23_Click(object sender, EventArgs e)
        {
            if (Flag)
            {
                this.productsBindingSource.Sort = "ProductName Asc";
            }
            else
            {
                this.productsBindingSource.Sort = "ProductName Desc";
            }

            Flag = !Flag;

        }

        private void Button21_Click(object sender, EventArgs e)
        {
            this.productsBindingSource.Filter = "UnitPrice>30";
        }

        private void Button22_Click(object sender, EventArgs e)
        {
            int position = this.productsBindingSource.Find("ProductID", 11);
            this.productsBindingSource.Position = position;
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(this.nWDataSet.Products);
            dv.RowFilter = "UnitPrice > 30";

            this.dataGridView1.DataSource = dv;
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            this.productsBindingSource.AddNew();

        }

        private void Button19_Click(object sender, EventArgs e)
        {
            this.productsBindingSource.RemoveAt(this.productsBindingSource.Position);
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            FrmAddProduct f = new FrmAddProduct();
          
            if (f.ShowDialog() == DialogResult.OK)  //f.DialogResult
            {
                MessageBox.Show("OK");

              NWDataSet.ProductsRow   prodRow= this.nWDataSet.Products.NewProductsRow();
              
                prodRow.ProductName = f.textBox1.Text;
                prodRow.Discontinued = f.checkBox1.Checked;

                this.nWDataSet.Products.AddProductsRow(prodRow);

                this.productsBindingSource.MoveLast();

            }
            else
            {
                MessageBox.Show("Cancel");
            }
        }
    }
}
