namespace Balthazard
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.metinKutusu1 = new System.Windows.Forms.TextBox();
            this.metinKutusu2 = new System.Windows.Forms.TextBox();
            this.metinKutusu3 = new System.Windows.Forms.TextBox();
            this.sonucBox = new System.Windows.Forms.TextBox();
            this.nihaiBox = new System.Windows.Forms.TextBox();
            this.silBtn = new System.Windows.Forms.Button();
            this.hesaplaBtn = new System.Windows.Forms.Button();
            this.secim1 = new System.Windows.Forms.RadioButton();
            this.secim2 = new System.Windows.Forms.RadioButton();
            this.secim3 = new System.Windows.Forms.RadioButton();
            this.seniliteBtn = new System.Windows.Forms.CheckBox();
            this.baslikLbl = new System.Windows.Forms.Label();
            this.sekmeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // metinKutusu1
            // 
            this.metinKutusu1.Location = new System.Drawing.Point(12, 31);
            this.metinKutusu1.Name = "metinKutusu1";
            this.metinKutusu1.Size = new System.Drawing.Size(223, 20);
            this.metinKutusu1.TabIndex = 0;
            this.metinKutusu1.Click += new System.EventHandler(this.ustexBox_Click);
            this.metinKutusu1.TextChanged += new System.EventHandler(this.ustexBox_TextChanged);
            this.metinKutusu1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ustexBox_KeyDown);
            // 
            // metinKutusu2
            // 
            this.metinKutusu2.Location = new System.Drawing.Point(12, 57);
            this.metinKutusu2.Name = "metinKutusu2";
            this.metinKutusu2.Size = new System.Drawing.Size(223, 20);
            this.metinKutusu2.TabIndex = 1;
            this.metinKutusu2.Click += new System.EventHandler(this.altexBox_Click);
            this.metinKutusu2.TextChanged += new System.EventHandler(this.altexBox_TextChanged);
            this.metinKutusu2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.altexBox_KeyDown);
            // 
            // metinKutusu3
            // 
            this.metinKutusu3.Location = new System.Drawing.Point(12, 83);
            this.metinKutusu3.Name = "metinKutusu3";
            this.metinKutusu3.Size = new System.Drawing.Size(223, 20);
            this.metinKutusu3.TabIndex = 2;
            this.metinKutusu3.Click += new System.EventHandler(this.digerBox_Click);
            this.metinKutusu3.TextChanged += new System.EventHandler(this.digerBox_TextChanged);
            this.metinKutusu3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.digerBox_KeyDown);
            // 
            // sonucBox
            // 
            this.sonucBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.sonucBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sonucBox.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.sonucBox.Location = new System.Drawing.Point(12, 157);
            this.sonucBox.Multiline = true;
            this.sonucBox.Name = "sonucBox";
            this.sonucBox.Size = new System.Drawing.Size(388, 269);
            this.sonucBox.TabIndex = 5;
            // 
            // nihaiBox
            // 
            this.nihaiBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.nihaiBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nihaiBox.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.nihaiBox.Location = new System.Drawing.Point(11, 447);
            this.nihaiBox.Multiline = true;
            this.nihaiBox.Name = "nihaiBox";
            this.nihaiBox.Size = new System.Drawing.Size(389, 60);
            this.nihaiBox.TabIndex = 6;
            // 
            // silBtn
            // 
            this.silBtn.Location = new System.Drawing.Point(12, 109);
            this.silBtn.Name = "silBtn";
            this.silBtn.Size = new System.Drawing.Size(45, 23);
            this.silBtn.TabIndex = 4;
            this.silBtn.Text = "X";
            this.silBtn.UseVisualStyleBackColor = true;
            this.silBtn.Click += new System.EventHandler(this.silBtn_Click);
            // 
            // hesaplaBtn
            // 
            this.hesaplaBtn.Location = new System.Drawing.Point(50, 109);
            this.hesaplaBtn.Name = "hesaplaBtn";
            this.hesaplaBtn.Size = new System.Drawing.Size(186, 23);
            this.hesaplaBtn.TabIndex = 3;
            this.hesaplaBtn.Text = "<<<";
            this.hesaplaBtn.UseVisualStyleBackColor = true;
            this.hesaplaBtn.Click += new System.EventHandler(this.hesaplaBtn_Click);
            // 
            // secim1
            // 
            this.secim1.AutoSize = true;
            this.secim1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.secim1.Location = new System.Drawing.Point(242, 31);
            this.secim1.Name = "secim1";
            this.secim1.Size = new System.Drawing.Size(116, 23);
            this.secim1.TabIndex = 7;
            this.secim1.TabStop = true;
            this.secim1.Text = "Üst Ekstremite";
            this.secim1.UseVisualStyleBackColor = true;
            this.secim1.Click += new System.EventHandler(this.ustExBtn_Click);
            // 
            // secim2
            // 
            this.secim2.AutoSize = true;
            this.secim2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.secim2.Location = new System.Drawing.Point(242, 57);
            this.secim2.Name = "secim2";
            this.secim2.Size = new System.Drawing.Size(113, 23);
            this.secim2.TabIndex = 8;
            this.secim2.TabStop = true;
            this.secim2.Text = "Alt Ekstremite";
            this.secim2.UseVisualStyleBackColor = true;
            this.secim2.Click += new System.EventHandler(this.altExBtn_Click);
            // 
            // secim3
            // 
            this.secim3.AutoSize = true;
            this.secim3.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.secim3.Location = new System.Drawing.Point(242, 83);
            this.secim3.Name = "secim3";
            this.secim3.Size = new System.Drawing.Size(60, 23);
            this.secim3.TabIndex = 9;
            this.secim3.TabStop = true;
            this.secim3.Text = "Diğer";
            this.secim3.UseVisualStyleBackColor = true;
            this.secim3.Click += new System.EventHandler(this.digerBtn_Click);
            // 
            // seniliteBtn
            // 
            this.seniliteBtn.AutoSize = true;
            this.seniliteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seniliteBtn.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.seniliteBtn.Location = new System.Drawing.Point(242, 108);
            this.seniliteBtn.Name = "seniliteBtn";
            this.seniliteBtn.Size = new System.Drawing.Size(68, 23);
            this.seniliteBtn.TabIndex = 10;
            this.seniliteBtn.Text = "Senilite";
            this.seniliteBtn.UseVisualStyleBackColor = true;
            this.seniliteBtn.CheckedChanged += new System.EventHandler(this.seniliteBtn_CheckedChanged);
            // 
            // baslikLbl
            // 
            this.baslikLbl.AutoSize = true;
            this.baslikLbl.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.baslikLbl.Location = new System.Drawing.Point(12, 9);
            this.baslikLbl.Name = "baslikLbl";
            this.baslikLbl.Size = new System.Drawing.Size(138, 19);
            this.baslikLbl.TabIndex = 11;
            this.baslikLbl.Text = "Lütfen oranları giriniz.";
            // 
            // sekmeBtn
            // 
            this.sekmeBtn.Location = new System.Drawing.Point(157, 5);
            this.sekmeBtn.Name = "sekmeBtn";
            this.sekmeBtn.Size = new System.Drawing.Size(79, 23);
            this.sekmeBtn.TabIndex = 12;
            this.sekmeBtn.Text = "Extremite v.b.";
            this.sekmeBtn.UseVisualStyleBackColor = true;
            this.sekmeBtn.Click += new System.EventHandler(this.sekmeBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(413, 538);
            this.Controls.Add(this.sekmeBtn);
            this.Controls.Add(this.baslikLbl);
            this.Controls.Add(this.seniliteBtn);
            this.Controls.Add(this.secim3);
            this.Controls.Add(this.secim2);
            this.Controls.Add(this.secim1);
            this.Controls.Add(this.hesaplaBtn);
            this.Controls.Add(this.silBtn);
            this.Controls.Add(this.nihaiBox);
            this.Controls.Add(this.sonucBox);
            this.Controls.Add(this.metinKutusu3);
            this.Controls.Add(this.metinKutusu2);
            this.Controls.Add(this.metinKutusu1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Balthazard 2.0";
            this.Load += new System.EventHandler(this.tabanFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox metinKutusu1;
        private System.Windows.Forms.TextBox metinKutusu2;
        private System.Windows.Forms.TextBox metinKutusu3;
        private System.Windows.Forms.TextBox sonucBox;
        private System.Windows.Forms.TextBox nihaiBox;
        private System.Windows.Forms.Button silBtn;
        private System.Windows.Forms.Button hesaplaBtn;
        private System.Windows.Forms.RadioButton secim1;
        private System.Windows.Forms.RadioButton secim2;
        private System.Windows.Forms.RadioButton secim3;
        private System.Windows.Forms.CheckBox seniliteBtn;
        private System.Windows.Forms.Label baslikLbl;
        private System.Windows.Forms.Button sekmeBtn;
    }
}

