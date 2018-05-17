namespace StatInspection
{
    partial class GenForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbSmpCount = new System.Windows.Forms.TextBox();
            this.tbMN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSQ = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMQ = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAQL = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbCT = new System.Windows.Forms.ComboBox();
            this.cbCL = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Количество партий:";
            // 
            // tbSmpCount
            // 
            this.tbSmpCount.Location = new System.Drawing.Point(12, 25);
            this.tbSmpCount.Name = "tbSmpCount";
            this.tbSmpCount.Size = new System.Drawing.Size(403, 20);
            this.tbSmpCount.TabIndex = 2;
            this.tbSmpCount.Text = "10";
            // 
            // tbMN
            // 
            this.tbMN.Location = new System.Drawing.Point(12, 64);
            this.tbMN.Name = "tbMN";
            this.tbMN.Size = new System.Drawing.Size(403, 20);
            this.tbMN.TabIndex = 4;
            this.tbMN.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Мат. ожидание объема партии:";
            // 
            // tbSN
            // 
            this.tbSN.Location = new System.Drawing.Point(12, 103);
            this.tbSN.Name = "tbSN";
            this.tbSN.Size = new System.Drawing.Size(403, 20);
            this.tbSN.TabIndex = 6;
            this.tbSN.Text = "5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ср. кв. откл. объема партии:";
            // 
            // tbSQ
            // 
            this.tbSQ.Location = new System.Drawing.Point(12, 181);
            this.tbSQ.Name = "tbSQ";
            this.tbSQ.Size = new System.Drawing.Size(403, 20);
            this.tbSQ.TabIndex = 10;
            this.tbSQ.Text = "0,01";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ср. кв. откл. реального уровня качества:";
            // 
            // tbMQ
            // 
            this.tbMQ.Location = new System.Drawing.Point(12, 142);
            this.tbMQ.Name = "tbMQ";
            this.tbMQ.Size = new System.Drawing.Size(403, 20);
            this.tbMQ.TabIndex = 8;
            this.tbMQ.Text = "0,3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(255, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Мат. ожидание реального уровня качества (в %):";
            // 
            // tbAQL
            // 
            this.tbAQL.Location = new System.Drawing.Point(12, 220);
            this.tbAQL.Name = "tbAQL";
            this.tbAQL.Size = new System.Drawing.Size(403, 20);
            this.tbAQL.TabIndex = 12;
            this.tbAQL.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Приемочный уровень качества AQL (в %):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Исходный вид контроля:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 282);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Уровень контроля:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(259, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(340, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbCT
            // 
            this.cbCT.FormattingEnabled = true;
            this.cbCT.Items.AddRange(new object[] {
            "Нормальный",
            "Ослабленный",
            "Усиленный"});
            this.cbCT.Location = new System.Drawing.Point(12, 259);
            this.cbCT.Name = "cbCT";
            this.cbCT.Size = new System.Drawing.Size(403, 21);
            this.cbCT.TabIndex = 19;
            this.cbCT.Text = "Нормальный";
            // 
            // cbCL
            // 
            this.cbCL.FormattingEnabled = true;
            this.cbCL.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "S-1",
            "S-2",
            "S-3",
            "S-4"});
            this.cbCL.Location = new System.Drawing.Point(12, 298);
            this.cbCL.Name = "cbCL";
            this.cbCL.Size = new System.Drawing.Size(403, 21);
            this.cbCL.TabIndex = 20;
            this.cbCL.Text = "II";
            // 
            // GenForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 362);
            this.Controls.Add(this.cbCL);
            this.Controls.Add(this.cbCT);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbAQL);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbSQ);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMQ);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSmpCount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenForm";
            this.ShowIcon = false;
            this.Text = "Генерация исходных данных";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox tbSmpCount;
        public System.Windows.Forms.TextBox tbMN;
        public System.Windows.Forms.TextBox tbSN;
        public System.Windows.Forms.TextBox tbSQ;
        public System.Windows.Forms.TextBox tbMQ;
        public System.Windows.Forms.TextBox tbAQL;
        public System.Windows.Forms.ComboBox cbCT;
        public System.Windows.Forms.ComboBox cbCL;
    }
}