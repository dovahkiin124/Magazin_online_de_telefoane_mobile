using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazin_online_de_telefoane_3
{
    public partial class Form1 : Form
    {
        private MagazinulDeTelefoaneMobile _magazin;
        private int PAS_Y = 21;
        private const int MAX_LENGHT = 30;
        private const int MAX_LENGHT1 = 300;
        private HashSet<IDisposable> labels = new HashSet<IDisposable>();
        public Form1(MagazinulDeTelefoaneMobile magazin)
        {
            InitializeComponent();
            _magazin = magazin;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void ButonSalvareClick(object sender, EventArgs e)
        {
            string brand = string.Empty;
            string model = string.Empty;
            int pret = 0;
            bool stoc = true;
            string des = string.Empty;
            


            
            //Model

            if (string.IsNullOrEmpty(textBoxModel.Text))
            {
                MessageBox.Show("Va rugam introduceti modelul inainte de salvare ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBoxModel.Text.Length > MAX_LENGHT)
            {
                MessageBox.Show("Prea lung modelul ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            model = textBoxModel.Text;
            //Brand
            if (string.IsNullOrEmpty(textBoxBrand.Text))
            {
                MessageBox.Show("Va rugam introduceti brandul inainte de salvare ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBoxBrand.Text.Length > MAX_LENGHT)
            {
                MessageBox.Show("Prea lung brandul ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            brand = textBoxBrand.Text;

            //pret
            var result = int.TryParse(textBoxPret.Text, out pret);
            if (!result)
            {
                MessageBox.Show("Va rugam introduceti un numar pentru pret. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxPret.Text))
            {
                MessageBox.Show("Va rugam introduceti pretul inainte de salvare ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            stoc = checkBoxStoc.Checked;

            //Descriere
            if (string.IsNullOrEmpty(textBoxDescriere.Text))
            {
                MessageBox.Show("Va rugam introduceti specificatiile inainte de salvare ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBoxDescriere.Text.Length > MAX_LENGHT1)
            {
                MessageBox.Show("Prea lunga descrierea ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             des= textBoxDescriere.Text;

            
            var nou = new Telefon(model, brand, pret, des, stoc);
            _magazin.Adauga_Telefon(nou);
            MessageBox.Show("Telefonul a fost adaugat ", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CleanItems();
        }
        private void CleanItems()
        {

            foreach (var label in labels)
            {
                label.Dispose();
            }
        }

        private void AdaugareTelefon_Click(object sender, EventArgs e)
        {
            CleanItems();
            this.textBoxBrand = new System.Windows.Forms.TextBox();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.textBoxPret = new System.Windows.Forms.TextBox();
            this.textBoxDescriere = new System.Windows.Forms.TextBox();
            this.checkBoxStoc = new System.Windows.Forms.CheckBox();
            this.labelModel = new System.Windows.Forms.Label();
            this.labelBrand = new System.Windows.Forms.Label();
            this.labelPret = new System.Windows.Forms.Label();
            this.labelStoc = new System.Windows.Forms.Label();
            this.labelDescriere = new System.Windows.Forms.Label();
            this.Salvare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxBrand
            // 
            this.textBoxBrand.Location = new System.Drawing.Point(109, 12);
            this.textBoxBrand.Name = "textBoxBrand";
            this.textBoxBrand.Size = new System.Drawing.Size(196, 22);
            this.textBoxBrand.TabIndex = 3;
            // 
            // textBoxModel
            // 
            this.textBoxModel.Location = new System.Drawing.Point(109, 40);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(196, 22);
            this.textBoxModel.TabIndex = 4;
            // 
            // textBoxPret
            // 
            this.textBoxPret.Location = new System.Drawing.Point(109, 68);
            this.textBoxPret.Name = "textBoxPret";
            this.textBoxPret.Size = new System.Drawing.Size(196, 22);
            this.textBoxPret.TabIndex = 5;
            // 
            // textBoxDescriere
            // 
            this.textBoxDescriere.Location = new System.Drawing.Point(109, 96);
            this.textBoxDescriere.Name = "textBoxDescriere";
            this.textBoxDescriere.Size = new System.Drawing.Size(196, 22);
            this.textBoxDescriere.TabIndex = 6;
            // 
            // checkBoxStoc
            // 
            this.checkBoxStoc.AutoSize = true;
            this.checkBoxStoc.Location = new System.Drawing.Point(112, 124);
            this.checkBoxStoc.Name = "checkBoxStoc";
            this.checkBoxStoc.Size = new System.Drawing.Size(193, 20);
            this.checkBoxStoc.TabIndex = 7;
            this.checkBoxStoc.Text = "Vreti sa-l introduceti in stoc?";
            this.checkBoxStoc.UseVisualStyleBackColor = true;
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Location = new System.Drawing.Point(25, 18);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(45, 16);
            this.labelModel.TabIndex = 8;
            this.labelModel.Text = "Model";
            // 
            // labelBrand
            // 
            this.labelBrand.AutoSize = true;
            this.labelBrand.Location = new System.Drawing.Point(25, 46);
            this.labelBrand.Name = "labelBrand";
            this.labelBrand.Size = new System.Drawing.Size(43, 16);
            this.labelBrand.TabIndex = 9;
            this.labelBrand.Text = "Brand";
            // 
            // labelPret
            // 
            this.labelPret.AutoSize = true;
            this.labelPret.Location = new System.Drawing.Point(25, 74);
            this.labelPret.Name = "labelPret";
            this.labelPret.Size = new System.Drawing.Size(31, 16);
            this.labelPret.TabIndex = 10;
            this.labelPret.Text = "Pret";
            // 
            // labelStoc
            // 
            this.labelStoc.AutoSize = true;
            this.labelStoc.Location = new System.Drawing.Point(25, 128);
            this.labelStoc.Name = "labelStoc";
            this.labelStoc.Size = new System.Drawing.Size(34, 16);
            this.labelStoc.TabIndex = 11;
            this.labelStoc.Text = "Stoc";
            // 
            // labelDescriere
            // 
            this.labelDescriere.AutoSize = true;
            this.labelDescriere.Location = new System.Drawing.Point(25, 102);
            this.labelDescriere.Name = "labelDescriere";
            this.labelDescriere.Size = new System.Drawing.Size(72, 16);
            this.labelDescriere.TabIndex = 12;
            this.labelDescriere.Text = "Specificatii";
            // 
            // Salvare
            // 
            this.Salvare.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Salvare.ImageKey = "(none)";
            this.Salvare.Location = new System.Drawing.Point(112, 168);
            this.Salvare.Name = "Salvare";
            this.Salvare.Size = new System.Drawing.Size(193, 23);
            this.Salvare.TabIndex = 13;
            this.Salvare.Text = "Salvare";
            this.Salvare.UseVisualStyleBackColor = false;
            this.Salvare.Click += new System.EventHandler(this.ButonSalvareClick);


            this.Controls.Add(this.Salvare);
            this.Controls.Add(this.labelDescriere);
            this.Controls.Add(this.labelStoc);
            this.Controls.Add(this.labelPret);
            this.Controls.Add(this.labelBrand);
            this.Controls.Add(this.labelModel);
            this.Controls.Add(this.checkBoxStoc);
            this.Controls.Add(this.textBoxDescriere);
            this.Controls.Add(this.textBoxPret);
            this.Controls.Add(this.textBoxModel);
            this.Controls.Add(this.textBoxBrand);

            this.labels.Add(this.Salvare);
            this.labels.Add(this.labelDescriere);
            this.labels.Add(this.labelStoc);
            this.labels.Add(this.labelPret);
            this.labels.Add(this.labelBrand);
            this.labels.Add(this.labelModel);
            this.labels.Add(this.checkBoxStoc);
            this.labels.Add(this.textBoxDescriere);
            this.labels.Add(this.textBoxPret);
            this.labels.Add(this.textBoxModel);
            this.labels.Add(this.textBoxBrand);
        }

        private void StalvareTelefon_Click(object sender, EventArgs e)
        {
            CleanItems();
            _magazin.SalveazaTelefoane("C:/Users/Asus/Desktop/telefon.txt");
            MessageBox.Show("Toate telefoanele au fost salvate in fisier ", "Succes!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void AfisareTelefon_Click(object sender, EventArgs e)
        {
            this.labelModel1 = new System.Windows.Forms.Label();
            this.labelBrand1 = new System.Windows.Forms.Label();
            this.labelPret1 = new System.Windows.Forms.Label();
            this.labelSpecificatii = new System.Windows.Forms.Label();
            this.labelStoc1 = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // 
            // labelModel1
            // 
            this.labelModel1.AutoSize = true;
            this.labelModel1.Location = new System.Drawing.Point(303, 23);
            this.labelModel1.Name = "labelModel1";
            this.labelModel1.Size = new System.Drawing.Size(45, 16);
            this.labelModel1.TabIndex = 3;
            this.labelModel1.Text = "Model";
            // 
            // labelBrand1
            // 
            this.labelBrand1.AutoSize = true;
            this.labelBrand1.Location = new System.Drawing.Point(395, 23);
            this.labelBrand1.Name = "labelBrand1";
            this.labelBrand1.Size = new System.Drawing.Size(43, 16);
            this.labelBrand1.TabIndex = 4;
            this.labelBrand1.Text = "Brand";
            // 
            // labelPret1
            // 
            this.labelPret1.AutoSize = true;
            this.labelPret1.Location = new System.Drawing.Point(488, 23);
            this.labelPret1.Name = "labelPret1";
            this.labelPret1.Size = new System.Drawing.Size(31, 16);
            this.labelPret1.TabIndex = 5;
            this.labelPret1.Text = "Pret";
            // 
            // labelSpecificatii
            // 
            this.labelSpecificatii.AutoSize = true;
            this.labelSpecificatii.Location = new System.Drawing.Point(587, 23);
            this.labelSpecificatii.Name = "labelSpecificatii";
            this.labelSpecificatii.Size = new System.Drawing.Size(72, 16);
            this.labelSpecificatii.TabIndex = 6;
            this.labelSpecificatii.Text = "Specificatii";
            // 
            // labelStoc1
            // 
            this.labelStoc1.AutoSize = true;
            this.labelStoc1.Location = new System.Drawing.Point(690, 23);
            this.labelStoc1.Name = "labelStoc1";
            this.labelStoc1.Size = new System.Drawing.Size(34, 16);
            this.labelStoc1.TabIndex = 7;
            this.labelStoc1.Text = "Stoc";

            this.Controls.Add(this.labelStoc1);
            this.Controls.Add(this.labelSpecificatii);
            this.Controls.Add(this.labelPret1);
            this.Controls.Add(this.labelBrand1);
            this.Controls.Add(this.labelModel1);

            this.labels.Add(this.labelStoc1);
            this.labels.Add(this.labelSpecificatii);
            this.labels.Add(this.labelPret1);
            this.labels.Add(this.labelBrand1);
            this.labels.Add(this.labelModel1);
            var pas_y_current = PAS_Y;

            foreach (var telefon in _magazin.telefoane)
            {
                this.labelModel1 = new System.Windows.Forms.Label();
                this.labelBrand1 = new System.Windows.Forms.Label();
                this.labelPret1 = new System.Windows.Forms.Label();
                this.labelSpecificatii = new System.Windows.Forms.Label();
                this.labelStoc1 = new System.Windows.Forms.Label();

                this.SuspendLayout();

                // 
                // labelModel1
                // 
                this.labelModel1.AutoSize = true;
                this.labelModel1.Location = new System.Drawing.Point(303, 23 + pas_y_current);
                this.labelModel1.Name = "labelModel1";
                this.labelModel1.Size = new System.Drawing.Size(45, 16 );
                this.labelModel1.TabIndex = 3;
                this.labelModel1.Text = telefon.Brandul;
                // 
                // labelBrand1
                // 
                this.labelBrand1.AutoSize = true;
                this.labelBrand1.Location = new System.Drawing.Point(395, 23 + pas_y_current);
                this.labelBrand1.Name = "labelBrand1";
                this.labelBrand1.Size = new System.Drawing.Size(43, 16 );
                this.labelBrand1.TabIndex = 4;
                this.labelBrand1.Text = telefon.Model;
                // 
                // labelPret1
                // 
                this.labelPret1.AutoSize = true;
                this.labelPret1.Location = new System.Drawing.Point(488, 23 + pas_y_current);
                this.labelPret1.Name = "labelPret1";
                this.labelPret1.Size = new System.Drawing.Size(31, 16);
                this.labelPret1.TabIndex = 5;
                this.labelPret1.Text = telefon.Pret.ToString();
                // 
                // labelSpecificatii
                // 
                this.labelSpecificatii.AutoSize = true;
                this.labelSpecificatii.Location = new System.Drawing.Point(587, 23 + pas_y_current);
                this.labelSpecificatii.Name = "labelSpecificatii";
                this.labelSpecificatii.Size = new System.Drawing.Size(72, 16 );
                this.labelSpecificatii.TabIndex = 6;
                this.labelSpecificatii.Text = telefon.Descriere;
                // 
                // labelStoc1
                // 
                this.labelStoc1.AutoSize = true;
                this.labelStoc1.Location = new System.Drawing.Point(690, 23 + pas_y_current);
                this.labelStoc1.Name = "labelStoc1";
                this.labelStoc1.Size = new System.Drawing.Size(34, 16 );
                this.labelStoc1.TabIndex = 7;
                var x = telefon.Stoc;    
                this.labelStoc1.Text = x?"Da":"Nu";



                this.Controls.Add(this.labelStoc1);
                this.Controls.Add(this.labelSpecificatii);
                this.Controls.Add(this.labelPret1);
                this.Controls.Add(this.labelBrand1);
                this.Controls.Add(this.labelModel1);

                this.labels.Add(this.labelStoc1);
                this.labels.Add(this.labelSpecificatii);
                this.labels.Add(this.labelPret1);
                this.labels.Add(this.labelBrand1);
                this.labels.Add(this.labelModel1);
                pas_y_current += PAS_Y;
            }
        }

        private void buttonIncarcare_Click(object sender, EventArgs e)
        {
            CleanItems();
            _magazin.ReadPhonesFromFile("C:/Users/Asus/Desktop/telefon.txt");
            MessageBox.Show("Toate telefoanele au fost incarcate  din fisier", "Succes!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       
        private void buttonC_Click(object sender, EventArgs e)
        {
            
            var criteria = textBoxCautare.Text;
            CleanItems();
            this.labelCautare = new System.Windows.Forms.Label();
            this.textBoxCautare = new System.Windows.Forms.TextBox();
            this.buttonC = new System.Windows.Forms.Button();
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

            this.Controls.Add(this.buttonC);
            this.Controls.Add(this.textBoxCautare);
            this.Controls.Add(this.labelCautare);

            this.labels.Add(this.buttonC);
            this.labels.Add(this.textBoxCautare);
            this.labels.Add(this.labelCautare);

            this.labelModel1 = new System.Windows.Forms.Label();
            this.labelBrand1 = new System.Windows.Forms.Label();
            this.labelPret1 = new System.Windows.Forms.Label();
            this.labelSpecificatii = new System.Windows.Forms.Label();
            this.labelStoc1 = new System.Windows.Forms.Label();
            // 
            // labelModel1
            // 
            this.labelModel1.AutoSize = true;
            this.labelModel1.Location = new System.Drawing.Point(303, 23);
            this.labelModel1.Name = "labelModel1";
            this.labelModel1.Size = new System.Drawing.Size(45, 16);
            this.labelModel1.TabIndex = 3;
            this.labelModel1.Text = "Model";
            // 
            // labelBrand1
            // 
            this.labelBrand1.AutoSize = true;
            this.labelBrand1.Location = new System.Drawing.Point(395, 23);
            this.labelBrand1.Name = "labelBrand1";
            this.labelBrand1.Size = new System.Drawing.Size(43, 16);
            this.labelBrand1.TabIndex = 4;
            this.labelBrand1.Text = "Brand";
            // 
            // labelPret1
            // 
            this.labelPret1.AutoSize = true;
            this.labelPret1.Location = new System.Drawing.Point(488, 23);
            this.labelPret1.Name = "labelPret1";
            this.labelPret1.Size = new System.Drawing.Size(31, 16);
            this.labelPret1.TabIndex = 5;
            this.labelPret1.Text = "Pret";
            // 
            // labelSpecificatii
            // 
            this.labelSpecificatii.AutoSize = true;
            this.labelSpecificatii.Location = new System.Drawing.Point(587, 23);
            this.labelSpecificatii.Name = "labelSpecificatii";
            this.labelSpecificatii.Size = new System.Drawing.Size(72, 16);
            this.labelSpecificatii.TabIndex = 6;
            this.labelSpecificatii.Text = "Specificatii";
            // 
            // labelStoc1
            // 
            this.labelStoc1.AutoSize = true;
            this.labelStoc1.Location = new System.Drawing.Point(690, 23);
            this.labelStoc1.Name = "labelStoc1";
            this.labelStoc1.Size = new System.Drawing.Size(34, 16);
            this.labelStoc1.TabIndex = 7;
            this.labelStoc1.Text = "Stoc";

            this.Controls.Add(this.labelStoc1);
            this.Controls.Add(this.labelSpecificatii);
            this.Controls.Add(this.labelPret1);
            this.Controls.Add(this.labelBrand1);
            this.Controls.Add(this.labelModel1);

            this.labels.Add(this.labelStoc1);
            this.labels.Add(this.labelSpecificatii);
            this.labels.Add(this.labelPret1);
            this.labels.Add(this.labelBrand1);
            this.labels.Add(this.labelModel1);
            var pas_y_current = PAS_Y;
            foreach (var telefon in _magazin.SearchTelefoane(criteria))
            {
                this.labelModel1 = new System.Windows.Forms.Label();
                this.labelBrand1 = new System.Windows.Forms.Label();
                this.labelPret1 = new System.Windows.Forms.Label();
                this.labelSpecificatii = new System.Windows.Forms.Label();
                this.labelStoc1 = new System.Windows.Forms.Label();

                // 
                // labelModel1
                // 
                this.labelModel1.AutoSize = true;
                this.labelModel1.Location = new System.Drawing.Point(303, 23 + pas_y_current);
                this.labelModel1.Name = "labelModel1";
                this.labelModel1.Size = new System.Drawing.Size(45, 16);
                this.labelModel1.TabIndex = 3;
                this.labelModel1.Text = telefon.Brandul;
                // 
                // labelBrand1
                // 
                this.labelBrand1.AutoSize = true;
                this.labelBrand1.Location = new System.Drawing.Point(395, 23 + pas_y_current);
                this.labelBrand1.Name = "labelBrand1";
                this.labelBrand1.Size = new System.Drawing.Size(43, 16);
                this.labelBrand1.TabIndex = 4;
                this.labelBrand1.Text = telefon.Model;
                // 
                // labelPret1
                // 
                this.labelPret1.AutoSize = true;
                this.labelPret1.Location = new System.Drawing.Point(488, 23 + pas_y_current);
                this.labelPret1.Name = "labelPret1";
                this.labelPret1.Size = new System.Drawing.Size(31, 16);
                this.labelPret1.TabIndex = 5;
                this.labelPret1.Text = telefon.Pret.ToString();
                // 
                // labelSpecificatii
                // 
                this.labelSpecificatii.AutoSize = true;
                this.labelSpecificatii.Location = new System.Drawing.Point(587, 23 + pas_y_current);
                this.labelSpecificatii.Name = "labelSpecificatii";
                this.labelSpecificatii.Size = new System.Drawing.Size(72, 16);
                this.labelSpecificatii.TabIndex = 6;
                this.labelSpecificatii.Text = telefon.Descriere;
                // 
                // labelStoc1
                // 
                this.labelStoc1.AutoSize = true;
                this.labelStoc1.Location = new System.Drawing.Point(690, 23 + pas_y_current);
                this.labelStoc1.Name = "labelStoc1";
                this.labelStoc1.Size = new System.Drawing.Size(34, 16);
                this.labelStoc1.TabIndex = 7;
                var x = telefon.Stoc;
                this.labelStoc1.Text = x ? "Da" : "Nu";



                this.Controls.Add(this.labelStoc1);
                this.Controls.Add(this.labelSpecificatii);
                this.Controls.Add(this.labelPret1);
                this.Controls.Add(this.labelBrand1);
                this.Controls.Add(this.labelModel1);

                this.labels.Add(this.labelStoc1);
                this.labels.Add(this.labelSpecificatii);
                this.labels.Add(this.labelPret1);
                this.labels.Add(this.labelBrand1);
                this.labels.Add(this.labelModel1);
                pas_y_current += PAS_Y;
            }
        }
    }
}
