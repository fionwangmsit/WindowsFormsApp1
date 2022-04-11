using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class FrmWarmUp : Form
    {
        //建構子方法
        public FrmWarmUp()
        {

            InitializeComponent();

            this.Text = "Hello";
            this.button1.Text = "yyy";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Hello
            MessageBox.Show("Hello, " + textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Hi
            MessageBox.Show("Hi, " + textBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //set property 設屬性
            label1.Text = "11111111111111";
            label1.BackColor = Color.Blue;
            label1.ForeColor = Color.White;

            label1.BorderStyle = BorderStyle.None;
            button1.Visible = false;



        }

        private void button6_Click(object sender, EventArgs e)
        {
            button3.Click += Button3_Click;
            button3.Click += aaa;
          
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("button3 click");
        }

        private void aaa(object sender, EventArgs e)
        {
            MessageBox.Show("aaa ");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int n = 99;

            FrmWarmUp f = new FrmWarmUp();
            f.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //static property - shared property
            MessageBox.Show(SystemInformation.ComputerName);

//            嚴重性 程式碼 說明 專案  檔案 行   隱藏項目狀態
//錯誤  CS0200 無法指派為屬性或索引子 'SystemInformation.ComputerName'-- 其為唯讀 WindowsFormsApp1    C:\shared\ADO.NET\WindowsFormsApp1\WindowsFormsApp1\Form1.cs    86  作用中
//            SystemInformation.ComputerName = "xxx";  //set property
            string  s =  SystemInformation.ComputerName;  //get property
            
            //==============================================
            //instance property
            button1.Text = "xxx";
            button2.Text = "yyy";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //static method - 依賴參數
            File.Copy("a.txt", "a1.txt", true);

            //==================================
            //Instance method - 依賴實體
            FileInfo f = new FileInfo("b.txt");
            MessageBox.Show(f.FullName + "\n" + f.Extension + "\n" + f.CreationTime);
            f.CopyTo("b1.txt", true);

        }

        private void button10_Click(object sender, EventArgs e)
        {

            //Error Demo 1
            //            嚴重性 程式碼 說明 專案  檔案 行   隱藏項目狀態
            //錯誤  CS0120 需要有物件參考，才可使用非靜態欄位、方法或屬性 'Form.Text' WindowsFormsApp1 C:\shared\ADO.NET\WindowsFormsApp1\WindowsFormsApp1\Form1.cs    114 作用中

            // Form1.Text = "Hello, " + textBox1.Text;

            //Error Demo 2
            //Form1 f = new Form1();
            //f.Text = "Hello " + textBox1.Text;
            //f.Show();

            //============================
           //Text = "Hello, " + this.textBox1.Text;
            this.Text = "Hello, " + this.textBox1.Text;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Close();
            this.Close();
        }
    }
}
