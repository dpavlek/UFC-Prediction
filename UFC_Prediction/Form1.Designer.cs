namespace UFC_Prediction
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
            this.blueFighterPic = new System.Windows.Forms.PictureBox();
            this.redFighterPic = new System.Windows.Forms.PictureBox();
            this.startFightBtn = new System.Windows.Forms.Button();
            this.blueFighterCbx = new System.Windows.Forms.ComboBox();
            this.redFighterCbx = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.blueFighterPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redFighterPic)).BeginInit();
            this.SuspendLayout();
            // 
            // blueFighterPic
            // 
            this.blueFighterPic.BackColor = System.Drawing.Color.White;
            this.blueFighterPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.blueFighterPic.Location = new System.Drawing.Point(12, 12);
            this.blueFighterPic.Name = "blueFighterPic";
            this.blueFighterPic.Size = new System.Drawing.Size(300, 195);
            this.blueFighterPic.TabIndex = 0;
            this.blueFighterPic.TabStop = false;
            // 
            // redFighterPic
            // 
            this.redFighterPic.BackColor = System.Drawing.Color.White;
            this.redFighterPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.redFighterPic.Location = new System.Drawing.Point(575, 12);
            this.redFighterPic.Name = "redFighterPic";
            this.redFighterPic.Size = new System.Drawing.Size(300, 195);
            this.redFighterPic.TabIndex = 1;
            this.redFighterPic.TabStop = false;
            // 
            // startFightBtn
            // 
            this.startFightBtn.Location = new System.Drawing.Point(391, 213);
            this.startFightBtn.Name = "startFightBtn";
            this.startFightBtn.Size = new System.Drawing.Size(75, 23);
            this.startFightBtn.TabIndex = 2;
            this.startFightBtn.Text = "Fight!";
            this.startFightBtn.UseVisualStyleBackColor = true;
            this.startFightBtn.Click += new System.EventHandler(this.startFightBtn_Click);
            // 
            // blueFighterCbx
            // 
            this.blueFighterCbx.FormattingEnabled = true;
            this.blueFighterCbx.Location = new System.Drawing.Point(12, 213);
            this.blueFighterCbx.Name = "blueFighterCbx";
            this.blueFighterCbx.Size = new System.Drawing.Size(300, 21);
            this.blueFighterCbx.TabIndex = 3;
            this.blueFighterCbx.SelectedIndexChanged += new System.EventHandler(this.blueFighterCbx_SelectedIndexChanged);
            this.blueFighterCbx.Click += new System.EventHandler(this.blueFighterCbx_Click);
            // 
            // redFighterCbx
            // 
            this.redFighterCbx.FormattingEnabled = true;
            this.redFighterCbx.Location = new System.Drawing.Point(575, 213);
            this.redFighterCbx.Name = "redFighterCbx";
            this.redFighterCbx.Size = new System.Drawing.Size(300, 21);
            this.redFighterCbx.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 627);
            this.Controls.Add(this.redFighterCbx);
            this.Controls.Add(this.blueFighterCbx);
            this.Controls.Add(this.startFightBtn);
            this.Controls.Add(this.redFighterPic);
            this.Controls.Add(this.blueFighterPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.blueFighterPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redFighterPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox blueFighterPic;
        private System.Windows.Forms.PictureBox redFighterPic;
        private System.Windows.Forms.Button startFightBtn;
        private System.Windows.Forms.ComboBox blueFighterCbx;
        private System.Windows.Forms.ComboBox redFighterCbx;
    }
}

