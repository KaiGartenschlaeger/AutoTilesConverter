namespace AutoTilesConverter.Controls
{
    partial class TilesetSelector
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxTileset = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileset)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxTileset
            // 
            this.pictureBoxTileset.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTileset.Name = "pictureBoxTileset";
            this.pictureBoxTileset.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxTileset.TabIndex = 1;
            this.pictureBoxTileset.TabStop = false;
            this.pictureBoxTileset.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxTileset_Paint);
            this.pictureBoxTileset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTileset_MouseDown);
            this.pictureBoxTileset.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTileset_MouseMove);
            this.pictureBoxTileset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTileset_MouseUp);
            // 
            // TilesetSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxTileset);
            this.Name = "TilesetSelector";
            this.Size = new System.Drawing.Size(48, 49);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxTileset;
    }
}
