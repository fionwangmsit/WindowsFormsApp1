namespace Demo
{
    partial class FrmTransactionIsolation
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTransactionIsolation));
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage17 = new System.Windows.Forms.TabPage();
            this.button9 = new System.Windows.Forms.Button();
            this.Button12 = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Button11 = new System.Windows.Forms.Button();
            this.listBox8 = new System.Windows.Forms.ListBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.button126 = new System.Windows.Forms.Button();
            this.button127 = new System.Windows.Forms.Button();
            this.button86 = new System.Windows.Forms.Button();
            this.button87 = new System.Windows.Forms.Button();
            this.button88 = new System.Windows.Forms.Button();
            this.button89 = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.button91 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.largeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageList2 = new System.Windows.Forms.ImageList(this.components);
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl4.SuspendLayout();
            this.tabPage17.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage17);
            this.tabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl4.Location = new System.Drawing.Point(0, 0);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(1504, 538);
            this.tabControl4.TabIndex = 1;
            // 
            // tabPage17
            // 
            this.tabPage17.Controls.Add(this.button9);
            this.tabPage17.Controls.Add(this.Button12);
            this.tabPage17.Controls.Add(this.Label5);
            this.tabPage17.Controls.Add(this.Label3);
            this.tabPage17.Controls.Add(this.Button11);
            this.tabPage17.Controls.Add(this.listBox8);
            this.tabPage17.Controls.Add(this.groupBox16);
            this.tabPage17.Controls.Add(this.button88);
            this.tabPage17.Controls.Add(this.button89);
            this.tabPage17.Controls.Add(this.label21);
            this.tabPage17.Controls.Add(this.label22);
            this.tabPage17.Controls.Add(this.button91);
            this.tabPage17.Location = new System.Drawing.Point(4, 28);
            this.tabPage17.Name = "tabPage17";
            this.tabPage17.Size = new System.Drawing.Size(1496, 506);
            this.tabPage17.TabIndex = 4;
            this.tabPage17.Text = "TransactionIsolationLevel";
            this.tabPage17.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(882, 240);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(180, 39);
            this.button9.TabIndex = 33;
            this.button9.Text = "Close Connection";
            // 
            // Button12
            // 
            this.Button12.Location = new System.Drawing.Point(882, 176);
            this.Button12.Margin = new System.Windows.Forms.Padding(4);
            this.Button12.Name = "Button12";
            this.Button12.Size = new System.Drawing.Size(293, 39);
            this.Button12.TabIndex = 32;
            this.Button12.Text = "RollBack 其他交易";
            this.Button12.Click += new System.EventHandler(this.Button12_Click);
            // 
            // Label5
            // 
            this.Label5.ForeColor = System.Drawing.Color.Red;
            this.Label5.Location = new System.Drawing.Point(1016, 62);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(387, 39);
            this.Label5.TabIndex = 31;
            this.Label5.Text = "測試 ReadUncommitted 和 ReadCommitted";
            // 
            // Label3
            // 
            this.Label3.ForeColor = System.Drawing.Color.Red;
            this.Label3.Location = new System.Drawing.Point(882, 62);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(120, 39);
            this.Label3.TabIndex = 30;
            this.Label3.Text = "測試方式 II:";
            // 
            // Button11
            // 
            this.Button11.Location = new System.Drawing.Point(882, 117);
            this.Button11.Margin = new System.Windows.Forms.Padding(4);
            this.Button11.Name = "Button11";
            this.Button11.Size = new System.Drawing.Size(280, 39);
            this.Button11.TabIndex = 29;
            this.Button11.Text = "啟動其他交易";
            this.Button11.Click += new System.EventHandler(this.Button11_Click);
            // 
            // listBox8
            // 
            this.listBox8.ItemHeight = 18;
            this.listBox8.Location = new System.Drawing.Point(509, 118);
            this.listBox8.Name = "listBox8";
            this.listBox8.Size = new System.Drawing.Size(251, 274);
            this.listBox8.TabIndex = 28;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.button126);
            this.groupBox16.Controls.Add(this.button127);
            this.groupBox16.Controls.Add(this.button86);
            this.groupBox16.Controls.Add(this.button87);
            this.groupBox16.Location = new System.Drawing.Point(29, 108);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(430, 195);
            this.groupBox16.TabIndex = 27;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "啟動本交易Begin Transaction Isolation Level";
            // 
            // button126
            // 
            this.button126.Location = new System.Drawing.Point(20, 132);
            this.button126.Name = "button126";
            this.button126.Size = new System.Drawing.Size(167, 38);
            this.button126.TabIndex = 13;
            this.button126.Text = "ReadUncommitted";
            this.button126.Click += new System.EventHandler(this.button126_Click);
            // 
            // button127
            // 
            this.button127.Location = new System.Drawing.Point(220, 132);
            this.button127.Name = "button127";
            this.button127.Size = new System.Drawing.Size(180, 39);
            this.button127.TabIndex = 14;
            this.button127.Text = "ReadCommitted";
            this.button127.Click += new System.EventHandler(this.button127_Click);
            // 
            // button86
            // 
            this.button86.Location = new System.Drawing.Point(20, 69);
            this.button86.Name = "button86";
            this.button86.Size = new System.Drawing.Size(193, 38);
            this.button86.TabIndex = 9;
            this.button86.Text = "RepeatableRead";
            this.button86.Click += new System.EventHandler(this.button86_Click);
            // 
            // button87
            // 
            this.button87.Location = new System.Drawing.Point(220, 69);
            this.button87.Name = "button87";
            this.button87.Size = new System.Drawing.Size(193, 38);
            this.button87.TabIndex = 10;
            this.button87.Text = "Serializable";
            this.button87.Click += new System.EventHandler(this.button87_Click);
            // 
            // button88
            // 
            this.button88.Location = new System.Drawing.Point(29, 441);
            this.button88.Name = "button88";
            this.button88.Size = new System.Drawing.Size(180, 39);
            this.button88.TabIndex = 25;
            this.button88.Text = "Close Connection";
            // 
            // button89
            // 
            this.button89.Location = new System.Drawing.Point(29, 339);
            this.button89.Name = "button89";
            this.button89.Size = new System.Drawing.Size(193, 39);
            this.button89.TabIndex = 22;
            this.button89.Text = "Commit Transaction";
            this.button89.Click += new System.EventHandler(this.button89_Click);
            // 
            // label21
            // 
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(38, 62);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(360, 38);
            this.label21.TabIndex = 26;
            this.label21.Text = "測試I.  RepeatableRead / Serializable ";
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Black;
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Location = new System.Drawing.Point(29, 39);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(1009, 12);
            this.label22.TabIndex = 21;
            // 
            // button91
            // 
            this.button91.Location = new System.Drawing.Point(29, 384);
            this.button91.Name = "button91";
            this.button91.Size = new System.Drawing.Size(193, 39);
            this.button91.TabIndex = 23;
            this.button91.Text = "RollBack Transaction";
            this.button91.Click += new System.EventHandler(this.button91_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeToolStripMenuItem,
            this.smallToolStripMenuItem,
            this.detailsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(140, 94);
            // 
            // largeToolStripMenuItem
            // 
            this.largeToolStripMenuItem.Name = "largeToolStripMenuItem";
            this.largeToolStripMenuItem.Size = new System.Drawing.Size(139, 30);
            this.largeToolStripMenuItem.Text = "Large";
            // 
            // smallToolStripMenuItem
            // 
            this.smallToolStripMenuItem.Name = "smallToolStripMenuItem";
            this.smallToolStripMenuItem.Size = new System.Drawing.Size(139, 30);
            this.smallToolStripMenuItem.Text = "Small";
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(139, 30);
            this.detailsToolStripMenuItem.Text = "Details";
            // 
            // ImageList2
            // 
            this.ImageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList2.ImageStream")));
            this.ImageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList2.Images.SetKeyName(0, "FLGGERM.ICO");
            this.ImageList2.Images.SetKeyName(1, "CTRCAN.ICO");
            this.ImageList2.Images.SetKeyName(2, "CTRFRAN.ICO");
            this.ImageList2.Images.SetKeyName(3, "CTRGERM.ICO");
            this.ImageList2.Images.SetKeyName(4, "CTRITALY.ICO");
            this.ImageList2.Images.SetKeyName(5, "CTRJAPAN.ICO");
            this.ImageList2.Images.SetKeyName(6, "CTRMEX.ICO");
            this.ImageList2.Images.SetKeyName(7, "CTRSKOR.ICO");
            this.ImageList2.Images.SetKeyName(8, "CTRSPAIN.ICO");
            this.ImageList2.Images.SetKeyName(9, "CTRUK.ICO");
            this.ImageList2.Images.SetKeyName(10, "CTRUSA.ICO");
            this.ImageList2.Images.SetKeyName(11, "FLGASTRL.ICO");
            this.ImageList2.Images.SetKeyName(12, "FLGAUSTA.ICO");
            this.ImageList2.Images.SetKeyName(13, "FLGBELG.ICO");
            this.ImageList2.Images.SetKeyName(14, "FLGBRAZL.ICO");
            this.ImageList2.Images.SetKeyName(15, "FLGCAN.ICO");
            this.ImageList2.Images.SetKeyName(16, "FLGDEN.ICO");
            this.ImageList2.Images.SetKeyName(17, "FLGFIN.ICO");
            this.ImageList2.Images.SetKeyName(18, "FLGFRAN.ICO");
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "FLGGERM.ICO");
            this.ImageList1.Images.SetKeyName(1, "CTRCAN.ICO");
            this.ImageList1.Images.SetKeyName(2, "CTRFRAN.ICO");
            this.ImageList1.Images.SetKeyName(3, "CTRGERM.ICO");
            this.ImageList1.Images.SetKeyName(4, "CTRITALY.ICO");
            this.ImageList1.Images.SetKeyName(5, "CTRJAPAN.ICO");
            this.ImageList1.Images.SetKeyName(6, "CTRMEX.ICO");
            this.ImageList1.Images.SetKeyName(7, "CTRSKOR.ICO");
            this.ImageList1.Images.SetKeyName(8, "CTRSPAIN.ICO");
            this.ImageList1.Images.SetKeyName(9, "CTRUK.ICO");
            this.ImageList1.Images.SetKeyName(10, "CTRUSA.ICO");
            this.ImageList1.Images.SetKeyName(11, "FLGASTRL.ICO");
            this.ImageList1.Images.SetKeyName(12, "FLGAUSTA.ICO");
            this.ImageList1.Images.SetKeyName(13, "FLGBELG.ICO");
            this.ImageList1.Images.SetKeyName(14, "FLGBRAZL.ICO");
            this.ImageList1.Images.SetKeyName(15, "FLGCAN.ICO");
            this.ImageList1.Images.SetKeyName(16, "FLGDEN.ICO");
            this.ImageList1.Images.SetKeyName(17, "FLGFIN.ICO");
            this.ImageList1.Images.SetKeyName(18, "FLGFRAN.ICO");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmTransactionIsolation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1504, 538);
            this.Controls.Add(this.tabControl4);
            this.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmTransactionIsolation";
            this.Text = "FrmTransactionIsolation";
            this.tabControl4.ResumeLayout(false);
            this.tabPage17.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage17;
        internal System.Windows.Forms.ListBox listBox8;
        internal System.Windows.Forms.GroupBox groupBox16;
        internal System.Windows.Forms.Button button126;
        internal System.Windows.Forms.Button button127;
        internal System.Windows.Forms.Button button86;
        internal System.Windows.Forms.Button button87;
        internal System.Windows.Forms.Button button88;
        internal System.Windows.Forms.Button button89;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.Label label22;
        internal System.Windows.Forms.Button button91;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        internal System.Windows.Forms.ImageList ImageList1;
        internal System.Windows.Forms.ImageList ImageList2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem largeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        internal System.Windows.Forms.Button Button12;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button Button11;
        internal System.Windows.Forms.Button button9;
    }
}