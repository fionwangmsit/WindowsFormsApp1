using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1._1._Overview
{
    public partial class FrmTool : Form
    {
        public FrmTool()
        {
            InitializeComponent();
        }

        private void categoriesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.categoriesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.nWDataSet);

        }

        private void FrmTool_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'nWDataSet.Categories' 資料表。您可以視需要進行移動或移除。
            this.categoriesTableAdapter.Fill(this.nWDataSet.Categories);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //強制回應 DialogBox - ShowDialog()
            DialogResult result = this.openFileDialog1.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                MessageBox.Show("OK " + this.openFileDialog1.FileName);

                this.picturePictureBox.Image = Image.FromFile(this.openFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("Cancel");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if ( this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = this.colorDialog1.Color;
            }
        }
    }
}
