using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace INA_Z2
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			dataGridView1 = new DataGridView();
			label1 = new Label();
			textBox1 = new TextBox();
			textBox2 = new TextBox();
			label2 = new Label();
			label3 = new Label();
			textBox4 = new TextBox();
			label4 = new Label();
			button1 = new Button();
			comboBox1 = new ComboBox();
			textBox3 = new TextBox();
			textBox5 = new TextBox();
			label5 = new Label();
			label6 = new Label();
			label7 = new Label();
			comboBox2 = new ComboBox();
			lp = new DataGridViewTextBoxColumn();
			x_real = new DataGridViewTextBoxColumn();
			f_x = new DataGridViewTextBoxColumn();
			g_x = new DataGridViewTextBoxColumn();
			p_i = new DataGridViewTextBoxColumn();
			q_i = new DataGridViewTextBoxColumn();
			r = new DataGridViewTextBoxColumn();
			x_real_sel = new DataGridViewTextBoxColumn();
			x_bin = new DataGridViewTextBoxColumn();
			parents = new DataGridViewTextBoxColumn();
			p_c = new DataGridViewTextBoxColumn();
			crossing = new DataGridViewTextBoxColumn();
			mutation_points = new DataGridViewTextBoxColumn();
			after_mutation = new DataGridViewTextBoxColumn();
			after_mutation_xreal = new DataGridViewTextBoxColumn();
			new_f_x = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(new DataGridViewColumn[] { lp, x_real, f_x, g_x, p_i, q_i, r, x_real_sel, x_bin, parents, p_c, crossing, mutation_points, after_mutation, after_mutation_xreal, new_f_x });
			dataGridView1.Location = new Point(12, 90);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowTemplate.Height = 25;
			dataGridView1.Size = new Size(1666, 337);
			dataGridView1.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(21, 24);
			label1.Name = "label1";
			label1.Size = new Size(24, 15);
			label1.TabIndex = 1;
			label1.Text = "a =";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(65, 21);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(100, 23);
			textBox1.TabIndex = 2;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(241, 24);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(100, 23);
			textBox2.TabIndex = 4;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(197, 27);
			label2.Name = "label2";
			label2.Size = new Size(25, 15);
			label2.TabIndex = 3;
			label2.Text = "b =";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(360, 27);
			label3.Name = "label3";
			label3.Size = new Size(25, 15);
			label3.TabIndex = 5;
			label3.Text = "d =";
			// 
			// textBox4
			// 
			textBox4.Location = new Point(561, 24);
			textBox4.Name = "textBox4";
			textBox4.Size = new Size(100, 23);
			textBox4.TabIndex = 8;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(528, 29);
			label4.Name = "label4";
			label4.Size = new Size(27, 15);
			label4.TabIndex = 7;
			label4.Text = "N =";
			// 
			// button1
			// 
			button1.Location = new Point(1180, 25);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 9;
			button1.Text = "START";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// comboBox1
			// 
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[] { "0,1", "0,01", "0,001", "0,0001" });
			comboBox1.Location = new Point(390, 24);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(121, 23);
			comboBox1.TabIndex = 10;
			// 
			// textBox3
			// 
			textBox3.Location = new Point(717, 24);
			textBox3.Name = "textBox3";
			textBox3.Size = new Size(100, 23);
			textBox3.TabIndex = 11;
			// 
			// textBox5
			// 
			textBox5.Location = new Point(874, 24);
			textBox5.Name = "textBox5";
			textBox5.Size = new Size(100, 23);
			textBox5.TabIndex = 12;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(675, 29);
			label5.Name = "label5";
			label5.Size = new Size(36, 15);
			label5.TabIndex = 13;
			label5.Text = "P_k =";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(827, 29);
			label6.Name = "label6";
			label6.Size = new Size(41, 15);
			label6.TabIndex = 14;
			label6.Text = "P_m =";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(991, 29);
			label7.Name = "label7";
			label7.Size = new Size(35, 15);
			label7.TabIndex = 16;
			label7.Text = "Cel =";
			// 
			// comboBox2
			// 
			comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox2.FormattingEnabled = true;
			comboBox2.Items.AddRange(new object[] { "Maximum" });
			comboBox2.Location = new Point(1032, 24);
			comboBox2.Name = "comboBox2";
			comboBox2.Size = new Size(121, 23);
			comboBox2.TabIndex = 17;
			// 
			// lp
			// 
			lp.HeaderText = "lp";
			lp.Name = "lp";
			// 
			// x_real
			// 
			x_real.HeaderText = "x_real";
			x_real.Name = "x_real";
			// 
			// f_x
			// 
			f_x.HeaderText = "f(x)";
			f_x.Name = "f_x";
			// 
			// g_x
			// 
			g_x.HeaderText = "g(x)";
			g_x.Name = "g_x";
			// 
			// p_i
			// 
			p_i.HeaderText = "p_i";
			p_i.Name = "p_i";
			// 
			// q_i
			// 
			q_i.HeaderText = "q_i";
			q_i.Name = "q_i";
			// 
			// r
			// 
			r.HeaderText = "r";
			r.Name = "r";
			// 
			// x_real_sel
			// 
			x_real_sel.HeaderText = "xreal po selekcji";
			x_real_sel.Name = "x_real_sel";
			// 
			// x_bin
			// 
			x_bin.HeaderText = "x_bin";
			x_bin.Name = "x_bin";
			// 
			// parents
			// 
			parents.HeaderText = "rodzice";
			parents.Name = "parents";
			// 
			// p_c
			// 
			p_c.HeaderText = "P_c";
			p_c.Name = "p_c";
			// 
			// crossing
			// 
			crossing.HeaderText = "pokolenie krzyżówkowe";
			crossing.Name = "crossing";
			// 
			// mutation_points
			// 
			mutation_points.HeaderText = "punkty mutacji";
			mutation_points.Name = "mutation_points";
			// 
			// after_mutation
			// 
			after_mutation.HeaderText = "po mutacji";
			after_mutation.Name = "after_mutation";
			// 
			// after_mutation_xreal
			// 
			after_mutation_xreal.HeaderText = "po mutacji xreal";
			after_mutation_xreal.Name = "after_mutation_xreal";
			// 
			// new_f_x
			// 
			new_f_x.HeaderText = "f(x)";
			new_f_x.Name = "new_f_x";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1690, 451);
			Controls.Add(comboBox2);
			Controls.Add(label7);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(textBox5);
			Controls.Add(textBox3);
			Controls.Add(comboBox1);
			Controls.Add(button1);
			Controls.Add(textBox4);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(textBox2);
			Controls.Add(label2);
			Controls.Add(textBox1);
			Controls.Add(label1);
			Controls.Add(dataGridView1);
			Name = "Form1";
			Text = "Form1";
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dataGridView1;
		private Label label1;
		private TextBox textBox1;
		private TextBox textBox2;
		private Label label2;
		private Label label3;
		private TextBox textBox4;
		private Label label4;
		private Button button1;
		private ComboBox comboBox1;
		private TextBox textBox3;
		private TextBox textBox5;
		private Label label5;
		private Label label6;
		private Label label7;
		private ComboBox comboBox2;
		private DataGridViewTextBoxColumn lp;
		private DataGridViewTextBoxColumn x_real;
		private DataGridViewTextBoxColumn f_x;
		private DataGridViewTextBoxColumn g_x;
		private DataGridViewTextBoxColumn p_i;
		private DataGridViewTextBoxColumn q_i;
		private DataGridViewTextBoxColumn r;
		private DataGridViewTextBoxColumn x_real_sel;
		private DataGridViewTextBoxColumn x_bin;
		private DataGridViewTextBoxColumn parents;
		private DataGridViewTextBoxColumn p_c;
		private DataGridViewTextBoxColumn crossing;
		private DataGridViewTextBoxColumn mutation_points;
		private DataGridViewTextBoxColumn after_mutation;
		private DataGridViewTextBoxColumn after_mutation_xreal;
		private DataGridViewTextBoxColumn new_f_x;
	}
}