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
            this.winningLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.blueFightNm = new System.Windows.Forms.ComboBox();
            this.redFightNm = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.blueFighterPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redFighterPic)).BeginInit();
            this.SuspendLayout();
            // 
            // blueFighterPic
            // 
            this.blueFighterPic.BackColor = System.Drawing.Color.White;
            this.blueFighterPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blueFighterPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.blueFighterPic.Location = new System.Drawing.Point(15, 41);
            this.blueFighterPic.Name = "blueFighterPic";
            this.blueFighterPic.Size = new System.Drawing.Size(300, 195);
            this.blueFighterPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.blueFighterPic.TabIndex = 0;
            this.blueFighterPic.TabStop = false;
            // 
            // redFighterPic
            // 
            this.redFighterPic.BackColor = System.Drawing.Color.White;
            this.redFighterPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.redFighterPic.Location = new System.Drawing.Point(578, 41);
            this.redFighterPic.Name = "redFighterPic";
            this.redFighterPic.Size = new System.Drawing.Size(300, 195);
            this.redFighterPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.redFighterPic.TabIndex = 1;
            this.redFighterPic.TabStop = false;
            // 
            // startFightBtn
            // 
            this.startFightBtn.Location = new System.Drawing.Point(407, 240);
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
            this.blueFighterCbx.Location = new System.Drawing.Point(15, 242);
            this.blueFighterCbx.Name = "blueFighterCbx";
            this.blueFighterCbx.Size = new System.Drawing.Size(300, 21);
            this.blueFighterCbx.TabIndex = 3;
            this.blueFighterCbx.SelectedIndexChanged += new System.EventHandler(this.blueFighterCbx_SelectedIndexChanged);
            this.blueFighterCbx.Click += new System.EventHandler(this.blueFighterCbx_Click);
            // 
            // redFighterCbx
            // 
            this.redFighterCbx.FormattingEnabled = true;
            this.redFighterCbx.Location = new System.Drawing.Point(578, 242);
            this.redFighterCbx.Name = "redFighterCbx";
            this.redFighterCbx.Size = new System.Drawing.Size(300, 21);
            this.redFighterCbx.TabIndex = 4;
            this.redFighterCbx.SelectedIndexChanged += new System.EventHandler(this.redFighterCbx_SelectedIndexChanged);
            // 
            // winningLabel
            // 
            this.winningLabel.AutoSize = true;
            this.winningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.winningLabel.Location = new System.Drawing.Point(415, 115);
            this.winningLabel.Name = "winningLabel";
            this.winningLabel.Size = new System.Drawing.Size(31, 20);
            this.winningLabel.TabIndex = 5;
            this.winningLabel.Text = "VS";
            this.winningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(101, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Blue Fighter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(684, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Red Fighter";
            // 
            // blueFightNm
            // 
            this.blueFightNm.Enabled = false;
            this.blueFightNm.FormattingEnabled = true;
            this.blueFightNm.Location = new System.Drawing.Point(15, 269);
            this.blueFightNm.Name = "blueFightNm";
            this.blueFightNm.Size = new System.Drawing.Size(118, 21);
            this.blueFightNm.TabIndex = 8;
            // 
            // redFightNm
            // 
            this.redFightNm.Enabled = false;
            this.redFightNm.FormattingEnabled = true;
            this.redFightNm.Location = new System.Drawing.Point(757, 269);
            this.redFightNm.Name = "redFightNm";
            this.redFightNm.Size = new System.Drawing.Size(121, 21);
            this.redFightNm.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 627);
            this.Controls.Add(this.redFightNm);
            this.Controls.Add(this.blueFightNm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.winningLabel);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox blueFighterPic;
        private System.Windows.Forms.PictureBox redFighterPic;
        private System.Windows.Forms.Button startFightBtn;
        private System.Windows.Forms.ComboBox blueFighterCbx;
        private System.Windows.Forms.ComboBox redFighterCbx;
        private System.Windows.Forms.Label winningLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox blueFightNm;
        private System.Windows.Forms.ComboBox redFightNm;
    }
}

