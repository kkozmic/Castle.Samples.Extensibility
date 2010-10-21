namespace EventBrokerSample.UI.UI
{
    partial class Input
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Publisher = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Publisher
            // 
            this.Publisher.Location = new System.Drawing.Point(4, 4);
            this.Publisher.Name = "Publisher";
            this.Publisher.Size = new System.Drawing.Size(75, 23);
            this.Publisher.TabIndex = 0;
            this.Publisher.Text = "Publish Message";
            this.Publisher.UseVisualStyleBackColor = true;
            this.Publisher.Click += new System.EventHandler(this.Publisher_Click);
            // 
            // Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Publisher);
            this.Name = "Input";
            this.Size = new System.Drawing.Size(96, 47);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Publisher;
    }
}
