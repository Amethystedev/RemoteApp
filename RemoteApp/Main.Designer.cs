namespace RemoteApp
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            DGV_Applications = new DataGridView();
            Application = new DataGridViewTextBoxColumn();
            CheminApplication = new DataGridViewTextBoxColumn();
            Cle = new DataGridViewTextBoxColumn();
            btn_add = new Button();
            btn_edit = new Button();
            btn_remove = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_Applications).BeginInit();
            SuspendLayout();
            // 
            // DGV_Applications
            // 
            DGV_Applications.AllowUserToAddRows = false;
            DGV_Applications.AllowUserToDeleteRows = false;
            DGV_Applications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Applications.Columns.AddRange(new DataGridViewColumn[] { Application, CheminApplication, Cle });
            DGV_Applications.Location = new Point(31, 16);
            DGV_Applications.MultiSelect = false;
            DGV_Applications.Name = "DGV_Applications";
            DGV_Applications.ReadOnly = true;
            DGV_Applications.RowHeadersWidth = 62;
            DGV_Applications.Size = new Size(582, 401);
            DGV_Applications.TabIndex = 0;
            // 
            // Application
            // 
            Application.HeaderText = "Application";
            Application.MinimumWidth = 8;
            Application.Name = "Application";
            Application.ReadOnly = true;
            Application.Width = 250;
            // 
            // CheminApplication
            // 
            CheminApplication.HeaderText = "Chemin Application";
            CheminApplication.MinimumWidth = 8;
            CheminApplication.Name = "CheminApplication";
            CheminApplication.ReadOnly = true;
            CheminApplication.Width = 250;
            // 
            // Cle
            // 
            Cle.HeaderText = "Cle";
            Cle.MinimumWidth = 8;
            Cle.Name = "Cle";
            Cle.ReadOnly = true;
            Cle.Visible = false;
            Cle.Width = 150;
            // 
            // btn_add
            // 
            btn_add.Image = (Image)resources.GetObject("btn_add.Image");
            btn_add.Location = new Point(637, 37);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(112, 40);
            btn_add.TabIndex = 1;
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // btn_edit
            // 
            btn_edit.Image = (Image)resources.GetObject("btn_edit.Image");
            btn_edit.Location = new Point(640, 98);
            btn_edit.Name = "btn_edit";
            btn_edit.Size = new Size(112, 40);
            btn_edit.TabIndex = 2;
            btn_edit.UseVisualStyleBackColor = true;
            btn_edit.Click += btn_edit_Click;
            // 
            // btn_remove
            // 
            btn_remove.Image = (Image)resources.GetObject("btn_remove.Image");
            btn_remove.Location = new Point(646, 164);
            btn_remove.Name = "btn_remove";
            btn_remove.Size = new Size(112, 40);
            btn_remove.TabIndex = 3;
            btn_remove.UseVisualStyleBackColor = true;
            btn_remove.Click += btn_remove_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_remove);
            Controls.Add(btn_edit);
            Controls.Add(btn_add);
            Controls.Add(DGV_Applications);
            Name = "Main";
            Text = "RemoteApp Main";
            Activated += Main_Activated;
            ((System.ComponentModel.ISupportInitialize)DGV_Applications).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGV_Applications;
        private Button btn_add;
        private Button btn_edit;
        private Button btn_remove;
        private DataGridViewTextBoxColumn Application;
        private DataGridViewTextBoxColumn CheminApplication;
        private DataGridViewTextBoxColumn Cle;
    }
}
