namespace SzoTanuloProgram
{
    partial class ProgetosEsBeirogatos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgetosEsBeirogatos));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SajatSzojegyzek = new System.Windows.Forms.Button();
            this.ElementaryDropDownListTimer = new System.Windows.Forms.Timer(this.components);
            this.IntermediateDropDownListTimer = new System.Windows.Forms.Timer(this.components);
            this.PreIntermediateTimer = new System.Windows.Forms.Timer(this.components);
            this.ProficiencyTimer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.menuButton1 = new SzoTanuloProgram.MenuButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(960, 636);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.menuButton1);
            this.panel1.Controls.Add(this.SajatSzojegyzek);
            this.panel1.Location = new System.Drawing.Point(3, 578);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 3);
            this.panel1.Size = new System.Drawing.Size(300, 55);
            this.panel1.TabIndex = 7;
            // 
            // SajatSzojegyzek
            // 
            this.SajatSzojegyzek.BackColor = System.Drawing.Color.Orange;
            this.SajatSzojegyzek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SajatSzojegyzek.FlatAppearance.BorderSize = 0;
            this.SajatSzojegyzek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SajatSzojegyzek.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SajatSzojegyzek.Location = new System.Drawing.Point(0, 0);
            this.SajatSzojegyzek.Margin = new System.Windows.Forms.Padding(2);
            this.SajatSzojegyzek.Name = "SajatSzojegyzek";
            this.SajatSzojegyzek.Size = new System.Drawing.Size(150, 150);
            this.SajatSzojegyzek.TabIndex = 5;
            this.SajatSzojegyzek.Text = "EGYEDI SZÓJEGYZÉK BETÖLTÉSE";
            this.SajatSzojegyzek.UseVisualStyleBackColor = false;
            this.SajatSzojegyzek.Click += new System.EventHandler(this.SajatSzojegyzek_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 636);
            this.panel2.TabIndex = 8;
            // 
            // menuButton1
            // 
            this.menuButton1.Location = new System.Drawing.Point(150, 0);
            this.menuButton1.Margin = new System.Windows.Forms.Padding(0);
            this.menuButton1.Name = "menuButton1";
            this.menuButton1.Size = new System.Drawing.Size(150, 150);
            this.menuButton1.TabIndex = 6;
            // 
            // ProgetosEsBeirogatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(960, 636);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProgetosEsBeirogatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipus_1_Magyar_Angol_Szavak";
            this.Load += new System.EventHandler(this.Tipus_1_Magyar_Angol_Szavak_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer ElementaryDropDownListTimer;
        private System.Windows.Forms.Timer IntermediateDropDownListTimer;
        private System.Windows.Forms.Timer PreIntermediateTimer;
        private System.Windows.Forms.Timer ProficiencyTimer;
        private System.Windows.Forms.Button SajatSzojegyzek;
        private System.Windows.Forms.Panel panel1;
        private MenuButton menuButton1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}