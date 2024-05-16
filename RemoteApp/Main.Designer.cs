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
            components = new System.ComponentModel.Container();
            DGV_Applications = new DataGridView();
            Application = new DataGridViewTextBoxColumn();
            CheminApplication = new DataGridViewTextBoxColumn();
            Cle = new DataGridViewTextBoxColumn();
            btn_add = new Button();
            btn_edit = new Button();
            btn_remove = new Button();
            lbl_ip = new Label();
            label1 = new Label();
            pb_rdp = new PictureBox();
            tt_info_rdpuser = new ToolTip(components);
            lbl_version = new Label();
            ((System.ComponentModel.ISupportInitialize)DGV_Applications).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_rdp).BeginInit();
            SuspendLayout();
            // 
            // DGV_Applications
            // 
            DGV_Applications.AllowUserToAddRows = false;
            DGV_Applications.AllowUserToDeleteRows = false;
            DGV_Applications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            Application.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Application.HeaderText = "Application Name";
            Application.MinimumWidth = 8;
            Application.Name = "Application";
            Application.ReadOnly = true;
            // 
            // CheminApplication
            // 
            CheminApplication.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CheminApplication.HeaderText = "Application Exe";
            CheminApplication.MinimumWidth = 8;
            CheminApplication.Name = "CheminApplication";
            CheminApplication.ReadOnly = true;
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
            btn_add.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_add.BackgroundImage = Properties.Resources.plus;
            btn_add.BackgroundImageLayout = ImageLayout.Center;
            btn_add.Location = new Point(637, 92);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(112, 40);
            btn_add.TabIndex = 1;
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // btn_edit
            // 
            btn_edit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_edit.BackgroundImage = Properties.Resources.edit;
            btn_edit.BackgroundImageLayout = ImageLayout.Center;
            btn_edit.Location = new Point(637, 158);
            btn_edit.Name = "btn_edit";
            btn_edit.Size = new Size(112, 40);
            btn_edit.TabIndex = 2;
            btn_edit.UseVisualStyleBackColor = true;
            btn_edit.Click += btn_edit_Click;
            // 
            // btn_remove
            // 
            btn_remove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_remove.BackgroundImage = Properties.Resources.moins;
            btn_remove.BackgroundImageLayout = ImageLayout.Center;
            btn_remove.Location = new Point(637, 222);
            btn_remove.Name = "btn_remove";
            btn_remove.Size = new Size(112, 40);
            btn_remove.TabIndex = 3;
            btn_remove.UseVisualStyleBackColor = true;
            btn_remove.Click += btn_remove_Click;
            // 
            // lbl_ip
            // 
            lbl_ip.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_ip.AutoSize = true;
            lbl_ip.Location = new Point(637, 392);
            lbl_ip.Name = "lbl_ip";
            lbl_ip.Size = new Size(53, 25);
            lbl_ip.TabIndex = 4;
            lbl_ip.Text = "lbl_ip";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(642, 17);
            label1.Name = "label1";
            label1.Size = new Size(99, 25);
            label1.TabIndex = 5;
            label1.Text = "Active RDP";
            // 
            // pb_rdp
            // 
            pb_rdp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pb_rdp.BackgroundImageLayout = ImageLayout.Center;
            pb_rdp.Location = new Point(684, 47);
            pb_rdp.Name = "pb_rdp";
            pb_rdp.Size = new Size(34, 34);
            pb_rdp.TabIndex = 6;
            pb_rdp.TabStop = false;
            pb_rdp.Click += pb_rdp_Click;
            pb_rdp.MouseHover += pb_rdp_MouseHover;
            // 
            // lbl_version
            // 
            lbl_version.AutoSize = true;
            lbl_version.Location = new Point(8, 422);
            lbl_version.Name = "lbl_version";
            lbl_version.Size = new Size(47, 25);
            lbl_version.TabIndex = 7;
            lbl_version.Text = "V0.1";
            lbl_version.Click += lbl_version_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_version);
            Controls.Add(pb_rdp);
            Controls.Add(label1);
            Controls.Add(lbl_ip);
            Controls.Add(btn_remove);
            Controls.Add(btn_edit);
            Controls.Add(btn_add);
            Controls.Add(DGV_Applications);
            MinimumSize = new Size(822, 506);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            Activated += Main_Activated;
            ((System.ComponentModel.ISupportInitialize)DGV_Applications).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_rdp).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGV_Applications;
        private Button btn_add;
        private Button btn_edit;
        private Button btn_remove;
        private Label lbl_ip;
        private Label label1;
        private PictureBox pb_rdp;
        private DataGridViewTextBoxColumn Application;
        private DataGridViewTextBoxColumn CheminApplication;
        private DataGridViewTextBoxColumn Cle;
        private ToolTip tt_info_rdpuser;
        private Label lbl_version;
    }
}
