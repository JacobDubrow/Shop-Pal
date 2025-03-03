namespace CODE_PROJECT
{
    partial class Home
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
            this.CreateList = new System.Windows.Forms.Button();
            this.JoinMessage = new System.Windows.Forms.Button();
            this.ListList = new System.Windows.Forms.DomainUpDown();
            this.OpenList = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // CreateList
            // 
            this.CreateList.BackColor = System.Drawing.Color.Black;
            this.CreateList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateList.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.CreateList.Location = new System.Drawing.Point(21, 90);
            this.CreateList.Name = "CreateList";
            this.CreateList.Size = new System.Drawing.Size(206, 35);
            this.CreateList.TabIndex = 1;
            this.CreateList.Text = "Create New Shopping List";
            this.CreateList.UseVisualStyleBackColor = false;
            this.CreateList.Click += new System.EventHandler(this.CreateList_Click);
            // 
            // JoinMessage
            // 
            this.JoinMessage.BackColor = System.Drawing.Color.Black;
            this.JoinMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JoinMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoinMessage.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.JoinMessage.Location = new System.Drawing.Point(697, 90);
            this.JoinMessage.Name = "JoinMessage";
            this.JoinMessage.Size = new System.Drawing.Size(80, 35);
            this.JoinMessage.TabIndex = 2;
            this.JoinMessage.Text = "Join List";
            this.JoinMessage.UseVisualStyleBackColor = false;
            this.JoinMessage.Click += new System.EventHandler(this.JoinMessage_Click);
            // 
            // ListList
            // 
            this.ListList.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ListList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListList.Location = new System.Drawing.Point(261, 212);
            this.ListList.Name = "ListList";
            this.ListList.Size = new System.Drawing.Size(276, 16);
            this.ListList.TabIndex = 5;
            this.ListList.Text = "No lists at the moment (Create one!)";
            this.ListList.SelectedItemChanged += new System.EventHandler(this.ListList_SelectedItemChanged);
            // 
            // OpenList
            // 
            this.OpenList.BackColor = System.Drawing.Color.Black;
            this.OpenList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenList.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.OpenList.Location = new System.Drawing.Point(346, 266);
            this.OpenList.Name = "OpenList";
            this.OpenList.Size = new System.Drawing.Size(91, 35);
            this.OpenList.TabIndex = 6;
            this.OpenList.Text = "Open List";
            this.OpenList.UseVisualStyleBackColor = false;
            this.OpenList.Click += new System.EventHandler(this.OpenList_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CODE_PROJECT.Properties.Resources.backkkkk;
            this.pictureBox2.Location = new System.Drawing.Point(-3, -3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(809, 456);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Location = new System.Drawing.Point(298, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 62);
            this.label1.TabIndex = 8;
            this.label1.Text = "Home Page";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OpenList);
            this.Controls.Add(this.ListList);
            this.Controls.Add(this.JoinMessage);
            this.Controls.Add(this.CreateList);
            this.Controls.Add(this.pictureBox2);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CreateList;
        private System.Windows.Forms.Button JoinMessage;
        private System.Windows.Forms.DomainUpDown ListList;
        private System.Windows.Forms.Button OpenList;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
    }
}