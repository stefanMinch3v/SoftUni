namespace CatchTheButtonReal
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
            this.ButtonMouseEnter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonMouseEnter
            // 
            this.ButtonMouseEnter.BackColor = System.Drawing.SystemColors.Highlight;
            this.ButtonMouseEnter.Cursor = System.Windows.Forms.Cursors.Default;
            this.ButtonMouseEnter.Location = new System.Drawing.Point(580, 249);
            this.ButtonMouseEnter.Name = "ButtonMouseEnter";
            this.ButtonMouseEnter.Size = new System.Drawing.Size(81, 24);
            this.ButtonMouseEnter.TabIndex = 0;
            this.ButtonMouseEnter.Text = "Catch me";
            this.ButtonMouseEnter.UseVisualStyleBackColor = false;
            this.ButtonMouseEnter.Click += new System.EventHandler(this.ButtonMouseEnter_Click);
            this.ButtonMouseEnter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseEnter_MouseClick);
            this.ButtonMouseEnter.MouseHover += new System.EventHandler(this.ButtonMouseEnter_MouseHover);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 543);
            this.Controls.Add(this.ButtonMouseEnter);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonMouseEnter;
    }
}

