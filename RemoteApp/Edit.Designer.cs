namespace RemoteApp
{
    partial class Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Edit));
            tb_app = new TextBox();
            btn_valid = new Button();
            btn_file_explore = new Button();
            openFileDialog1 = new OpenFileDialog();
            tb_cheminapp = new TextBox();
            SuspendLayout();
            // 
            // tb_app
            // 
            tb_app.Location = new Point(35, 32);
            tb_app.Name = "tb_app";
            tb_app.ReadOnly = true;
            tb_app.Size = new Size(515, 31);
            tb_app.TabIndex = 0;
            // 
            // btn_valid
            // 
            btn_valid.Image = (Image)resources.GetObject("btn_valid.Image");
            btn_valid.Location = new Point(614, 49);
            btn_valid.Name = "btn_valid";
            btn_valid.Size = new Size(112, 40);
            btn_valid.TabIndex = 1;
            btn_valid.UseVisualStyleBackColor = true;
            // 
            // btn_file_explore
            // 
            btn_file_explore.Location = new Point(556, 86);
            btn_file_explore.Name = "btn_file_explore";
            btn_file_explore.Size = new Size(36, 40);
            btn_file_explore.TabIndex = 2;
            btn_file_explore.Text = "...";
            btn_file_explore.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // tb_cheminapp
            // 
            tb_cheminapp.Location = new Point(35, 91);
            tb_cheminapp.Name = "tb_cheminapp";
            tb_cheminapp.ReadOnly = true;
            tb_cheminapp.Size = new Size(515, 31);
            tb_cheminapp.TabIndex = 3;
            // 
            // Edit
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(748, 179);
            Controls.Add(tb_cheminapp);
            Controls.Add(btn_file_explore);
            Controls.Add(btn_valid);
            Controls.Add(tb_app);
            Name = "Edit";
            Text = "Edit Application";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_app;
        private Button btn_valid;
        private Button btn_file_explore;
        private OpenFileDialog openFileDialog1;
        private TextBox tb_cheminapp;
    }
}