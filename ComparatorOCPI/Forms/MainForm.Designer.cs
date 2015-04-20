namespace ComparatorOCPI.Forms
{
    partial class MainForm
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
            this.uxCsvOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.uxWiresharkOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.uxGetCsvFile = new System.Windows.Forms.Button();
            this.uxGetWiresharkFile = new System.Windows.Forms.Button();
            this.uxClose = new System.Windows.Forms.Button();
            this.uxCompareFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxCsvOpenFile
            // 
            this.uxCsvOpenFile.Filter = "Csv | *.csv|Wszystkie pliki|*.*";
            // 
            // uxWiresharkOpenFile
            // 
            this.uxWiresharkOpenFile.Filter = "Wireshark | *.pcapng|Wszystkie pliki|*.*";
            // 
            // uxGetCsvFile
            // 
            this.uxGetCsvFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxGetCsvFile.Location = new System.Drawing.Point(12, 12);
            this.uxGetCsvFile.Name = "uxGetCsvFile";
            this.uxGetCsvFile.Size = new System.Drawing.Size(143, 60);
            this.uxGetCsvFile.TabIndex = 0;
            this.uxGetCsvFile.Text = "Wybierz plik Csv";
            this.uxGetCsvFile.UseVisualStyleBackColor = true;
            this.uxGetCsvFile.Click += new System.EventHandler(this.uxGetCsvFile_Click);
            // 
            // uxGetWiresharkFile
            // 
            this.uxGetWiresharkFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxGetWiresharkFile.Location = new System.Drawing.Point(162, 12);
            this.uxGetWiresharkFile.Name = "uxGetWiresharkFile";
            this.uxGetWiresharkFile.Size = new System.Drawing.Size(143, 60);
            this.uxGetWiresharkFile.TabIndex = 1;
            this.uxGetWiresharkFile.Text = "Wybierz plik z Wireshark";
            this.uxGetWiresharkFile.UseVisualStyleBackColor = true;
            this.uxGetWiresharkFile.Click += new System.EventHandler(this.uxGetWiresharkFile_Click);
            // 
            // uxClose
            // 
            this.uxClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxClose.Location = new System.Drawing.Point(12, 144);
            this.uxClose.Name = "uxClose";
            this.uxClose.Size = new System.Drawing.Size(293, 60);
            this.uxClose.TabIndex = 2;
            this.uxClose.Text = "Zamknij";
            this.uxClose.UseVisualStyleBackColor = true;
            this.uxClose.Click += new System.EventHandler(this.uxClose_Click);
            // 
            // uxCompareFiles
            // 
            this.uxCompareFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxCompareFiles.Location = new System.Drawing.Point(12, 78);
            this.uxCompareFiles.Name = "uxCompareFiles";
            this.uxCompareFiles.Size = new System.Drawing.Size(293, 60);
            this.uxCompareFiles.TabIndex = 3;
            this.uxCompareFiles.Text = "Porównaj pliki i wygeneruj csv";
            this.uxCompareFiles.UseVisualStyleBackColor = true;
            this.uxCompareFiles.Click += new System.EventHandler(this.uxCompareFiles_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.uxClose;
            this.ClientSize = new System.Drawing.Size(317, 214);
            this.Controls.Add(this.uxCompareFiles);
            this.Controls.Add(this.uxClose);
            this.Controls.Add(this.uxGetWiresharkFile);
            this.Controls.Add(this.uxGetCsvFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Porównywarka plików";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog uxCsvOpenFile;
        private System.Windows.Forms.OpenFileDialog uxWiresharkOpenFile;
        private System.Windows.Forms.Button uxGetCsvFile;
        private System.Windows.Forms.Button uxGetWiresharkFile;
        private System.Windows.Forms.Button uxClose;
        private System.Windows.Forms.Button uxCompareFiles;
    }
}

