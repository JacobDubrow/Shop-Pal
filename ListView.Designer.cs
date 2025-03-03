namespace CODE_PROJECT
{
    partial class ListView
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.AddItem = new System.Windows.Forms.Button();
            this.ClearList = new System.Windows.Forms.Button();
            this.LeaveList = new System.Windows.Forms.Button();
            this.MarkPurchased = new System.Windows.Forms.Button();
            this.ShareList = new System.Windows.Forms.Button();
            this.ImportList = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(228, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shared List View";
            // 
            // listBoxItems
            // 
            this.listBoxItems.BackColor = System.Drawing.Color.Lavender;
            this.listBoxItems.ForeColor = System.Drawing.Color.Navy;
            this.listBoxItems.FormattingEnabled = true;
            this.listBoxItems.Location = new System.Drawing.Point(127, 123);
            this.listBoxItems.Name = "listBoxItems";
            this.listBoxItems.Size = new System.Drawing.Size(524, 186);
            this.listBoxItems.TabIndex = 2;
            this.listBoxItems.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // AddItem
            // 
            this.AddItem.BackColor = System.Drawing.Color.Navy;
            this.AddItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddItem.ForeColor = System.Drawing.Color.White;
            this.AddItem.Location = new System.Drawing.Point(127, 82);
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(89, 35);
            this.AddItem.TabIndex = 3;
            this.AddItem.Text = "Add Item";
            this.AddItem.UseVisualStyleBackColor = false;
            this.AddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // ClearList
            // 
            this.ClearList.BackColor = System.Drawing.Color.Navy;
            this.ClearList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ClearList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearList.ForeColor = System.Drawing.Color.White;
            this.ClearList.Location = new System.Drawing.Point(467, 82);
            this.ClearList.Name = "ClearList";
            this.ClearList.Size = new System.Drawing.Size(89, 35);
            this.ClearList.TabIndex = 4;
            this.ClearList.Text = "Clear List";
            this.ClearList.UseVisualStyleBackColor = false;
            this.ClearList.Click += new System.EventHandler(this.ClearList_Click);
            // 
            // LeaveList
            // 
            this.LeaveList.BackColor = System.Drawing.Color.Navy;
            this.LeaveList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LeaveList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeaveList.ForeColor = System.Drawing.Color.White;
            this.LeaveList.Location = new System.Drawing.Point(562, 82);
            this.LeaveList.Name = "LeaveList";
            this.LeaveList.Size = new System.Drawing.Size(89, 35);
            this.LeaveList.TabIndex = 5;
            this.LeaveList.Text = "Leave List";
            this.LeaveList.UseVisualStyleBackColor = false;
            this.LeaveList.Click += new System.EventHandler(this.LeaveList_Click);
            // 
            // MarkPurchased
            // 
            this.MarkPurchased.BackColor = System.Drawing.Color.Navy;
            this.MarkPurchased.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MarkPurchased.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MarkPurchased.ForeColor = System.Drawing.Color.White;
            this.MarkPurchased.Location = new System.Drawing.Point(222, 82);
            this.MarkPurchased.Name = "MarkPurchased";
            this.MarkPurchased.Size = new System.Drawing.Size(169, 35);
            this.MarkPurchased.TabIndex = 6;
            this.MarkPurchased.Text = "Mark Item Purchased";
            this.MarkPurchased.UseVisualStyleBackColor = false;
            this.MarkPurchased.Click += new System.EventHandler(this.MarkPurchased_Click);
            // 
            // ShareList
            // 
            this.ShareList.BackColor = System.Drawing.Color.Navy;
            this.ShareList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShareList.ForeColor = System.Drawing.Color.White;
            this.ShareList.Location = new System.Drawing.Point(744, 59);
            this.ShareList.Name = "ShareList";
            this.ShareList.Size = new System.Drawing.Size(52, 35);
            this.ShareList.TabIndex = 8;
            this.ShareList.Text = "Share List";
            this.ShareList.UseVisualStyleBackColor = false;
            this.ShareList.Click += new System.EventHandler(this.ShareList_Click);
            // 
            // ImportList
            // 
            this.ImportList.BackColor = System.Drawing.Color.Navy;
            this.ImportList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ImportList.ForeColor = System.Drawing.Color.White;
            this.ImportList.Location = new System.Drawing.Point(744, 100);
            this.ImportList.Name = "ImportList";
            this.ImportList.Size = new System.Drawing.Size(52, 35);
            this.ImportList.TabIndex = 9;
            this.ImportList.Text = "Import List";
            this.ImportList.UseVisualStyleBackColor = false;
            this.ImportList.Click += new System.EventHandler(this.ImportList_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CODE_PROJECT.Properties.Resources.seifuhsdfd;
            this.pictureBox3.Location = new System.Drawing.Point(-28, -6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(878, 464);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Lavender;
            this.pictureBox2.Image = global::CODE_PROJECT.Properties.Resources._6570292;
            this.pictureBox2.Location = new System.Drawing.Point(744, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(52, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // ListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ImportList);
            this.Controls.Add(this.ShareList);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.MarkPurchased);
            this.Controls.Add(this.LeaveList);
            this.Controls.Add(this.ClearList);
            this.Controls.Add(this.AddItem);
            this.Controls.Add(this.listBoxItems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Name = "ListView";
            this.Text = "ListView";
            this.Load += new System.EventHandler(this.ListView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxItems;
        private System.Windows.Forms.Button AddItem;
        private System.Windows.Forms.Button ClearList;
        private System.Windows.Forms.Button LeaveList;
        private System.Windows.Forms.Button MarkPurchased;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button ShareList;
        private System.Windows.Forms.Button ImportList;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}