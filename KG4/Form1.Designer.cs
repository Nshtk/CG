
namespace KG4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("UD Digi Kyokasho NP-R", 20.29091F);
            this.textBox1.Location = new System.Drawing.Point(1096, 64);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(72, 36);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "15";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("UD Digi Kyokasho NP-R", 20.29091F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "X rotate",
            "Y rotate",
            "Z rotate"});
            this.comboBox1.Location = new System.Drawing.Point(976, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(192, 44);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.Text = "X rotate";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Transparent;
            this.button14.Image = global::KG4.Properties.Resources.scale_down;
            this.button14.Location = new System.Drawing.Point(27, 365);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 73);
            this.button14.TabIndex = 17;
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Transparent;
            this.button13.Image = global::KG4.Properties.Resources.scale_up;
            this.button13.Location = new System.Drawing.Point(27, 286);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 73);
            this.button13.TabIndex = 17;
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Transparent;
            this.button12.Image = global::KG4.Properties.Resources.projection;
            this.button12.Location = new System.Drawing.Point(55, 102);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(98, 82);
            this.button12.TabIndex = 16;
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Transparent;
            this.button11.Image = global::KG4.Properties.Resources._return;
            this.button11.Location = new System.Drawing.Point(1014, 154);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(109, 87);
            this.button11.TabIndex = 14;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Transparent;
            this.button10.Image = global::KG4.Properties.Resources.rot;
            this.button10.Location = new System.Drawing.Point(976, 64);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(109, 72);
            this.button10.TabIndex = 11;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.Image = global::KG4.Properties.Resources.mz;
            this.button9.Location = new System.Drawing.Point(27, 505);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 88);
            this.button9.TabIndex = 9;
            this.button9.Text = " ";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.Image = global::KG4.Properties.Resources.mx;
            this.button8.Location = new System.Drawing.Point(27, 683);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 84);
            this.button8.TabIndex = 8;
            this.button8.Text = " ";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.Image = global::KG4.Properties.Resources.my;
            this.button7.Location = new System.Drawing.Point(27, 599);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 78);
            this.button7.TabIndex = 7;
            this.button7.Text = " ";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.Image = global::KG4.Properties.Resources.front;
            this.button6.Location = new System.Drawing.Point(1094, 429);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(62, 56);
            this.button6.TabIndex = 6;
            this.button6.Text = " ";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.Image = global::KG4.Properties.Resources.back;
            this.button5.Location = new System.Drawing.Point(1094, 491);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(61, 56);
            this.button5.TabIndex = 5;
            this.button5.Text = " ";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.Image = global::KG4.Properties.Resources.down;
            this.button4.Location = new System.Drawing.Point(1014, 708);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(61, 65);
            this.button4.TabIndex = 4;
            this.button4.Text = " ";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.Image = global::KG4.Properties.Resources.up1;
            this.button3.Location = new System.Drawing.Point(1014, 642);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(61, 63);
            this.button3.TabIndex = 3;
            this.button3.Text = " ";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Image = global::KG4.Properties.Resources.left;
            this.button2.Location = new System.Drawing.Point(941, 708);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 65);
            this.button2.TabIndex = 2;
            this.button2.Text = " ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Image = global::KG4.Properties.Resources.right;
            this.button1.Location = new System.Drawing.Point(1081, 708);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 62);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("UD Digi Kyokasho NP-R", 20.29091F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBox1.Image = global::KG4.Properties.Resources.Wire;
            this.checkBox1.Location = new System.Drawing.Point(12, 15);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(191, 70);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Wireframe";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 785);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Kg4 - 3D";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
    }
}

