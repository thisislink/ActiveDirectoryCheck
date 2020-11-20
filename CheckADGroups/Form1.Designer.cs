namespace CheckADGroups
{
    partial class CheckADGroupsForm
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
            this.userTextbox = new System.Windows.Forms.TextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.AdGroupResultsBox = new System.Windows.Forms.RichTextBox();
            this.dropdownBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // userTextbox
            // 
            this.userTextbox.Location = new System.Drawing.Point(170, 45);
            this.userTextbox.Name = "userTextbox";
            this.userTextbox.Size = new System.Drawing.Size(142, 20);
            this.userTextbox.TabIndex = 0;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(9, 48);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(155, 13);
            this.userLabel.TabIndex = 1;
            this.userLabel.Text = "Enter user 7-letter or AD Group:";
            // 
            // SearchButton
            // 
            this.SearchButton.AutoSize = true;
            this.SearchButton.Location = new System.Drawing.Point(318, 43);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(106, 23);
            this.SearchButton.TabIndex = 3;
            this.SearchButton.Text = "Search AD Groups";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // AdGroupResultsBox
            // 
            this.AdGroupResultsBox.Location = new System.Drawing.Point(12, 80);
            this.AdGroupResultsBox.Name = "AdGroupResultsBox";
            this.AdGroupResultsBox.ReadOnly = true;
            this.AdGroupResultsBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.AdGroupResultsBox.Size = new System.Drawing.Size(412, 346);
            this.AdGroupResultsBox.TabIndex = 4;
            this.AdGroupResultsBox.Text = "";
            // 
            // dropdownBox
            // 
            this.dropdownBox.FormattingEnabled = true;
            this.dropdownBox.ItemHeight = 13;
            this.dropdownBox.Items.AddRange(new object[] {
            "Find ADGroups by UserID (7-letter)",
            "Find Users by ADGroup Name"});
            this.dropdownBox.Location = new System.Drawing.Point(12, 12);
            this.dropdownBox.Name = "dropdownBox";
            this.dropdownBox.Size = new System.Drawing.Size(142, 21);
            this.dropdownBox.TabIndex = 5;
            this.dropdownBox.Text = "Select Search Type";
            this.dropdownBox.SelectedIndexChanged += new System.EventHandler(this.dropdownBox_Resize);
            // 
            // CheckADGroupsForm
            // 
            this.AcceptButton = this.SearchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 450);
            this.Controls.Add(this.dropdownBox);
            this.Controls.Add(this.AdGroupResultsBox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.userTextbox);
            this.KeyPreview = true;
            this.Name = "CheckADGroupsForm";
            this.Text = "Admin - Check User AD Groups";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userTextbox;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.RichTextBox AdGroupResultsBox;
        private System.Windows.Forms.ComboBox dropdownBox;
    }
}

