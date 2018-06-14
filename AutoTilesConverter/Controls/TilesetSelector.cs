using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AutoTilesConverter.Controls
{
    public partial class TilesetSelector : UserControl
    {
        #region Fields

        // properties

        private Image m_sourceImage;
        private bool m_singleTileMode;
        private Size m_tileSize;
        private Rectangle m_selection;

        // internal helper

        private bool m_mouseDown;
        private int m_startX, m_startY, m_selX, m_selY, m_selWidth, m_selHeight;

        #endregion

        #region Constructor

        public TilesetSelector()
        {
            InitializeComponent();

            m_sourceImage = null;
            m_singleTileMode = false;
            m_tileSize = new Size(32, 32);
            m_selection = Rectangle.Empty;

            m_mouseDown = false;
        }

        #endregion

        #region Control events

        private void pictureBoxTileset_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !m_mouseDown)
            {
                m_mouseDown = true;

                m_startX = (e.X / m_tileSize.Width) * m_tileSize.Width;
                m_startY = (e.Y / m_tileSize.Height) * m_tileSize.Height;

                m_selX = m_startX;
                m_selY = m_startY;
                m_selWidth = m_tileSize.Width;
                m_selHeight = m_tileSize.Height;

                SelectedTiles = new Rectangle(
                    (e.X / m_tileSize.Width) * (m_tileSize.Width / m_tileSize.Width),
                    (e.Y / m_tileSize.Height) * (m_tileSize.Height / m_tileSize.Height),
                    m_tileSize.Width / m_tileSize.Width,
                    m_tileSize.Height / m_tileSize.Height);

                pictureBoxTileset.Refresh();
            }
        }

        private void pictureBoxTileset_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_mouseDown = false;
            }
        }

        private void pictureBoxTileset_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left
                && !m_singleTileMode
                && m_mouseDown
                && e.X >= 0 && e.X < pictureBoxTileset.Width
                && e.Y >= 0 && e.Y < pictureBoxTileset.Height)
            {
                int endX = (e.X / m_tileSize.Width) * m_tileSize.Width;
                int endY = (e.Y / m_tileSize.Height) * m_tileSize.Height;

                if (m_startX < endX)
                {
                    m_selX = m_startX;
                    m_selWidth = m_tileSize.Width + endX - m_startX;
                }
                else
                {
                    m_selX = endX;
                    m_selWidth = m_tileSize.Width + m_startX - endX;
                }

                if (m_startY < endY)
                {
                    m_selY = m_startY;
                    m_selHeight = m_tileSize.Height + endY - m_startY;
                }
                else
                {
                    m_selY = endY;
                    m_selHeight = m_tileSize.Height + m_startY - endY;
                }

                SelectedTiles = new Rectangle(
                    m_selX / m_tileSize.Width,
                    m_selY / m_tileSize.Height,
                    m_selWidth / m_tileSize.Width,
                    m_selHeight / m_tileSize.Height);

                pictureBoxTileset.Refresh();
            }
        }

        private void pictureBoxTileset_Paint(object sender, PaintEventArgs e)
        {
            if (m_sourceImage != null)
            {
                e.Graphics.DrawRectangle(Pens.Black, Selection.X, Selection.Y, Selection.Width - 1, Selection.Height - 1);
                e.Graphics.DrawRectangle(Pens.White, Selection.X + 1, Selection.Y + 1, Selection.Width - 3, Selection.Height - 3);
                e.Graphics.DrawRectangle(Pens.White, Selection.X + 2, Selection.Y + 2, Selection.Width - 5, Selection.Height - 5);
                e.Graphics.DrawRectangle(Pens.Black, Selection.X + 3, Selection.Y + 3, Selection.Width - 7, Selection.Height - 7);
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Tritt auf, falls die Auswahl verändert wird.
        /// </summary>
        [Browsable(true)]
        [Category("Verhalten")]
        [Description("Tritt auf, falls die Auswahl verändert wird.")]
        public event EventHandler<TileSelectEventArgs> SelectionChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Verändert das aktuelle Image
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image SourceImage
        {
            get
            {
                return m_sourceImage;
            }

            set
            {
                if (value != null)
                {
                    m_sourceImage = value;

                    pictureBoxTileset.Image = m_sourceImage;
                    pictureBoxTileset.Size = new Size(m_sourceImage.Width, m_sourceImage.Height);

                    SelectedTiles = new Rectangle(0, 0, 1, 1);

                    pictureBoxTileset.Refresh();
                }
                else
                {
                    if (pictureBoxTileset.Image != null)
                    {
                        pictureBoxTileset.Image = null;
                        pictureBoxTileset.Size = new Size(0, 0);
                        pictureBoxTileset.Refresh();

                        SelectedTiles = Rectangle.Empty;
                    }
                }
            }
        }

        /// <summary>
        /// Die Kachelgröße in Pixel
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Size TileSize
        {
            get { return m_tileSize; }
            set
            {
                m_tileSize = value;
                pictureBoxTileset.Refresh();
            }
        }

        /// <summary>
        /// Liefert die Tileauswahl in Pixel
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle Selection
        {
            get
            {
                return new Rectangle(
                    m_selection.X * m_tileSize.Width,
                    m_selection.Y * m_tileSize.Height,
                    m_selection.Width * m_tileSize.Width,
                    m_selection.Height * m_tileSize.Height);
            }
        }

        /// <summary>
        /// Liefert die Tileauswahl in externen Koordinaten.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle SelectedTiles
        {
            get { return m_selection; }
            set
            {
                if (m_selection != value)
                {
                    var arguments = new TileSelectEventArgs(
                        value,
                        new Rectangle(
                            value.X * m_tileSize.Width,
                            value.Y * m_tileSize.Height,
                            value.Width * m_tileSize.Width,
                            value.Height * m_tileSize.Height));

                    if (SelectionChanged != null)
                    {
                        SelectionChanged(this, arguments);
                    }

                    if (!arguments.Cancel)
                    {
                        m_selection = value;
                        pictureBoxTileset.Refresh();
                    }
                }
            }
        }

        /// <summary>
        /// Falls gesetzt, kann jeweils nur eine Kachel ausgewählt werden.
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool SingleTileMode
        {
            get { return m_singleTileMode; }
            set
            {
                m_singleTileMode = value;

                if (m_selection.Width > 1 || m_selection.Height > 0)
                {
                    m_selection = new Rectangle(m_selection.X, m_selection.Y, 1, 1);
                }

                pictureBoxTileset.Refresh();
            }
        }

        #endregion
    }
}