namespace ReadFromEventLog
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
      this.LicenseListView = new System.Windows.Forms.ListView();
      this.CloseButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // LicenseListView
      // 
      this.LicenseListView.Location = new System.Drawing.Point(45, 73);
      this.LicenseListView.Name = "LicenseListView";
      this.LicenseListView.Size = new System.Drawing.Size(567, 305);
      this.LicenseListView.TabIndex = 0;
      this.LicenseListView.UseCompatibleStateImageBehavior = false;
      // 
      // CloseButton
      // 
      this.CloseButton.Location = new System.Drawing.Point(776, 418);
      this.CloseButton.Name = "CloseButton";
      this.CloseButton.Size = new System.Drawing.Size(95, 23);
      this.CloseButton.TabIndex = 1;
      this.CloseButton.Text = "Close";
      this.CloseButton.UseVisualStyleBackColor = true;
      this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(883, 453);
      this.Controls.Add(this.CloseButton);
      this.Controls.Add(this.LicenseListView);
      this.Name = "Form1";
      this.Text = "License Event Log Viewer";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView LicenseListView;
    private System.Windows.Forms.Button CloseButton;
  }
}

