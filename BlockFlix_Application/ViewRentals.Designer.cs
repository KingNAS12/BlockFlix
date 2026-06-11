namespace BlockFlix_Application
{
    partial class ViewRentals
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
            label1 = new Label();
            checkBoxActive = new CheckBox();
            checkBoxReturned = new CheckBox();
            checkBoxOverdue = new CheckBox();
            dataGridView1 = new DataGridView();
            buttonCreate = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 26);
            label1.Name = "label1";
            label1.Size = new Size(121, 20);
            label1.TabIndex = 0;
            label1.Text = "All Rental Orders";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // checkBoxActive
            // 
            checkBoxActive.AutoSize = true;
            checkBoxActive.Checked = true;
            checkBoxActive.CheckState = CheckState.Checked;
            checkBoxActive.Location = new Point(47, 70);
            checkBoxActive.Name = "checkBoxActive";
            checkBoxActive.Size = new Size(72, 24);
            checkBoxActive.TabIndex = 1;
            checkBoxActive.Text = "Active";
            checkBoxActive.UseVisualStyleBackColor = true;
            checkBoxActive.CheckedChanged += checkBoxActive_CheckedChanged;
            // 
            // checkBoxReturned
            // 
            checkBoxReturned.AutoSize = true;
            checkBoxReturned.Checked = true;
            checkBoxReturned.CheckState = CheckState.Checked;
            checkBoxReturned.Location = new Point(125, 70);
            checkBoxReturned.Name = "checkBoxReturned";
            checkBoxReturned.Size = new Size(91, 24);
            checkBoxReturned.TabIndex = 2;
            checkBoxReturned.Text = "Returned";
            checkBoxReturned.UseVisualStyleBackColor = true;
            checkBoxReturned.CheckedChanged += checkBoxReturned_CheckedChanged;
            // 
            // checkBoxOverdue
            // 
            checkBoxOverdue.AutoSize = true;
            checkBoxOverdue.Checked = true;
            checkBoxOverdue.CheckState = CheckState.Checked;
            checkBoxOverdue.Location = new Point(238, 70);
            checkBoxOverdue.Name = "checkBoxOverdue";
            checkBoxOverdue.Size = new Size(87, 24);
            checkBoxOverdue.TabIndex = 3;
            checkBoxOverdue.Text = "Overdue";
            checkBoxOverdue.UseVisualStyleBackColor = true;
            checkBoxOverdue.CheckedChanged += checkBoxOverdue_CheckedChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 100);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1750, 746);
            dataGridView1.TabIndex = 4;
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(358, 65);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(179, 29);
            buttonCreate.TabIndex = 5;
            buttonCreate.Text = "+ Create New Rental";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // ViewRentals
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1774, 858);
            Controls.Add(buttonCreate);
            Controls.Add(dataGridView1);
            Controls.Add(checkBoxOverdue);
            Controls.Add(checkBoxReturned);
            Controls.Add(checkBoxActive);
            Controls.Add(label1);
            Name = "ViewRentals";
            Text = "ViewRentals";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CheckBox checkBoxActive;
        private CheckBox checkBoxReturned;
        private CheckBox checkBoxOverdue;
        private DataGridView dataGridView1;
        private Button buttonCreate;
    }
}