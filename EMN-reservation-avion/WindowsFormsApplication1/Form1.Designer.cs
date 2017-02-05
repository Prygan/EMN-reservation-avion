namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblClient = new System.Windows.Forms.Label();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.btnEnvoyer = new System.Windows.Forms.Button();
            this.btnDepiler = new System.Windows.Forms.Button();
            this.txtContenu = new System.Windows.Forms.TextBox();
            this.lblContenu = new System.Windows.Forms.Label();
            this.lblVol = new System.Windows.Forms.Label();
            this.txtVol = new System.Windows.Forms.TextBox();
            this.lblHotel = new System.Windows.Forms.Label();
            this.txtHotel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(13, 13);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(39, 13);
            this.lblClient.TabIndex = 0;
            this.lblClient.Text = "Client :";
            // 
            // txtClient
            // 
            this.txtClient.Location = new System.Drawing.Point(95, 10);
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(100, 20);
            this.txtClient.TabIndex = 1;
            // 
            // btnEnvoyer
            // 
            this.btnEnvoyer.Location = new System.Drawing.Point(219, 7);
            this.btnEnvoyer.Name = "btnEnvoyer";
            this.btnEnvoyer.Size = new System.Drawing.Size(75, 23);
            this.btnEnvoyer.TabIndex = 2;
            this.btnEnvoyer.Text = "Envoyer";
            this.btnEnvoyer.UseVisualStyleBackColor = true;
            this.btnEnvoyer.Click += new System.EventHandler(this.btnEnvoyer_Click);
            // 
            // btnDepiler
            // 
            this.btnDepiler.Location = new System.Drawing.Point(321, 7);
            this.btnDepiler.Name = "btnDepiler";
            this.btnDepiler.Size = new System.Drawing.Size(75, 23);
            this.btnDepiler.TabIndex = 3;
            this.btnDepiler.Text = "Depiler";
            this.btnDepiler.UseVisualStyleBackColor = true;
            this.btnDepiler.Click += new System.EventHandler(this.btnDepiler_Click);
            // 
            // txtContenu
            // 
            this.txtContenu.Location = new System.Drawing.Point(107, 163);
            this.txtContenu.Name = "txtContenu";
            this.txtContenu.Size = new System.Drawing.Size(435, 20);
            this.txtContenu.TabIndex = 4;
            // 
            // lblContenu
            // 
            this.lblContenu.AutoSize = true;
            this.lblContenu.Location = new System.Drawing.Point(13, 166);
            this.lblContenu.Name = "lblContenu";
            this.lblContenu.Size = new System.Drawing.Size(88, 13);
            this.lblContenu.TabIndex = 5;
            this.lblContenu.Text = "Contenu Queue :";
            // 
            // lblVol
            // 
            this.lblVol.AutoSize = true;
            this.lblVol.Location = new System.Drawing.Point(13, 53);
            this.lblVol.Name = "lblVol";
            this.lblVol.Size = new System.Drawing.Size(28, 13);
            this.lblVol.TabIndex = 6;
            this.lblVol.Text = "Vol :";
            // 
            // txtVol
            // 
            this.txtVol.Location = new System.Drawing.Point(95, 53);
            this.txtVol.Name = "txtVol";
            this.txtVol.Size = new System.Drawing.Size(100, 20);
            this.txtVol.TabIndex = 7;
            // 
            // lblHotel
            // 
            this.lblHotel.AutoSize = true;
            this.lblHotel.Location = new System.Drawing.Point(13, 96);
            this.lblHotel.Name = "lblHotel";
            this.lblHotel.Size = new System.Drawing.Size(41, 13);
            this.lblHotel.TabIndex = 8;
            this.lblHotel.Text = "Hotel : ";
            // 
            // txtHotel
            // 
            this.txtHotel.Location = new System.Drawing.Point(95, 93);
            this.txtHotel.Name = "txtHotel";
            this.txtHotel.Size = new System.Drawing.Size(100, 20);
            this.txtHotel.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 389);
            this.Controls.Add(this.txtHotel);
            this.Controls.Add(this.lblHotel);
            this.Controls.Add(this.txtVol);
            this.Controls.Add(this.lblVol);
            this.Controls.Add(this.lblContenu);
            this.Controls.Add(this.txtContenu);
            this.Controls.Add(this.btnDepiler);
            this.Controls.Add(this.btnEnvoyer);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.lblClient);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Button btnEnvoyer;
        private System.Windows.Forms.Button btnDepiler;
        private System.Windows.Forms.TextBox txtContenu;
        private System.Windows.Forms.Label lblContenu;
        private System.Windows.Forms.Label lblVol;
        private System.Windows.Forms.TextBox txtVol;
        private System.Windows.Forms.Label lblHotel;
        private System.Windows.Forms.TextBox txtHotel;
    }
}

