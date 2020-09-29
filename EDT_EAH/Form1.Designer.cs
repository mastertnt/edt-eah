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
            this.Manage = new MaterialSkin.Controls.MaterialFlatButton();
            this.DisplayStudent = new MaterialSkin.Controls.MaterialFlatButton();
            this.DisplayTeachers = new MaterialSkin.Controls.MaterialFlatButton();
            this.Compute = new MaterialSkin.Controls.MaterialFlatButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Manage
            // 
            this.Manage.AutoSize = true;
            this.Manage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Manage.Depth = 0;
            this.Manage.Icon = null;
            this.Manage.Location = new System.Drawing.Point(32, 88);
            this.Manage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Manage.MouseState = MaterialSkin.MouseState.HOVER;
            this.Manage.Name = "Manage";
            this.Manage.Primary = false;
            this.Manage.Size = new System.Drawing.Size(121, 36);
            this.Manage.TabIndex = 0;
            this.Manage.Text = "Paramétrer...";
            this.Manage.UseVisualStyleBackColor = true;
            this.Manage.Click += new System.EventHandler(this.Manage_Click);
            // 
            // DisplayStudent
            // 
            this.DisplayStudent.AutoSize = true;
            this.DisplayStudent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DisplayStudent.Depth = 0;
            this.DisplayStudent.Icon = null;
            this.DisplayStudent.Location = new System.Drawing.Point(32, 265);
            this.DisplayStudent.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DisplayStudent.MouseState = MaterialSkin.MouseState.HOVER;
            this.DisplayStudent.Name = "DisplayStudent";
            this.DisplayStudent.Primary = false;
            this.DisplayStudent.Size = new System.Drawing.Size(207, 36);
            this.DisplayStudent.TabIndex = 1;
            this.DisplayStudent.Text = "Afficher planning élèves";
            this.DisplayStudent.UseVisualStyleBackColor = true;
            this.DisplayStudent.Click += new System.EventHandler(this.DisplayStudent_Click);
            // 
            // DisplayTeachers
            // 
            this.DisplayTeachers.AutoSize = true;
            this.DisplayTeachers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DisplayTeachers.Depth = 0;
            this.DisplayTeachers.Icon = null;
            this.DisplayTeachers.Location = new System.Drawing.Point(32, 363);
            this.DisplayTeachers.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DisplayTeachers.MouseState = MaterialSkin.MouseState.HOVER;
            this.DisplayTeachers.Name = "DisplayTeachers";
            this.DisplayTeachers.Primary = false;
            this.DisplayTeachers.Size = new System.Drawing.Size(201, 36);
            this.DisplayTeachers.TabIndex = 2;
            this.DisplayTeachers.Text = "Afficher planning profs";
            this.DisplayTeachers.UseVisualStyleBackColor = true;
            this.DisplayTeachers.Click += new System.EventHandler(this.DisplayTeachers_Click);
            // 
            // Compute
            // 
            this.Compute.AutoSize = true;
            this.Compute.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Compute.Depth = 0;
            this.Compute.Icon = null;
            this.Compute.Location = new System.Drawing.Point(32, 180);
            this.Compute.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Compute.MouseState = MaterialSkin.MouseState.HOVER;
            this.Compute.Name = "Compute";
            this.Compute.Primary = false;
            this.Compute.Size = new System.Drawing.Size(160, 36);
            this.Compute.TabIndex = 3;
            this.Compute.Text = "Elaborer planning";
            this.Compute.UseVisualStyleBackColor = true;
            this.Compute.Click += new System.EventHandler(this.Compute_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::EDT_EAH.Properties.Resources.chsf;
            this.pictureBox3.Location = new System.Drawing.Point(433, 88);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(255, 136);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::EDT_EAH.Properties.Resources.acver_2017_bleu_region_acad;
            this.pictureBox2.Location = new System.Drawing.Point(282, 230);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(406, 195);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EDT_EAH.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(282, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 440);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Compute);
            this.Controls.Add(this.DisplayTeachers);
            this.Controls.Add(this.DisplayStudent);
            this.Controls.Add(this.Manage);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 700);
            this.MinimumSize = new System.Drawing.Size(430, 400);
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "Empoi du temps EAH";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton Manage;
        private MaterialSkin.Controls.MaterialFlatButton DisplayStudent;
        private MaterialSkin.Controls.MaterialFlatButton DisplayTeachers;
        private MaterialSkin.Controls.MaterialFlatButton Compute;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

