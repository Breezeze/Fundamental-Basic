namespace _4._2分页
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.CB_Times = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Division = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_Professional = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_Class = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.National = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentNu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // CB_Times
            // 
            this.CB_Times.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Times.FormattingEnabled = true;
            this.CB_Times.Location = new System.Drawing.Point(84, 41);
            this.CB_Times.Name = "CB_Times";
            this.CB_Times.Size = new System.Drawing.Size(91, 23);
            this.CB_Times.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "年级：";
            // 
            // CB_Division
            // 
            this.CB_Division.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Division.FormattingEnabled = true;
            this.CB_Division.Location = new System.Drawing.Point(247, 41);
            this.CB_Division.Name = "CB_Division";
            this.CB_Division.Size = new System.Drawing.Size(106, 23);
            this.CB_Division.TabIndex = 0;
            this.CB_Division.SelectedIndexChanged += new System.EventHandler(this.GetProfessional);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "学部：";
            // 
            // CB_Professional
            // 
            this.CB_Professional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Professional.FormattingEnabled = true;
            this.CB_Professional.Location = new System.Drawing.Point(422, 41);
            this.CB_Professional.Name = "CB_Professional";
            this.CB_Professional.Size = new System.Drawing.Size(174, 23);
            this.CB_Professional.TabIndex = 0;
            this.CB_Professional.SelectedIndexChanged += new System.EventHandler(this.GetClass);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "专业：";
            // 
            // CB_Class
            // 
            this.CB_Class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Class.FormattingEnabled = true;
            this.CB_Class.Location = new System.Drawing.Point(670, 41);
            this.CB_Class.Name = "CB_Class";
            this.CB_Class.Size = new System.Drawing.Size(112, 23);
            this.CB_Class.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(612, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "班级：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(803, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nid,
            this.StudentName,
            this.Gender,
            this.National,
            this.StudentNu,
            this.IdNumber});
            this.dataGridView1.Location = new System.Drawing.Point(27, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.Size = new System.Drawing.Size(878, 361);
            this.dataGridView1.TabIndex = 3;
            // 
            // Nid
            // 
            this.Nid.Frozen = true;
            this.Nid.HeaderText = "序号";
            this.Nid.Name = "Nid";
            this.Nid.ReadOnly = true;
            this.Nid.Width = 70;
            // 
            // StudentName
            // 
            this.StudentName.Frozen = true;
            this.StudentName.HeaderText = "姓名";
            this.StudentName.Name = "StudentName";
            this.StudentName.ReadOnly = true;
            this.StudentName.Width = 70;
            // 
            // Gender
            // 
            this.Gender.Frozen = true;
            this.Gender.HeaderText = "性别";
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            this.Gender.Width = 70;
            // 
            // National
            // 
            this.National.Frozen = true;
            this.National.HeaderText = "民族";
            this.National.Name = "National";
            this.National.ReadOnly = true;
            this.National.Width = 70;
            // 
            // StudentNu
            // 
            this.StudentNu.Frozen = true;
            this.StudentNu.HeaderText = "学号";
            this.StudentNu.Name = "StudentNu";
            this.StudentNu.ReadOnly = true;
            this.StudentNu.Width = 150;
            // 
            // IdNumber
            // 
            this.IdNumber.Frozen = true;
            this.IdNumber.HeaderText = "身份证";
            this.IdNumber.Name = "IdNumber";
            this.IdNumber.ReadOnly = true;
            this.IdNumber.Width = 200;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F);
            this.label5.Location = new System.Drawing.Point(390, 448);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 25);
            this.label5.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(306, 446);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "上一页";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(527, 446);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 35);
            this.button3.TabIndex = 5;
            this.button3.Text = "下一页";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(611, 446);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(78, 35);
            this.button4.TabIndex = 5;
            this.button4.Text = "尾页";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(222, 446);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(78, 35);
            this.button5.TabIndex = 5;
            this.button5.Text = "首页";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(830, 456);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 15);
            this.label6.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 493);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_Class);
            this.Controls.Add(this.CB_Professional);
            this.Controls.Add(this.CB_Division);
            this.Controls.Add(this.CB_Times);
            this.Name = "Form1";
            this.Text = "学生信息系统";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_Times;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_Division;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_Professional;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_Class;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nid;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn National;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentNu;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label6;
    }
}

