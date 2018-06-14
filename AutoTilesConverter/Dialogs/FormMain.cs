using AutoTilesConverter.Formats;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace AutoTilesConverter.Dialogs
{
    public partial class FormMain : Form
    {
        #region Fields

        private readonly FormatRepository _formats;

        #endregion

        #region Constructor

        public FormMain()
        {
            InitializeComponent();

            _formats = new FormatRepository();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _formats.InitFormats();

            cbxFormat.DisplayMember = "Name";

            foreach (var format in _formats.Formats)
            {
                cbxFormat.Items.Add(format);
            }

            if (cbxFormat.Items.Count > 0)
                cbxFormat.SelectedIndex = 0;
        }

        #endregion

        #region Helper

        private ConverterFormat GetSelectedFormat()
        {
            return cbxFormat.SelectedItem as ConverterFormat;
        }

        private void LoadSourceImage(string fileName, ConverterFormat format)
        {
            Image image = Image.FromFile(fileName);

            if (image.Width % format.FrameWidth != 0)
                throw new Exception($"The source image has an invalid width. The width must be dividable by {format.FrameWidth}");
            if (image.Height % format.FrameHeight != 0)
                throw new Exception($"The source image has an invalid height. The height must be dividable by {format.FrameHeight}");

            sourceTileset.SourceImage = image;
            sourceTileset.Size = image.Size;
        }

        #endregion

        #region Control events

        private void cbxFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedFormat = GetSelectedFormat();
            if (selectedFormat == null)
                return;

            sourceTileset.SingleTileMode = true;
            sourceTileset.TileSize = new Size(
                selectedFormat.FrameWidth, selectedFormat.FrameHeight);

            nudMaxWidth.Value = selectedFormat.OptimalWidth;

            Convert();
        }

        private void pbxOutput_MouseClick(object sender, MouseEventArgs e)
        {
            Convert();
        }

        private void spcImages_Panel2_Click(object sender, EventArgs e)
        {
            Convert();
        }

        private void nudMaxWidth_ValueChanged(object sender, EventArgs e)
        {
            Convert();
        }

        private void Convert()
        {
            var selectedFormat = cbxFormat.SelectedItem as ConverterFormat;
            if (selectedFormat == null)
                return;

            var sourceImage = sourceTileset.SourceImage;
            if (sourceImage == null)
                return;

            var canvasTilesCountX = 0;
            var canvasTilesCountY = 0;

            if (nudMaxWidth.Value == 0)
            {
                canvasTilesCountX = canvasTilesCountY = (int)Math.Ceiling(Math.Sqrt(selectedFormat.Rules.Count));
            }
            else
            {
                canvasTilesCountX = (int)nudMaxWidth.Value;
                if (canvasTilesCountX > selectedFormat.Rules.Count)
                    canvasTilesCountX = selectedFormat.Rules.Count;

                canvasTilesCountY = (int)Math.Ceiling((float)selectedFormat.Rules.Count / canvasTilesCountX);
            }

            var canvas = new Bitmap(
                canvasTilesCountX * selectedFormat.TileWidth,
                canvasTilesCountY * selectedFormat.TileHeight);

            canvas.SetResolution(
                sourceImage.HorizontalResolution,
                sourceImage.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(canvas))
            {
                graphics.Clear(Color.Transparent);

                int tileX = 0;
                int tileY = 0;

                foreach (var rule in selectedFormat.Rules)
                {
                    int tileXInternal = 0;
                    int tileYInternal = 0;

                    for (int tileIndex = 0; tileIndex < 4; tileIndex++)
                    {
                        var index = rule.SourceIndexes[tileIndex];

                        var x = (rule.SourceIndexes[tileIndex] - 1) % selectedFormat.TilesCountXInternal;
                        var y = (rule.SourceIndexes[tileIndex] - 1) / selectedFormat.TilesCountXInternal;

                        var src = new Rectangle(
                            sourceTileset.Selection.X + (x * selectedFormat.TileWidthInternal),
                            sourceTileset.Selection.Y + (y * selectedFormat.TileHeightInternal),
                            selectedFormat.TileWidthInternal,
                            selectedFormat.TileHeightInternal);

                        var dst = new Rectangle(
                            tileX * selectedFormat.TileWidth + tileXInternal * selectedFormat.TileWidthInternal,
                            tileY * selectedFormat.TileHeight + tileYInternal * selectedFormat.TileHeightInternal,
                            selectedFormat.TileWidthInternal,
                            selectedFormat.TileHeightInternal);

                        graphics.DrawImage(sourceTileset.SourceImage, dst, src, GraphicsUnit.Pixel);

                        tileXInternal++;
                        if (tileXInternal + 1 > 2)
                        {
                            tileXInternal = 0;
                            tileYInternal++;
                        }
                    }

                    tileX++;
                    if (tileX + 1 > canvasTilesCountX)
                    {
                        tileX = 0;
                        tileY++;
                    }
                }
            }

            pbxOutput.Image = canvas;
        }

        private void ResetImages()
        {
            sourceTileset.SourceImage = null;
            sourceTileset.Size = new Size(10, 10);

            pbxOutput.Image = null;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (pbxOutput.Image == null)
                return;

            Clipboard.SetImage(pbxOutput.Image);

            MessageBox.Show("The output image has been copied to the clipboard", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pbxOutput.Image == null)
                return;

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Save output";
                dialog.Filter = "PNG Image|*.png|BMP Image|*.bmp";
                dialog.FileName = Path.GetFileNameWithoutExtension(lblSource.Text) + "_Output";

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        switch (dialog.FilterIndex)
                        {
                            case 1:
                                pbxOutput.Image.Save(dialog.FileName, ImageFormat.Png);
                                break;
                            case 2:
                                pbxOutput.Image.Save(dialog.FileName, ImageFormat.Bmp);
                                break;

                            default:
                                throw new NotImplementedException();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to save the output file.\n\n" + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnPickFile_Click(object sender, EventArgs e)
        {
            var selectedFormat = GetSelectedFormat();
            if (selectedFormat == null)
                return;

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Choose source file";
                dialog.Filter = "Image formats|*.png;*.bmp|All files|*.*";

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        LoadSourceImage(dialog.FileName, selectedFormat);
                        lblSource.Text = dialog.FileName;
                    }
                    catch (Exception ex)
                    {
                        ResetImages();

                        MessageBox.Show(ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion
    }
}