
namespace CompGraph7
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.openGLControl1 = new SharpGL.OpenGLControl();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.colorDialog2 = new System.Windows.Forms.ColorDialog();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(183, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Выберите фигуру:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 110);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(282, 25);
			this.label2.TabIndex = 1;
			this.label2.Text = "Выберите способ отрисовки:";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Фигура по заданию",
            "Утка"});
			this.comboBox1.Location = new System.Drawing.Point(17, 67);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(255, 28);
			this.comboBox1.TabIndex = 4;
			// 
			// comboBox2
			// 
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[] {
            "Сплошная",
            "Каркасная"});
			this.comboBox2.Location = new System.Drawing.Point(17, 145);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(178, 28);
			this.comboBox2.TabIndex = 5;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(12, 691);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(282, 83);
			this.button1.TabIndex = 6;
			this.button1.Text = "Старт";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// openGLControl1
			// 
			this.openGLControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.openGLControl1.Dock = System.Windows.Forms.DockStyle.Right;
			this.openGLControl1.DrawFPS = false;
			this.openGLControl1.FrameRate = 60;
			this.openGLControl1.Location = new System.Drawing.Point(302, 0);
			this.openGLControl1.Margin = new System.Windows.Forms.Padding(5);
			this.openGLControl1.Name = "openGLControl1";
			this.openGLControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
			this.openGLControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
			this.openGLControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
			this.openGLControl1.Size = new System.Drawing.Size(997, 786);
			this.openGLControl1.TabIndex = 7;
			this.openGLControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl1_OpenGLDraw);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBox1.Location = new System.Drawing.Point(17, 294);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(213, 24);
			this.checkBox1.TabIndex = 8;
			this.checkBox1.Text = "Включить освещение";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBox2.Location = new System.Drawing.Point(17, 335);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(266, 24);
			this.checkBox2.TabIndex = 9;
			this.checkBox2.Text = "Включить текстурирование";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// comboBox3
			// 
			this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Items.AddRange(new object[] {
            "OX",
            "OY",
            "OZ"});
			this.comboBox3.Location = new System.Drawing.Point(17, 238);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(69, 28);
			this.comboBox3.TabIndex = 11;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 198);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(287, 25);
			this.label3.TabIndex = 10;
			this.label3.Text = "Вращение относительно оси:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1299, 786);
			this.Controls.Add(this.comboBox3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.openGLControl1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Button button1;
		private SharpGL.OpenGLControl openGLControl1;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.ColorDialog colorDialog2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Label label3;
	}
}

