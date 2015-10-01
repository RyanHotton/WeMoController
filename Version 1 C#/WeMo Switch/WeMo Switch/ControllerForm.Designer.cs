namespace WeMo_Switch
{
    partial class ControllerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControllerForm));
            this.btnOn = new System.Windows.Forms.Button();
            this.btnOff = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.chkDefaultBtn = new System.Windows.Forms.CheckBox();
            this.gpBoxInfo = new System.Windows.Forms.GroupBox();
            this.lblWeMoName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnToggle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.gpBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOn
            // 
            this.btnOn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOn.Font = new System.Drawing.Font("Broadway", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOn.Location = new System.Drawing.Point(12, 228);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(120, 120);
            this.btnOn.TabIndex = 0;
            this.btnOn.Text = "ON";
            this.btnOn.UseVisualStyleBackColor = true;
            this.btnOn.Click += new System.EventHandler(this.btnOn_Click);
            // 
            // btnOff
            // 
            this.btnOff.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOff.Font = new System.Drawing.Font("Broadway", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOff.Location = new System.Drawing.Point(155, 228);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(120, 120);
            this.btnOff.TabIndex = 1;
            this.btnOff.Text = "OFF";
            this.btnOff.UseMnemonic = false;
            this.btnOff.UseVisualStyleBackColor = true;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "WeMo Controller";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "WeMo Status: ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(151, 62);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 20);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "N/A";
            // 
            // picIcon
            // 
            this.picIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picIcon.Location = new System.Drawing.Point(212, 49);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(60, 60);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIcon.TabIndex = 5;
            this.picIcon.TabStop = false;
            // 
            // chkDefaultBtn
            // 
            this.chkDefaultBtn.AutoSize = true;
            this.chkDefaultBtn.Location = new System.Drawing.Point(12, 92);
            this.chkDefaultBtn.Name = "chkDefaultBtn";
            this.chkDefaultBtn.Size = new System.Drawing.Size(99, 17);
            this.chkDefaultBtn.TabIndex = 6;
            this.chkDefaultBtn.Text = "Default Buttons";
            this.chkDefaultBtn.UseMnemonic = false;
            this.chkDefaultBtn.UseVisualStyleBackColor = true;
            this.chkDefaultBtn.CheckedChanged += new System.EventHandler(this.chkDefaultBtn_CheckedChanged);
            // 
            // gpBoxInfo
            // 
            this.gpBoxInfo.BackColor = System.Drawing.Color.White;
            this.gpBoxInfo.Controls.Add(this.lblWeMoName);
            this.gpBoxInfo.Controls.Add(this.lblName);
            this.gpBoxInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpBoxInfo.Location = new System.Drawing.Point(12, 116);
            this.gpBoxInfo.Name = "gpBoxInfo";
            this.gpBoxInfo.Size = new System.Drawing.Size(260, 100);
            this.gpBoxInfo.TabIndex = 7;
            this.gpBoxInfo.TabStop = false;
            this.gpBoxInfo.Text = "Info";
            // 
            // lblWeMoName
            // 
            this.lblWeMoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeMoName.Location = new System.Drawing.Point(117, 22);
            this.lblWeMoName.Name = "lblWeMoName";
            this.lblWeMoName.Size = new System.Drawing.Size(130, 23);
            this.lblWeMoName.TabIndex = 1;
            this.lblWeMoName.Text = "WeMo Switch";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(105, 16);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "WeMo Name: ";
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(253, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(33, 13);
            this.lblVersion.TabIndex = 8;
            this.lblVersion.Text = "v0.1";
            // 
            // btnToggle
            // 
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnToggle.Font = new System.Drawing.Font("Broadway", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggle.Location = new System.Drawing.Point(12, 228);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(263, 120);
            this.btnToggle.TabIndex = 9;
            this.btnToggle.Text = "TOGGLE";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // ControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 360);
            this.Controls.Add(this.btnToggle);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.gpBoxInfo);
            this.Controls.Add(this.chkDefaultBtn);
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOff);
            this.Controls.Add(this.btnOn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControllerForm";
            this.Text = "WeMo Controller";
            this.Load += new System.EventHandler(this.ControllerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.gpBoxInfo.ResumeLayout(false);
            this.gpBoxInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOn;
        private System.Windows.Forms.Button btnOff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.CheckBox chkDefaultBtn;
        private System.Windows.Forms.GroupBox gpBoxInfo;
        private System.Windows.Forms.Label lblWeMoName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnToggle;
    }
}

