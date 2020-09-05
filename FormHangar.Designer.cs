namespace WindowsFormsBomber
{
    partial class FormHangar
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
            this.pictureBoxHangar = new System.Windows.Forms.PictureBox();
            this.groupBoxGetWarPlane = new System.Windows.Forms.GroupBox();
            this.pictureBoxWarPlane = new System.Windows.Forms.PictureBox();
            this.buttonGetWarPlane = new System.Windows.Forms.Button();
            this.labelPlace = new System.Windows.Forms.Label();
            this.maskedTextBoxPlace = new System.Windows.Forms.MaskedTextBox();
            this.labelLevels = new System.Windows.Forms.Label();
            this.listBoxLevels = new System.Windows.Forms.ListBox();
            this.buttonSetWarPlane = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHangar)).BeginInit();
            this.groupBoxGetWarPlane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarPlane)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxHangar
            // 
            this.pictureBoxHangar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxHangar.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxHangar.Name = "pictureBoxHangar";
            this.pictureBoxHangar.Size = new System.Drawing.Size(859, 461);
            this.pictureBoxHangar.TabIndex = 0;
            this.pictureBoxHangar.TabStop = false;
            // 
            // groupBoxGetWarPlane
            // 
            this.groupBoxGetWarPlane.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBoxGetWarPlane.Controls.Add(this.pictureBoxWarPlane);
            this.groupBoxGetWarPlane.Controls.Add(this.buttonGetWarPlane);
            this.groupBoxGetWarPlane.Controls.Add(this.labelPlace);
            this.groupBoxGetWarPlane.Controls.Add(this.maskedTextBoxPlace);
            this.groupBoxGetWarPlane.Location = new System.Drawing.Point(863, 280);
            this.groupBoxGetWarPlane.Name = "groupBoxGetWarPlane";
            this.groupBoxGetWarPlane.Size = new System.Drawing.Size(137, 169);
            this.groupBoxGetWarPlane.TabIndex = 3;
            this.groupBoxGetWarPlane.TabStop = false;
            this.groupBoxGetWarPlane.Text = "Забрать самолет";
            // pictureBoxWarPlane
            // 
            this.pictureBoxWarPlane.Location = new System.Drawing.Point(9, 78);
            this.pictureBoxWarPlane.Name = "pictureBoxWarPlane";
            this.pictureBoxWarPlane.Size = new System.Drawing.Size(122, 80);
            this.pictureBoxWarPlane.TabIndex = 3;
            this.pictureBoxWarPlane.TabStop = false;
            // 
            // buttonGetWarPlane
            // 
            this.buttonGetWarPlane.Location = new System.Drawing.Point(34, 49);
            this.buttonGetWarPlane.Name = "buttonGetWarPlane";
            this.buttonGetWarPlane.Size = new System.Drawing.Size(75, 23);
            this.buttonGetWarPlane.TabIndex = 2;
            this.buttonGetWarPlane.Text = "Забрать";
            this.buttonGetWarPlane.UseVisualStyleBackColor = true;
            this.buttonGetWarPlane.Click += new System.EventHandler(this.ButtonGetWarPlane_Click);
            // 
            // labelPlace
            // 
            this.labelPlace.AutoSize = true;
            this.labelPlace.Location = new System.Drawing.Point(23, 27);
            this.labelPlace.Name = "labelPlace";
            this.labelPlace.Size = new System.Drawing.Size(45, 13);
            this.labelPlace.TabIndex = 1;
            this.labelPlace.Text = "Место: ";
            // maskedTextBoxPlace
            // 
            this.maskedTextBoxPlace.Location = new System.Drawing.Point(74, 23);
            this.maskedTextBoxPlace.Name = "maskedTextBoxPlace";
            this.maskedTextBoxPlace.Size = new System.Drawing.Size(35, 20);
            this.maskedTextBoxPlace.TabIndex = 0;
            // 
            // labelLevels
            // 
            this.labelLevels.AutoSize = true;
            this.labelLevels.Location = new System.Drawing.Point(911, 9);
            this.labelLevels.Name = "labelLevels";
            this.labelLevels.Size = new System.Drawing.Size(48, 13);
            this.labelLevels.TabIndex = 4;
            this.labelLevels.Text = "Уровни:";
            // 
            // listBoxLevels
            // 
            this.listBoxLevels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLevels.FormattingEnabled = true;
            this.listBoxLevels.Location = new System.Drawing.Point(865, 28);
            this.listBoxLevels.Name = "listBoxLevels";
            this.listBoxLevels.Size = new System.Drawing.Size(136, 95);
            this.listBoxLevels.TabIndex = 5;
            this.listBoxLevels.SelectedIndexChanged += new System.EventHandler(this.listBoxLevels_SelectedIndexChanged);
            // 
            // buttonSetWarPlane
            // 
            this.buttonSetWarPlane.Location = new System.Drawing.Point(865, 129);
            this.buttonSetWarPlane.Name = "buttonSetWarPlane";
            this.buttonSetWarPlane.Size = new System.Drawing.Size(136, 38);
            this.buttonSetWarPlane.TabIndex = 6;
            this.buttonSetWarPlane.Text = "Заказать военный самолет";
            this.buttonSetWarPlane.UseVisualStyleBackColor = true;
            this.buttonSetWarPlane.Click += new System.EventHandler(this.buttonSetWarPlane_Click);
            // 
            // FormHangar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 461);
            this.Controls.Add(this.buttonSetWarPlane);
            this.Controls.Add(this.listBoxLevels);
            this.Controls.Add(this.labelLevels);
            this.Controls.Add(this.groupBoxGetWarPlane);
            this.Controls.Add(this.pictureBoxHangar);
            this.Name = "FormHangar";
            this.Text = "Ангар";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHangar)).EndInit();
            this.groupBoxGetWarPlane.ResumeLayout(false);
            this.groupBoxGetWarPlane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarPlane)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxHangar;
        private System.Windows.Forms.GroupBox groupBoxGetWarPlane;
        private System.Windows.Forms.PictureBox pictureBoxWarPlane;
        private System.Windows.Forms.Button buttonGetWarPlane;
        private System.Windows.Forms.Label labelPlace;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPlace;
        private System.Windows.Forms.Label labelLevels;
        private System.Windows.Forms.ListBox listBoxLevels;
        private System.Windows.Forms.Button buttonSetWarPlane;
    }
}