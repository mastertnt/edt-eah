namespace EDT_EAH
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
            this.Manage = new System.Windows.Forms.Button();
            this.DisplayStudent = new System.Windows.Forms.Button();
            this.DisplayTeachers = new System.Windows.Forms.Button();
            this.Compute = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Manage
            // 
            this.Manage.Location = new System.Drawing.Point(32, 27);
            this.Manage.Name = "Manage";
            this.Manage.Size = new System.Drawing.Size(117, 60);
            this.Manage.TabIndex = 0;
            this.Manage.Text = "Paramétrer...";
            this.Manage.UseVisualStyleBackColor = true;
            this.Manage.Click += new System.EventHandler(this.Manage_Click);
            // 
            // DisplayStudent
            // 
            this.DisplayStudent.Location = new System.Drawing.Point(32, 201);
            this.DisplayStudent.Name = "DisplayStudent";
            this.DisplayStudent.Size = new System.Drawing.Size(117, 60);
            this.DisplayStudent.TabIndex = 1;
            this.DisplayStudent.Text = "Afficher planning élèves";
            this.DisplayStudent.UseVisualStyleBackColor = true;
            this.DisplayStudent.Click += new System.EventHandler(this.DisplayStudent_Click);
            // 
            // DisplayTeachers
            // 
            this.DisplayTeachers.Location = new System.Drawing.Point(32, 289);
            this.DisplayTeachers.Name = "DisplayTeachers";
            this.DisplayTeachers.Size = new System.Drawing.Size(117, 62);
            this.DisplayTeachers.TabIndex = 2;
            this.DisplayTeachers.Text = "Afficher planning profs";
            this.DisplayTeachers.UseVisualStyleBackColor = true;
            this.DisplayTeachers.Click += new System.EventHandler(this.DisplayTeachers_Click);
            // 
            // Compute
            // 
            this.Compute.Location = new System.Drawing.Point(32, 110);
            this.Compute.Name = "Compute";
            this.Compute.Size = new System.Drawing.Size(117, 60);
            this.Compute.TabIndex = 3;
            this.Compute.Text = "Calculer";
            this.Compute.UseVisualStyleBackColor = true;
            this.Compute.Click += new System.EventHandler(this.Compute_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EDT_EAH.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(179, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(322, 324);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 361);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Compute);
            this.Controls.Add(this.DisplayTeachers);
            this.Controls.Add(this.DisplayStudent);
            this.Controls.Add(this.Manage);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(540, 400);
            this.MinimumSize = new System.Drawing.Size(540, 400);
            this.Name = "Form1";
            this.Text = "Empoi du temps EAH";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Manage;
        private System.Windows.Forms.Button DisplayStudent;
        private System.Windows.Forms.Button DisplayTeachers;
        private System.Windows.Forms.Button Compute;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

