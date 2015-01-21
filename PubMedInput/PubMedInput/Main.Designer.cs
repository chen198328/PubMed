namespace PubMedInput
{
    partial class Main
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
            this.btnOpenFiles = new System.Windows.Forms.Button();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenerateTables = new System.Windows.Forms.Button();
            this.lbl_taskmessageshow = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cbxFilenames = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenFiles
            // 
            this.btnOpenFiles.Location = new System.Drawing.Point(689, 20);
            this.btnOpenFiles.Name = "btnOpenFiles";
            this.btnOpenFiles.Size = new System.Drawing.Size(93, 23);
            this.btnOpenFiles.TabIndex = 1;
            this.btnOpenFiles.Text = "打开";
            this.btnOpenFiles.UseVisualStyleBackColor = true;
            this.btnOpenFiles.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(83, 24);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(225, 21);
            this.txtTaskName.TabIndex = 2;
            this.txtTaskName.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGenerateTables);
            this.groupBox1.Controls.Add(this.lbl_taskmessageshow);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTaskName);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(795, 64);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnGenerateTables
            // 
            this.btnGenerateTables.Location = new System.Drawing.Point(685, 24);
            this.btnGenerateTables.Name = "btnGenerateTables";
            this.btnGenerateTables.Size = new System.Drawing.Size(97, 23);
            this.btnGenerateTables.TabIndex = 4;
            this.btnGenerateTables.Text = "生成";
            this.btnGenerateTables.UseVisualStyleBackColor = true;
            this.btnGenerateTables.Click += new System.EventHandler(this.btnGenerateTables_Click);
            // 
            // lbl_taskmessageshow
            // 
            this.lbl_taskmessageshow.AutoSize = true;
            this.lbl_taskmessageshow.Location = new System.Drawing.Point(326, 29);
            this.lbl_taskmessageshow.Name = "lbl_taskmessageshow";
            this.lbl_taskmessageshow.Size = new System.Drawing.Size(155, 12);
            this.lbl_taskmessageshow.TabIndex = 4;
            this.lbl_taskmessageshow.Text = "系统生成的表名:Title,Mesh";
            this.lbl_taskmessageshow.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "任务名：";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(19, 162);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(779, 223);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Multiselect = true;
            // 
            // cbxFilenames
            // 
            this.cbxFilenames.FormattingEnabled = true;
            this.cbxFilenames.Location = new System.Drawing.Point(7, 23);
            this.cbxFilenames.Name = "cbxFilenames";
            this.cbxFilenames.Size = new System.Drawing.Size(676, 20);
            this.cbxFilenames.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxFilenames);
            this.groupBox2.Controls.Add(this.btnOpenFiles);
            this.groupBox2.Location = new System.Drawing.Point(12, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(795, 59);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(701, 400);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(93, 23);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 470);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFiles;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_taskmessageshow;
        private System.Windows.Forms.Button btnGenerateTables;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ComboBox cbxFilenames;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnImport;
    }
}

