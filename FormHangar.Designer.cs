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
            this.buttonSetWarPlane = new System.Windows.Forms.Button();
            this.buttonSetBomber = new System.Windows.Forms.Button();
            this.groupBoxGetWarPlane = new System.Windows.Forms.GroupBox();
            this.maskedTextBoxPlace = new System.Windows.Forms.MaskedTextBox();
            this.labelPlace = new System.Windows.Forms.Label();
            this.buttonGetWarPlane = new System.Windows.Forms.Button();
            this.pictureBoxWarPlane = new System.Windows.Forms.PictureBox();
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
            // buttonSetWarPlane
            // 
            this.buttonSetWarPlane.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonSetWarPlane.Location = new System.Drawing.Point(863, 12);
            this.buttonSetWarPlane.Name = "buttonSetWarPlane";
            this.buttonSetWarPlane.Size = new System.Drawing.Size(137, 48);
            this.buttonSetWarPlane.TabIndex = 1;
            this.buttonSetWarPlane.Text = "Посадить военный самолет";
            this.buttonSetWarPlane.UseVisualStyleBackColor = true;
            this.buttonSetWarPlane.Click += new System.EventHandler(this.ButtonSetWarPlane_Click);
            // 
            // buttonSetBomber
            // 
            this.buttonSetBomber.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonSetBomber.Location = new System.Drawing.Point(863, 66);
            this.buttonSetBomber.Name = "buttonSetBomber";
            this.buttonSetBomber.Size = new System.Drawing.Size(137, 48);
            this.buttonSetBomber.TabIndex = 2;
            this.buttonSetBomber.Text = "Посадить бомбардировщик";
            this.buttonSetBomber.UseVisualStyleBackColor = true;
            this.buttonSetBomber.Click += new System.EventHandler(this.ButtonSetBomber_Click);
            // 
            // groupBoxGetWarPlane
            // 
            this.groupBoxGetWarPlane.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBoxGetWarPlane.Controls.Add(this.pictureBoxWarPlane);
            this.groupBoxGetWarPlane.Controls.Add(this.buttonGetWarPlane);
            this.groupBoxGetWarPlane.Controls.Add(this.labelPlace);
            this.groupBoxGetWarPlane.Controls.Add(this.maskedTextBoxPlace);
            this.groupBoxGetWarPlane.Location = new System.Drawing.Point(863, 292);
            this.groupBoxGetWarPlane.Name = "groupBoxGetWarPlane";
            this.groupBoxGetWarPlane.Size = new System.Drawing.Size(137, 169);
            this.groupBoxGetWarPlane.TabIndex = 3;
            this.groupBoxGetWarPlane.TabStop = false;
            this.groupBoxGetWarPlane.Text = "Забрать самолет";
            // 
            // maskedTextBoxPlace
            // 
            this.maskedTextBoxPlace.Location = new System.Drawing.Point(74, 23);
            this.maskedTextBoxPlace.Name = "maskedTextBoxPlace";
            this.maskedTextBoxPlace.Size = new System.Drawing.Size(35, 20);
            this.maskedTextBoxPlace.TabIndex = 0;
            // 
            // labelPlace
            // 
            this.labelPlace.AutoSize = true;
            this.labelPlace.Location = new System.Drawing.Point(23, 27);
            this.labelPlace.Name = "labelPlace";
            this.labelPlace.Size = new System.Drawing.Size(45, 13);
            this.labelPlace.TabIndex = 1;
            this.labelPlace.Text = "Место: ";
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
            // pictureBoxWarPlane
            // 
            this.pictureBoxWarPlane.Location = new System.Drawing.Point(9, 78);
            this.pictureBoxWarPlane.Name = "pictureBoxWarPlane";
            this.pictureBoxWarPlane.Size = new System.Drawing.Size(122, 80);
            this.pictureBoxWarPlane.TabIndex = 3;
            this.pictureBoxWarPlane.TabStop = false;
            // 
            // FormHangar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 461);
            this.Controls.Add(this.groupBoxGetWarPlane);
            this.Controls.Add(this.buttonSetBomber);
            this.Controls.Add(this.buttonSetWarPlane);
            this.Controls.Add(this.pictureBoxHangar);
            this.Name = "FormHangar";
            this.Text = "Ангар";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHangar)).EndInit();
            this.groupBoxGetWarPlane.ResumeLayout(false);
            this.groupBoxGetWarPlane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarPlane)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxHangar;
        private System.Windows.Forms.Button buttonSetWarPlane;
        private System.Windows.Forms.Button buttonSetBomber;
        private System.Windows.Forms.GroupBox groupBoxGetWarPlane;
        private System.Windows.Forms.PictureBox pictureBoxWarPlane;
        private System.Windows.Forms.Button buttonGetWarPlane;
        private System.Windows.Forms.Label labelPlace;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPlace;
    }
}