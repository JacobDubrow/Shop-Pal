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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CreateList = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ListList = new System.Windows.Forms.DomainUpDown();
            this.OpenList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Mongolian Baiti", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Navy;
            this.textBox1.Location = new System.Drawing.Point(21, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(369, 41);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "List Home Page";
            // 
            // CreateList
            // 
            this.CreateList.BackColor = System.Drawing.Color.SkyBlue;
            this.CreateList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateList.Location = new System.Drawing.Point(21, 90);
            this.CreateList.Name = "CreateList";
            this.CreateList.Size = new System.Drawing.Size(206, 35);
            this.CreateList.TabIndex = 1;
            this.CreateList.Text = "Create New Shopping List";
            this.CreateList.UseVisualStyleBackColor = false;
            this.CreateList.Click += new System.EventHandler(this.CreateList_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SkyBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(697, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "Join List";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CODE_PROJECT.Properties.Resources.waves;
            this.pictureBox1.Location = new System.Drawing.Point(-19, 273);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(840, 199);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // ListList
            // 
            this.ListList.Location = new System.Drawing.Point(274, 174);
            this.ListList.Name = "ListList";
            this.ListList.Size = new System.Drawing.Size(276, 20);
            this.ListList.TabIndex = 5;
            this.ListList.Text = "List 1";
            this.ListList.SelectedItemChanged += new System.EventHandler(this.ListList_SelectedItemChanged);
            // 
            // OpenList
            // 
            this.OpenList.BackColor = System.Drawing.Color.SkyBlue;
            this.OpenList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenList.Location = new System.Drawing.Point(360, 208);
            this.OpenList.Name = "OpenList";
            this.OpenList.Size = new System.Drawing.Size(91, 35);
            this.OpenList.TabIndex = 6;
            this.OpenList.Text = "Open List";
            this.OpenList.UseVisualStyleBackColor = false;
            this.OpenList.Click += new System.EventHandler(this.OpenList_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OpenList);
            this.Controls.Add(this.ListList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.CreateList);
            this.Controls.Add(this.textBox1);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button CreateList;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DomainUpDown ListList;
        private System.Windows.Forms.Button OpenList;
    }
}