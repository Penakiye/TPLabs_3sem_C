namespace WindowsFormsBomber
{
    partial class FormWarPlaneConfig
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.labelBomber = new System.Windows.Forms.Label();
            this.labelWarPlane = new System.Windows.Forms.Label();
            this.pictureBoxWarPlane = new System.Windows.Forms.PictureBox();
            this.panelWarPlane = new System.Windows.Forms.Panel();
            this.labelDopColor = new System.Windows.Forms.Label();
            this.labelMainColor = new System.Windows.Forms.Label();
            this.groupBoxColor = new System.Windows.Forms.GroupBox();
            this.panelGold = new System.Windows.Forms.Panel();
            this.panelYellow = new System.Windows.Forms.Panel();
            this.panelGray = new System.Windows.Forms.Panel();
            this.panelRed = new System.Windows.Forms.Panel();
            this.panelBlue = new System.Windows.Forms.Panel();
            this.panelWhite = new System.Windows.Forms.Panel();
            this.panelGreen = new System.Windows.Forms.Panel();
            this.panelBlack = new System.Windows.Forms.Panel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarPlane)).BeginInit();
            this.panelWarPlane.SuspendLayout();
            this.groupBoxColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.labelBomber);
            this.groupBox.Controls.Add(this.labelWarPlane);
            this.groupBox.Location = new System.Drawing.Point(9, 20);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(184, 118);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Тип военного самолета";
            // 
            // labelBomber
            // 
            this.labelBomber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelBomber.Location = new System.Drawing.Point(30, 69);
            this.labelBomber.Name = "labelBomber";
            this.labelBomber.Size = new System.Drawing.Size(121, 30);
            this.labelBomber.TabIndex = 1;
            this.labelBomber.Text = "Бомбардировщик";
            this.labelBomber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelBomber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelBomber_MouseDown);
            // 
            // labelWarPlane
            // 
            this.labelWarPlane.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelWarPlane.Location = new System.Drawing.Point(30, 28);
            this.labelWarPlane.Name = "labelWarPlane";
            this.labelWarPlane.Size = new System.Drawing.Size(121, 30);
            this.labelWarPlane.TabIndex = 0;
            this.labelWarPlane.Text = "Военный самолет";
            this.labelWarPlane.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelWarPlane.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelWarPlane_MouseDown);
            // 
            // pictureBoxWarPlane
            // 
            this.pictureBoxWarPlane.Location = new System.Drawing.Point(26, 19);
            this.pictureBoxWarPlane.Name = "pictureBoxWarPlane";
            this.pictureBoxWarPlane.Size = new System.Drawing.Size(100, 80);
            this.pictureBoxWarPlane.TabIndex = 1;
            this.pictureBoxWarPlane.TabStop = false;
            // 
            // panelWarPlane
            // 
            this.panelWarPlane.AllowDrop = true;
            this.panelWarPlane.Controls.Add(this.labelDopColor);
            this.panelWarPlane.Controls.Add(this.labelMainColor);
            this.panelWarPlane.Controls.Add(this.pictureBoxWarPlane);
            this.panelWarPlane.Location = new System.Drawing.Point(208, 20);
            this.panelWarPlane.Name = "panelWarPlane";
            this.panelWarPlane.Size = new System.Drawing.Size(153, 229);
            this.panelWarPlane.TabIndex = 2;
            this.panelWarPlane.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelWarPlane_DragDrop);
            this.panelWarPlane.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelWarPlane_DragEnter);
            // 
            // labelDopColor
            // 
            this.labelDopColor.AllowDrop = true;
            this.labelDopColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDopColor.Location = new System.Drawing.Point(27, 171);
            this.labelDopColor.Name = "labelDopColor";
            this.labelDopColor.Size = new System.Drawing.Size(98, 35);
            this.labelDopColor.TabIndex = 3;
            this.labelDopColor.Text = "Доп. цвет";
            this.labelDopColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDopColor.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelDopColor_DragDrop);
            this.labelDopColor.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelMainColor_DragEnter);
            // 
            // labelMainColor
            // 
            this.labelMainColor.AllowDrop = true;
            this.labelMainColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMainColor.Location = new System.Drawing.Point(28, 120);
            this.labelMainColor.Name = "labelMainColor";
            this.labelMainColor.Size = new System.Drawing.Size(98, 35);
            this.labelMainColor.TabIndex = 2;
            this.labelMainColor.Text = "Основной цвет";
            this.labelMainColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMainColor.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelMainColor_DragDrop);
            this.labelMainColor.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelMainColor_DragEnter);
            // 
            // groupBoxColor
            // 
            this.groupBoxColor.Controls.Add(this.panelGold);
            this.groupBoxColor.Controls.Add(this.panelYellow);
            this.groupBoxColor.Controls.Add(this.panelGray);
            this.groupBoxColor.Controls.Add(this.panelRed);
            this.groupBoxColor.Controls.Add(this.panelBlue);
            this.groupBoxColor.Controls.Add(this.panelWhite);
            this.groupBoxColor.Controls.Add(this.panelGreen);
            this.groupBoxColor.Controls.Add(this.panelBlack);
            this.groupBoxColor.Location = new System.Drawing.Point(389, 21);
            this.groupBoxColor.Name = "groupBoxColor";
            this.groupBoxColor.Size = new System.Drawing.Size(136, 228);
            this.groupBoxColor.TabIndex = 3;
            this.groupBoxColor.TabStop = false;
            this.groupBoxColor.Text = "Цвета";
            // 
            // panelGold
            // 
            this.panelGold.BackColor = System.Drawing.Color.Gold;
            this.panelGold.Location = new System.Drawing.Point(79, 174);
            this.panelGold.Name = "panelGold";
            this.panelGold.Size = new System.Drawing.Size(35, 35);
            this.panelGold.TabIndex = 3;
            // 
            // panelYellow
            // 
            this.panelYellow.BackColor = System.Drawing.Color.Yellow;
            this.panelYellow.Location = new System.Drawing.Point(79, 123);
            this.panelYellow.Name = "panelYellow";
            this.panelYellow.Size = new System.Drawing.Size(35, 35);
            this.panelYellow.TabIndex = 4;
            // 
            // panelGray
            // 
            this.panelGray.BackColor = System.Drawing.Color.Silver;
            this.panelGray.Location = new System.Drawing.Point(19, 174);
            this.panelGray.Name = "panelGray";
            this.panelGray.Size = new System.Drawing.Size(35, 35);
            this.panelGray.TabIndex = 1;
            // 
            // panelRed
            // 
            this.panelRed.BackColor = System.Drawing.Color.Red;
            this.panelRed.Location = new System.Drawing.Point(79, 72);
            this.panelRed.Name = "panelRed";
            this.panelRed.Size = new System.Drawing.Size(35, 35);
            this.panelRed.TabIndex = 5;
            // 
            // panelBlue
            // 
            this.panelBlue.BackColor = System.Drawing.Color.Blue;
            this.panelBlue.Location = new System.Drawing.Point(19, 123);
            this.panelBlue.Name = "panelBlue";
            this.panelBlue.Size = new System.Drawing.Size(35, 35);
            this.panelBlue.TabIndex = 1;
            // 
            // panelWhite
            // 
            this.panelWhite.BackColor = System.Drawing.Color.White;
            this.panelWhite.Location = new System.Drawing.Point(79, 26);
            this.panelWhite.Name = "panelWhite";
            this.panelWhite.Size = new System.Drawing.Size(35, 35);
            this.panelWhite.TabIndex = 2;
            // 
            // panelGreen
            // 
            this.panelGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panelGreen.Location = new System.Drawing.Point(19, 72);
            this.panelGreen.Name = "panelGreen";
            this.panelGreen.Size = new System.Drawing.Size(35, 35);
            this.panelGreen.TabIndex = 1;
            // 
            // panelBlack
            // 
            this.panelBlack.BackColor = System.Drawing.Color.Black;
            this.panelBlack.Location = new System.Drawing.Point(19, 26);
            this.panelBlack.Name = "panelBlack";
            this.panelBlack.Size = new System.Drawing.Size(35, 35);
            this.panelBlack.TabIndex = 0;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(9, 150);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(95, 41);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Добавить";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(98, 208);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(95, 41);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // FormWarPlaneConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 261);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBoxColor);
            this.Controls.Add(this.panelWarPlane);
            this.Controls.Add(this.groupBox);
            this.Name = "FormWarPlaneConfig";
            this.Text = "Выбор военного самолета";
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarPlane)).EndInit();
            this.panelWarPlane.ResumeLayout(false);
            this.groupBoxColor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label labelBomber;
        private System.Windows.Forms.Label labelWarPlane;
        private System.Windows.Forms.PictureBox pictureBoxWarPlane;
        private System.Windows.Forms.Panel panelWarPlane;
        private System.Windows.Forms.Label labelDopColor;
        private System.Windows.Forms.Label labelMainColor;
        private System.Windows.Forms.GroupBox groupBoxColor;
        private System.Windows.Forms.Panel panelGold;
        private System.Windows.Forms.Panel panelYellow;
        private System.Windows.Forms.Panel panelGray;
        private System.Windows.Forms.Panel panelRed;
        private System.Windows.Forms.Panel panelBlue;
        private System.Windows.Forms.Panel panelWhite;
        private System.Windows.Forms.Panel panelGreen;
        private System.Windows.Forms.Panel panelBlack;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}