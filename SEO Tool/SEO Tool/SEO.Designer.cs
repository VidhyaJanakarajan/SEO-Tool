namespace SEO_Tool
{
    partial class SEO
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
            this.SEOData = new System.Windows.Forms.DataGridView();
            this.bWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.SEOData)).BeginInit();
            this.SuspendLayout();
            // 
            // SEOData
            // 
            this.SEOData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SEOData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SEOData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SEOData.Location = new System.Drawing.Point(0, 0);
            this.SEOData.Name = "SEOData";
            this.SEOData.Size = new System.Drawing.Size(800, 450);
            this.SEOData.TabIndex = 0;
            // 
            // bWorker
            // 
            this.bWorker.WorkerReportsProgress = true;
            this.bWorker.WorkerSupportsCancellation = true;
            this.bWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWorker_DoWork_1);
            this.bWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bWorker_ProgressChanged);
            // 
            // SEO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SEOData);
            this.Name = "SEO";
            this.Text = "SEO Tool";
            this.Load += new System.EventHandler(this.SEO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SEOData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView SEOData;
        private System.ComponentModel.BackgroundWorker bWorker;
    }
}

