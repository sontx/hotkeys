namespace HotKeys.Forms
{
    partial class frmKiller
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
            this.cmbProcess = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labVirus = new System.Windows.Forms.Label();
            this.txtDes = new System.Windows.Forms.TextBox();
            this.txtStartAt = new System.Windows.Forms.TextBox();
            this.txtLocal = new System.Windows.Forms.TextBox();
            this.llabVirus = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bntKill = new System.Windows.Forms.Button();
            this.pic = new System.Windows.Forms.PictureBox();
            this.bntRefresh = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbProcess
            // 
            this.cmbProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProcess.FormattingEnabled = true;
            this.cmbProcess.Location = new System.Drawing.Point(38, 15);
            this.cmbProcess.Name = "cmbProcess";
            this.cmbProcess.Size = new System.Drawing.Size(210, 21);
            this.cmbProcess.TabIndex = 1;
            this.cmbProcess.SelectedIndexChanged += new System.EventHandler(this.cmbProcess_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labVirus);
            this.groupBox1.Controls.Add(this.txtDes);
            this.groupBox1.Controls.Add(this.txtStartAt);
            this.groupBox1.Controls.Add(this.txtLocal);
            this.groupBox1.Controls.Add(this.llabVirus);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 95);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // labVirus
            // 
            this.labVirus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labVirus.Location = new System.Drawing.Point(140, 67);
            this.labVirus.Name = "labVirus";
            this.labVirus.Size = new System.Drawing.Size(114, 14);
            this.labVirus.TabIndex = 7;
            this.labVirus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDes
            // 
            this.txtDes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDes.BackColor = System.Drawing.SystemColors.Control;
            this.txtDes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDes.Location = new System.Drawing.Point(75, 50);
            this.txtDes.Name = "txtDes";
            this.txtDes.ReadOnly = true;
            this.txtDes.Size = new System.Drawing.Size(179, 13);
            this.txtDes.TabIndex = 6;
            // 
            // txtStartAt
            // 
            this.txtStartAt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartAt.BackColor = System.Drawing.SystemColors.Control;
            this.txtStartAt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStartAt.Location = new System.Drawing.Point(75, 33);
            this.txtStartAt.Name = "txtStartAt";
            this.txtStartAt.ReadOnly = true;
            this.txtStartAt.Size = new System.Drawing.Size(179, 13);
            this.txtStartAt.TabIndex = 5;
            // 
            // txtLocal
            // 
            this.txtLocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocal.BackColor = System.Drawing.SystemColors.Control;
            this.txtLocal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLocal.Location = new System.Drawing.Point(75, 16);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.ReadOnly = true;
            this.txtLocal.Size = new System.Drawing.Size(179, 13);
            this.txtLocal.TabIndex = 4;
            // 
            // llabVirus
            // 
            this.llabVirus.AutoSize = true;
            this.llabVirus.Location = new System.Drawing.Point(6, 67);
            this.llabVirus.Name = "llabVirus";
            this.llabVirus.Size = new System.Drawing.Size(128, 13);
            this.llabVirus.TabIndex = 3;
            this.llabVirus.TabStop = true;
            this.llabVirus.Text = "Check with virustotal.com";
            this.llabVirus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llabVirus_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start at:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Localtion:";
            // 
            // bntKill
            // 
            this.bntKill.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bntKill.Location = new System.Drawing.Point(97, 151);
            this.bntKill.Name = "bntKill";
            this.bntKill.Size = new System.Drawing.Size(91, 25);
            this.bntKill.TabIndex = 3;
            this.bntKill.Text = "Kill";
            this.bntKill.UseVisualStyleBackColor = true;
            this.bntKill.Click += new System.EventHandler(this.bntKill_Click);
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(15, 15);
            this.pic.Margin = new System.Windows.Forms.Padding(0);
            this.pic.MaximumSize = new System.Drawing.Size(21, 21);
            this.pic.MinimumSize = new System.Drawing.Size(21, 21);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(21, 21);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 4;
            this.pic.TabStop = false;
            // 
            // bntRefresh
            // 
            this.bntRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntRefresh.Font = new System.Drawing.Font("Segoe UI Symbol", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntRefresh.Location = new System.Drawing.Point(254, 15);
            this.bntRefresh.MaximumSize = new System.Drawing.Size(21, 21);
            this.bntRefresh.MinimumSize = new System.Drawing.Size(21, 21);
            this.bntRefresh.Name = "bntRefresh";
            this.bntRefresh.Size = new System.Drawing.Size(21, 21);
            this.bntRefresh.TabIndex = 5;
            this.bntRefresh.Text = "↷";
            this.bntRefresh.UseVisualStyleBackColor = true;
            this.bntRefresh.Click += new System.EventHandler(this.bntRefresh_Click);
            // 
            // frmKiller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 188);
            this.Controls.Add(this.bntRefresh);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.bntKill);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbProcess);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKiller";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotkeys - Killer";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProcess;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bntKill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel llabVirus;
        private System.Windows.Forms.TextBox txtLocal;
        private System.Windows.Forms.TextBox txtDes;
        private System.Windows.Forms.TextBox txtStartAt;
        private System.Windows.Forms.Label labVirus;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Button bntRefresh;
    }
}