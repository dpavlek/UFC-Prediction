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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.percentLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.VSLabel = new System.Windows.Forms.Label();
            this.blueFighterInfo = new System.Windows.Forms.RichTextBox();
            this.redFighterInfo = new System.Windows.Forms.RichTextBox();
            this.fighterBetBox = new System.Windows.Forms.NumericUpDown();
            this.moneyBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.blueFighterRadio = new System.Windows.Forms.RadioButton();
            this.redFighterRadio = new System.Windows.Forms.RadioButton();
            this.bettingBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.blueFighterPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redFighterPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fighterBetBox)).BeginInit();
            this.bettingBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // blueFighterPic
            // 
            this.blueFighterPic.BackColor = System.Drawing.Color.Black;
            this.blueFighterPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blueFighterPic.Location = new System.Drawing.Point(17, 47);
            this.blueFighterPic.Name = "blueFighterPic";
            this.blueFighterPic.Size = new System.Drawing.Size(349, 224);
            this.blueFighterPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.blueFighterPic.TabIndex = 0;
            this.blueFighterPic.TabStop = false;
            // 
            // redFighterPic
            // 
            this.redFighterPic.BackColor = System.Drawing.Color.Black;
            this.redFighterPic.Location = new System.Drawing.Point(674, 47);
            this.redFighterPic.Name = "redFighterPic";
            this.redFighterPic.Size = new System.Drawing.Size(349, 224);
            this.redFighterPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.redFighterPic.TabIndex = 1;
            this.redFighterPic.TabStop = false;
            // 
            // startFightBtn
            // 
            this.startFightBtn.BackColor = System.Drawing.Color.White;
            this.startFightBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startFightBtn.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startFightBtn.Location = new System.Drawing.Point(461, 277);
            this.startFightBtn.Name = "startFightBtn";
            this.startFightBtn.Size = new System.Drawing.Size(136, 58);
            this.startFightBtn.TabIndex = 2;
            this.startFightBtn.Text = "FIGHT!";
            this.startFightBtn.UseVisualStyleBackColor = false;
            this.startFightBtn.Click += new System.EventHandler(this.startFightBtn_Click);
            // 
            // blueFighterCbx
            // 
            this.blueFighterCbx.BackColor = System.Drawing.Color.Black;
            this.blueFighterCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blueFighterCbx.ForeColor = System.Drawing.Color.White;
            this.blueFighterCbx.FormattingEnabled = true;
            this.blueFighterCbx.Location = new System.Drawing.Point(17, 279);
            this.blueFighterCbx.Name = "blueFighterCbx";
            this.blueFighterCbx.Size = new System.Drawing.Size(349, 23);
            this.blueFighterCbx.TabIndex = 3;
            this.blueFighterCbx.SelectedIndexChanged += new System.EventHandler(this.blueFighterCbx_SelectedIndexChanged);
            this.blueFighterCbx.Click += new System.EventHandler(this.blueFighterCbx_Click);
            // 
            // redFighterCbx
            // 
            this.redFighterCbx.BackColor = System.Drawing.Color.Black;
            this.redFighterCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.redFighterCbx.ForeColor = System.Drawing.Color.White;
            this.redFighterCbx.FormattingEnabled = true;
            this.redFighterCbx.Location = new System.Drawing.Point(674, 279);
            this.redFighterCbx.Name = "redFighterCbx";
            this.redFighterCbx.Size = new System.Drawing.Size(349, 23);
            this.redFighterCbx.TabIndex = 4;
            this.redFighterCbx.SelectedIndexChanged += new System.EventHandler(this.redFighterCbx_SelectedIndexChanged);
            // 
            // winningLabel
            // 
            this.winningLabel.AutoSize = true;
            this.winningLabel.BackColor = System.Drawing.Color.Transparent;
            this.winningLabel.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.winningLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.winningLabel.Location = new System.Drawing.Point(437, 122);
            this.winningLabel.Name = "winningLabel";
            this.winningLabel.Size = new System.Drawing.Size(149, 26);
            this.winningLabel.TabIndex = 5;
            this.winningLabel.Text = "Red Player Wins";
            this.winningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(118, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Blue Corner";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(798, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Red Corner";
            // 
            // blueFightNm
            // 
            this.blueFightNm.BackColor = System.Drawing.Color.Black;
            this.blueFightNm.Enabled = false;
            this.blueFightNm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blueFightNm.ForeColor = System.Drawing.Color.White;
            this.blueFightNm.FormattingEnabled = true;
            this.blueFightNm.Location = new System.Drawing.Point(230, 310);
            this.blueFightNm.Name = "blueFightNm";
            this.blueFightNm.Size = new System.Drawing.Size(137, 23);
            this.blueFightNm.TabIndex = 8;
            // 
            // redFightNm
            // 
            this.redFightNm.BackColor = System.Drawing.Color.Black;
            this.redFightNm.Enabled = false;
            this.redFightNm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.redFightNm.ForeColor = System.Drawing.Color.White;
            this.redFightNm.FormattingEnabled = true;
            this.redFightNm.Location = new System.Drawing.Point(883, 310);
            this.redFightNm.Name = "redFightNm";
            this.redFightNm.Size = new System.Drawing.Size(140, 23);
            this.redFightNm.TabIndex = 9;
            // 
            // percentLbl
            // 
            this.percentLbl.AutoSize = true;
            this.percentLbl.BackColor = System.Drawing.Color.Transparent;
            this.percentLbl.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.percentLbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.percentLbl.Location = new System.Drawing.Point(490, 209);
            this.percentLbl.Name = "percentLbl";
            this.percentLbl.Size = new System.Drawing.Size(62, 26);
            this.percentLbl.TabIndex = 10;
            this.percentLbl.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(84, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Fight number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(742, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Fight number:";
            // 
            // VSLabel
            // 
            this.VSLabel.AutoSize = true;
            this.VSLabel.BackColor = System.Drawing.Color.Transparent;
            this.VSLabel.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.VSLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.VSLabel.Location = new System.Drawing.Point(498, 47);
            this.VSLabel.Name = "VSLabel";
            this.VSLabel.Size = new System.Drawing.Size(37, 26);
            this.VSLabel.TabIndex = 13;
            this.VSLabel.Text = "VS";
            this.VSLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // blueFighterInfo
            // 
            this.blueFighterInfo.BackColor = System.Drawing.Color.Black;
            this.blueFighterInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.blueFighterInfo.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.blueFighterInfo.ForeColor = System.Drawing.Color.White;
            this.blueFighterInfo.Location = new System.Drawing.Point(17, 387);
            this.blueFighterInfo.Name = "blueFighterInfo";
            this.blueFighterInfo.ReadOnly = true;
            this.blueFighterInfo.Size = new System.Drawing.Size(349, 322);
            this.blueFighterInfo.TabIndex = 14;
            this.blueFighterInfo.Text = "";
            // 
            // redFighterInfo
            // 
            this.redFighterInfo.BackColor = System.Drawing.Color.Black;
            this.redFighterInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.redFighterInfo.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.redFighterInfo.ForeColor = System.Drawing.Color.White;
            this.redFighterInfo.Location = new System.Drawing.Point(674, 387);
            this.redFighterInfo.Name = "redFighterInfo";
            this.redFighterInfo.ReadOnly = true;
            this.redFighterInfo.Size = new System.Drawing.Size(349, 322);
            this.redFighterInfo.TabIndex = 15;
            this.redFighterInfo.Text = "";
            // 
            // fighterBetBox
            // 
            this.fighterBetBox.BackColor = System.Drawing.Color.Black;
            this.fighterBetBox.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fighterBetBox.ForeColor = System.Drawing.Color.White;
            this.fighterBetBox.Location = new System.Drawing.Point(41, 47);
            this.fighterBetBox.Name = "fighterBetBox";
            this.fighterBetBox.Size = new System.Drawing.Size(140, 27);
            this.fighterBetBox.TabIndex = 16;
            this.fighterBetBox.ValueChanged += new System.EventHandler(this.fighterBetBox_ValueChanged);
            // 
            // moneyBox
            // 
            this.moneyBox.BackColor = System.Drawing.Color.Black;
            this.moneyBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.moneyBox.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.moneyBox.ForeColor = System.Drawing.Color.White;
            this.moneyBox.Location = new System.Drawing.Point(45, 227);
            this.moneyBox.Name = "moneyBox";
            this.moneyBox.ReadOnly = true;
            this.moneyBox.Size = new System.Drawing.Size(136, 20);
            this.moneyBox.TabIndex = 17;
            this.moneyBox.Text = "1000$";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(63, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "Fighter Bet";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(63, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Moneys In Bank";
            // 
            // blueFighterRadio
            // 
            this.blueFighterRadio.AutoSize = true;
            this.blueFighterRadio.BackColor = System.Drawing.Color.Transparent;
            this.blueFighterRadio.ForeColor = System.Drawing.Color.White;
            this.blueFighterRadio.Location = new System.Drawing.Point(66, 101);
            this.blueFighterRadio.Name = "blueFighterRadio";
            this.blueFighterRadio.Size = new System.Drawing.Size(91, 19);
            this.blueFighterRadio.TabIndex = 23;
            this.blueFighterRadio.TabStop = true;
            this.blueFighterRadio.Text = "Blue Fighter";
            this.blueFighterRadio.UseVisualStyleBackColor = false;
            // 
            // redFighterRadio
            // 
            this.redFighterRadio.AutoSize = true;
            this.redFighterRadio.BackColor = System.Drawing.Color.Transparent;
            this.redFighterRadio.ForeColor = System.Drawing.Color.White;
            this.redFighterRadio.Location = new System.Drawing.Point(66, 137);
            this.redFighterRadio.Name = "redFighterRadio";
            this.redFighterRadio.Size = new System.Drawing.Size(88, 19);
            this.redFighterRadio.TabIndex = 24;
            this.redFighterRadio.TabStop = true;
            this.redFighterRadio.Text = "Red Fighter";
            this.redFighterRadio.UseVisualStyleBackColor = false;
            // 
            // bettingBox
            // 
            this.bettingBox.BackColor = System.Drawing.Color.Transparent;
            this.bettingBox.Controls.Add(this.fighterBetBox);
            this.bettingBox.Controls.Add(this.redFighterRadio);
            this.bettingBox.Controls.Add(this.label7);
            this.bettingBox.Controls.Add(this.label5);
            this.bettingBox.Controls.Add(this.moneyBox);
            this.bettingBox.Controls.Add(this.blueFighterRadio);
            this.bettingBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bettingBox.ForeColor = System.Drawing.Color.White;
            this.bettingBox.Location = new System.Drawing.Point(425, 420);
            this.bettingBox.Name = "bettingBox";
            this.bettingBox.Size = new System.Drawing.Size(200, 265);
            this.bettingBox.TabIndex = 25;
            this.bettingBox.TabStop = false;
            this.bettingBox.Text = "Betting";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UFC_Prediction.Properties.Resources.ufc_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1038, 723);
            this.Controls.Add(this.bettingBox);
            this.Controls.Add(this.redFighterInfo);
            this.Controls.Add(this.blueFighterInfo);
            this.Controls.Add(this.VSLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.percentLbl);
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
            this.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "UFC Prediction Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.blueFighterPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redFighterPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fighterBetBox)).EndInit();
            this.bettingBox.ResumeLayout(false);
            this.bettingBox.PerformLayout();
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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label percentLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label VSLabel;
        private System.Windows.Forms.RichTextBox blueFighterInfo;
        private System.Windows.Forms.RichTextBox redFighterInfo;
        private System.Windows.Forms.TextBox moneyBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown fighterBetBox;
        private System.Windows.Forms.RadioButton blueFighterRadio;
        private System.Windows.Forms.RadioButton redFighterRadio;
        private System.Windows.Forms.GroupBox bettingBox;
    }
}

