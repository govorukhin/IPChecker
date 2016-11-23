namespace WindowsFormsApplication3
{
    partial class Form_RandomAddress
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Protocol = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_IPTo = new System.Windows.Forms.TextBox();
            this.textBox_IPFrom = new System.Windows.Forms.TextBox();
            this.button_Generate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_Protocol);
            this.groupBox1.Controls.Add(this.textBox_Port);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_Path);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(291, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 124);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Uri добовляемый к IP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Протокол";
            // 
            // textBox_Protocol
            // 
            this.textBox_Protocol.Location = new System.Drawing.Point(21, 47);
            this.textBox_Protocol.Name = "textBox_Protocol";
            this.textBox_Protocol.Size = new System.Drawing.Size(83, 20);
            this.textBox_Protocol.TabIndex = 40;
            this.textBox_Protocol.Text = "Http";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(110, 47);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(82, 20);
            this.textBox_Port.TabIndex = 34;
            this.textBox_Port.Text = "8080";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Порт";
            // 
            // textBox_Path
            // 
            this.textBox_Path.Location = new System.Drawing.Point(21, 86);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.Size = new System.Drawing.Size(206, 20);
            this.textBox_Path.TabIndex = 38;
            this.textBox_Path.Text = "/cgi-bin/admin/privacy.cgi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Путь";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Диапазон IP адресов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Max";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Min";
            // 
            // textBox_IPTo
            // 
            this.textBox_IPTo.Location = new System.Drawing.Point(33, 66);
            this.textBox_IPTo.Name = "textBox_IPTo";
            this.textBox_IPTo.Size = new System.Drawing.Size(243, 20);
            this.textBox_IPTo.TabIndex = 46;
            // 
            // textBox_IPFrom
            // 
            this.textBox_IPFrom.Location = new System.Drawing.Point(33, 34);
            this.textBox_IPFrom.Name = "textBox_IPFrom";
            this.textBox_IPFrom.Size = new System.Drawing.Size(241, 20);
            this.textBox_IPFrom.TabIndex = 45;
            // 
            // button_Generate
            // 
            this.button_Generate.Location = new System.Drawing.Point(31, 103);
            this.button_Generate.Name = "button_Generate";
            this.button_Generate.Size = new System.Drawing.Size(245, 23);
            this.button_Generate.TabIndex = 43;
            this.button_Generate.Text = "Генерировать случайный IP";
            this.button_Generate.UseVisualStyleBackColor = true;
            this.button_Generate.Click += new System.EventHandler(this.button_Generate_Click);
            // 
            // Form_RandomAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 146);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_IPTo);
            this.Controls.Add(this.textBox_IPFrom);
            this.Controls.Add(this.button_Generate);
            this.Name = "Form_RandomAddress";
            this.Text = "Создание случайного IP адреса";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Protocol;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Path;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_IPTo;
        private System.Windows.Forms.TextBox textBox_IPFrom;
        private System.Windows.Forms.Button button_Generate;
    }
}