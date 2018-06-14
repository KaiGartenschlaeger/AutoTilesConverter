namespace AutoTilesConverter.Dialogs
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnPickFile = new System.Windows.Forms.Button();
            this.lblSource = new System.Windows.Forms.Label();
            this.spcImages = new System.Windows.Forms.SplitContainer();
            this.sourceTileset = new AutoTilesConverter.Controls.TilesetSelector();
            this.pbxOutput = new System.Windows.Forms.PictureBox();
            this.cbxFormat = new System.Windows.Forms.ComboBox();
            this.nudMaxWidth = new System.Windows.Forms.NumericUpDown();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spcImages)).BeginInit();
            this.spcImages.Panel1.SuspendLayout();
            this.spcImages.Panel2.SuspendLayout();
            this.spcImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source file";
            // 
            // btnPickFile
            // 
            this.btnPickFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFile.Location = new System.Drawing.Point(726, 28);
            this.btnPickFile.Name = "btnPickFile";
            this.btnPickFile.Size = new System.Drawing.Size(46, 22);
            this.btnPickFile.TabIndex = 1;
            this.btnPickFile.Text = "...";
            this.btnPickFile.UseVisualStyleBackColor = true;
            this.btnPickFile.Click += new System.EventHandler(this.btnPickFile_Click);
            // 
            // lblSource
            // 
            this.lblSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSource.Location = new System.Drawing.Point(12, 28);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(708, 22);
            this.lblSource.TabIndex = 2;
            this.lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spcImages
            // 
            this.spcImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spcImages.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spcImages.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcImages.Location = new System.Drawing.Point(12, 88);
            this.spcImages.Name = "spcImages";
            // 
            // spcImages.Panel1
            // 
            this.spcImages.Panel1.AutoScroll = true;
            this.spcImages.Panel1.Controls.Add(this.sourceTileset);
            // 
            // spcImages.Panel2
            // 
            this.spcImages.Panel2.AutoScroll = true;
            this.spcImages.Panel2.Controls.Add(this.pbxOutput);
            this.spcImages.Panel2.Click += new System.EventHandler(this.spcImages_Panel2_Click);
            this.spcImages.Size = new System.Drawing.Size(760, 424);
            this.spcImages.SplitterDistance = 296;
            this.spcImages.SplitterWidth = 8;
            this.spcImages.TabIndex = 3;
            // 
            // sourceTileset
            // 
            this.sourceTileset.Location = new System.Drawing.Point(0, 0);
            this.sourceTileset.Name = "sourceTileset";
            this.sourceTileset.SingleTileMode = false;
            this.sourceTileset.Size = new System.Drawing.Size(100, 100);
            this.sourceTileset.TabIndex = 0;
            this.sourceTileset.TileSize = new System.Drawing.Size(32, 32);
            // 
            // pbxOutput
            // 
            this.pbxOutput.Location = new System.Drawing.Point(0, 0);
            this.pbxOutput.Name = "pbxOutput";
            this.pbxOutput.Size = new System.Drawing.Size(100, 100);
            this.pbxOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxOutput.TabIndex = 1;
            this.pbxOutput.TabStop = false;
            this.pbxOutput.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbxOutput_MouseClick);
            // 
            // cbxFormat
            // 
            this.cbxFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFormat.FormattingEnabled = true;
            this.cbxFormat.Location = new System.Drawing.Point(12, 56);
            this.cbxFormat.Name = "cbxFormat";
            this.cbxFormat.Size = new System.Drawing.Size(612, 21);
            this.cbxFormat.TabIndex = 4;
            this.cbxFormat.SelectedIndexChanged += new System.EventHandler(this.cbxFormat_SelectedIndexChanged);
            // 
            // nudMaxWidth
            // 
            this.nudMaxWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMaxWidth.Location = new System.Drawing.Point(659, 57);
            this.nudMaxWidth.Name = "nudMaxWidth";
            this.nudMaxWidth.Size = new System.Drawing.Size(113, 20);
            this.nudMaxWidth.TabIndex = 5;
            this.nudMaxWidth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudMaxWidth.ValueChanged += new System.EventHandler(this.nudMaxWidth_ValueChanged);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Location = new System.Drawing.Point(606, 521);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(80, 28);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(692, 521);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 28);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.nudMaxWidth);
            this.Controls.Add(this.cbxFormat);
            this.Controls.Add(this.spcImages);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.btnPickFile);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoTiles Converter";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.spcImages.Panel1.ResumeLayout(false);
            this.spcImages.Panel2.ResumeLayout(false);
            this.spcImages.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcImages)).EndInit();
            this.spcImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPickFile;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.SplitContainer spcImages;
        private System.Windows.Forms.PictureBox pbxOutput;
        private System.Windows.Forms.ComboBox cbxFormat;
        private Controls.TilesetSelector sourceTileset;
        private System.Windows.Forms.NumericUpDown nudMaxWidth;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnSave;
    }
}

