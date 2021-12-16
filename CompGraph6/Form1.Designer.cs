
using SharpGL;
using System;

namespace CompGraph6
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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.openGLControl1 = new SharpGL.OpenGLControl();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "OX",
            "OY",
            "OZ"});
			this.comboBox1.Location = new System.Drawing.Point(9, 73);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(80, 37);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.label1.Location = new System.Drawing.Point(5, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(275, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Вращение относительно оси:";
			// 
			// openGLControl1
			// 
			this.openGLControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.openGLControl1.Dock = System.Windows.Forms.DockStyle.Right;
			this.openGLControl1.DrawFPS = false;
			this.openGLControl1.FrameRate = 60;
			this.openGLControl1.Location = new System.Drawing.Point(287, 0);
			this.openGLControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.openGLControl1.Name = "openGLControl1";
			this.openGLControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL4_4;
			this.openGLControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
			this.openGLControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
			this.openGLControl1.Size = new System.Drawing.Size(1010, 715);
			this.openGLControl1.TabIndex = 2;
			this.openGLControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl1_OpenGLDraw);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBox1.Image = global::CompGraph6.Properties.Resources.Безывыфвыфмянный;
			this.pictureBox1.Location = new System.Drawing.Point(0, 501);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(287, 214);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(9, 137);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(178, 70);
			this.button1.TabIndex = 4;
			this.button1.Text = "Старт/Стоп";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1297, 715);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.openGLControl1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private SharpGL.OpenGLControl openGLControl1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button1;
	}
}

