namespace BlockFlix_Application
{
    partial class GetRatingForm
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
            label = new Label();
            comboBoxRating = new ComboBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(279, 162);
            label.Name = "label";
            label.Size = new Size(50, 20);
            label.TabIndex = 0;
            label.Text = "label1";
            // 
            // comboBoxRating
            // 
            comboBoxRating.FormattingEnabled = true;
            comboBoxRating.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            comboBoxRating.Location = new Point(279, 217);
            comboBoxRating.Name = "comboBoxRating";
            comboBoxRating.Size = new Size(151, 28);
            comboBoxRating.TabIndex = 1;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(237, 291);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(379, 291);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "No Rating";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // GetRatingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(comboBoxRating);
            Controls.Add(label);
            Name = "GetRatingForm";
            Text = "GetRatingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label;
        private ComboBox comboBoxRating;
        private Button buttonSave;
        private Button buttonCancel;
    }
}