namespace Magazin_online_de_telefoane_3
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
            this.AdaugareTelefon = new System.Windows.Forms.Button();
            this.AfisareTelefon = new System.Windows.Forms.Button();
            this.StalvareTelefon = new System.Windows.Forms.Button();
            this.buttonIncarcare = new System.Windows.Forms.Button();
            this.labelCautare = new System.Windows.Forms.Label();
            this.textBoxCautare = new System.Windows.Forms.TextBox();
            this.buttonC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AdaugareTelefon
            // 
            this.AdaugareTelefon.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.AdaugareTelefon.Location = new System.Drawing.Point(46, 251);
            this.AdaugareTelefon.Name = "AdaugareTelefon";
            this.AdaugareTelefon.Size = new System.Drawing.Size(149, 23);
            this.AdaugareTelefon.TabIndex = 0;
            this.AdaugareTelefon.Text = "Adaugare Telefon ";
            this.AdaugareTelefon.UseVisualStyleBackColor = false;
            this.AdaugareTelefon.Click += new System.EventHandler(this.AdaugareTelefon_Click);
            // 
            // AfisareTelefon
            // 
            this.AfisareTelefon.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.AfisareTelefon.Location = new System.Drawing.Point(46, 309);
            this.AfisareTelefon.Name = "AfisareTelefon";
            this.AfisareTelefon.Size = new System.Drawing.Size(149, 23);
            this.AfisareTelefon.TabIndex = 1;
            this.AfisareTelefon.Text = "Afisare Telefon ";
            this.AfisareTelefon.UseVisualStyleBackColor = false;
            this.AfisareTelefon.Click += new System.EventHandler(this.AfisareTelefon_Click);
            // 
            // StalvareTelefon
            // 
            this.StalvareTelefon.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.StalvareTelefon.Location = new System.Drawing.Point(46, 280);
            this.StalvareTelefon.Name = "StalvareTelefon";
            this.StalvareTelefon.Size = new System.Drawing.Size(149, 23);
            this.StalvareTelefon.TabIndex = 2;
            this.StalvareTelefon.Text = "Salvare Telefon";
            this.StalvareTelefon.UseVisualStyleBackColor = false;
            this.StalvareTelefon.Click += new System.EventHandler(this.StalvareTelefon_Click);
            // 
            // buttonIncarcare
            // 
            this.buttonIncarcare.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonIncarcare.Location = new System.Drawing.Point(46, 339);
            this.buttonIncarcare.Name = "buttonIncarcare";
            this.buttonIncarcare.Size = new System.Drawing.Size(149, 23);
            this.buttonIncarcare.TabIndex = 3;
            this.buttonIncarcare.Text = "Refresh";
            this.buttonIncarcare.UseVisualStyleBackColor = false;
            this.buttonIncarcare.Click += new System.EventHandler(this.buttonIncarcare_Click);
            // 
            // labelCautare
            // 
            this.labelCautare.AutoSize = true;
            this.labelCautare.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelCautare.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelCautare.Location = new System.Drawing.Point(338, 258);
            this.labelCautare.Name = "labelCautare";
            this.labelCautare.Size = new System.Drawing.Size(53, 16);
            this.labelCautare.TabIndex = 5;
            this.labelCautare.Text = "Search:";
            // 
            // textBoxCautare
            // 
            this.textBoxCautare.Location = new System.Drawing.Point(424, 252);
            this.textBoxCautare.Name = "textBoxCautare";
            this.textBoxCautare.Size = new System.Drawing.Size(294, 22);
            this.textBoxCautare.TabIndex = 6;
            // 
            // buttonC
            // 
            this.buttonC.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonC.Location = new System.Drawing.Point(424, 292);
            this.buttonC.Name = "buttonC";
            this.buttonC.Size = new System.Drawing.Size(165, 21);
            this.buttonC.TabIndex = 7;
            this.buttonC.Text = "Cauta";
            this.buttonC.UseVisualStyleBackColor = false;
            this.buttonC.Click += new System.EventHandler(this.buttonC_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 450);
            this.Controls.Add(this.buttonC);
            this.Controls.Add(this.textBoxCautare);
            this.Controls.Add(this.labelCautare);
            this.Controls.Add(this.buttonIncarcare);
            this.Controls.Add(this.StalvareTelefon);
            this.Controls.Add(this.AfisareTelefon);
            this.Controls.Add(this.AdaugareTelefon);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AdaugareTelefon;
        private System.Windows.Forms.Button AfisareTelefon;
        private System.Windows.Forms.Button StalvareTelefon;
        private System.Windows.Forms.TextBox textBoxBrand;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.TextBox textBoxPret;
        private System.Windows.Forms.TextBox textBoxDescriere;
        private System.Windows.Forms.CheckBox checkBoxStoc;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.Label labelBrand;
        private System.Windows.Forms.Label labelPret;
        private System.Windows.Forms.Label labelStoc;
        private System.Windows.Forms.Label labelDescriere;
        private System.Windows.Forms.Button Salvare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelModel1;
        private System.Windows.Forms.Label labelBrand1;
        private System.Windows.Forms.Label labelPret1;
        private System.Windows.Forms.Label labelSpecificatii;
        private System.Windows.Forms.Button buttonIncarcare;
        private System.Windows.Forms.Label labelStoc1;
        private System.Windows.Forms.Label labelCautare;
        private System.Windows.Forms.TextBox textBoxCautare;
        private System.Windows.Forms.Button buttonC;
    }
}

