namespace CustomListViewExample
{
    partial class Form1
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
            this.btnChangeBorder = new System.Windows.Forms.Button();
            this.btnChangeBlankArea = new System.Windows.Forms.Button();
            this.customListView1 = new CustomListView.CustomListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnChangeBorder
            // 
            this.btnChangeBorder.Location = new System.Drawing.Point(683, 12);
            this.btnChangeBorder.Name = "btnChangeBorder";
            this.btnChangeBorder.Size = new System.Drawing.Size(105, 39);
            this.btnChangeBorder.TabIndex = 1;
            this.btnChangeBorder.Text = "Header Border To Red";
            this.btnChangeBorder.UseVisualStyleBackColor = true;
            this.btnChangeBorder.Click += new System.EventHandler(this.btnChangeBorder_Click);
            // 
            // btnChangeBlankArea
            // 
            this.btnChangeBlankArea.Location = new System.Drawing.Point(683, 57);
            this.btnChangeBlankArea.Name = "btnChangeBlankArea";
            this.btnChangeBlankArea.Size = new System.Drawing.Size(105, 39);
            this.btnChangeBlankArea.TabIndex = 2;
            this.btnChangeBlankArea.Text = "Header Blank Area To Black";
            this.btnChangeBlankArea.UseVisualStyleBackColor = true;
            this.btnChangeBlankArea.Click += new System.EventHandler(this.btnChangeBlankArea_Click);
            // 
            // customListView1
            // 
            this.customListView1.ColumnHeaderAreaColor = System.Drawing.Color.SandyBrown;
            this.customListView1.ColumnHeaderBlankAreaColor = System.Drawing.Color.NavajoWhite;
            this.customListView1.ColumnHeaderBorderColor = System.Drawing.Color.Blue;
            this.customListView1.ColumnHeaderBorderStyle = CustomListView.ColumnHeaderBorderStyle.Rectangle;
            this.customListView1.ColumnHeaderTextColor = System.Drawing.Color.IndianRed;
            this.customListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.customListView1.HideSelection = false;
            this.customListView1.Location = new System.Drawing.Point(12, 12);
            this.customListView1.Name = "customListView1";
            this.customListView1.Size = new System.Drawing.Size(665, 426);
            this.customListView1.TabIndex = 0;
            this.customListView1.UseCompatibleStateImageBehavior = false;
            this.customListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No.";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Title";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Artist";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnChangeBlankArea);
            this.Controls.Add(this.btnChangeBorder);
            this.Controls.Add(this.customListView1);
            this.Name = "Form1";
            this.Text = "Custom ListView Example";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomListView.CustomListView customListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnChangeBorder;
        private System.Windows.Forms.Button btnChangeBlankArea;
    }
}

