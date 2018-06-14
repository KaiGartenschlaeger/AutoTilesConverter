using System;
using System.Collections.Generic;

namespace AutoTilesConverter.Formats
{
    public class FormatRepository
    {
        private readonly List<ConverterFormat> _formats;

        public FormatRepository()
        {
            _formats = new List<ConverterFormat>();
        }

        public void InitFormats()
        {
            _formats.Clear();

            var autoTileVX = new ConverterFormat("AutoTile VX", 32, 32, 2, 3, 7);
            _formats.Add(autoTileVX);

            autoTileVX.Rules.Add(new ConverterFormatRule("Single", 9, 12, 21, 24));
            autoTileVX.Rules.Add(new ConverterFormatRule("Fill", 19, 18, 15, 14));

            autoTileVX.Rules.Add(new ConverterFormatRule("FillEdgeTL", 9, 10, 13, 14));
            autoTileVX.Rules.Add(new ConverterFormatRule("FillEdgeTR", 11, 12, 15, 16));
            autoTileVX.Rules.Add(new ConverterFormatRule("FillEdgeBL", 17, 18, 21, 22));
            autoTileVX.Rules.Add(new ConverterFormatRule("FillEdgeBR", 19, 20, 23, 24));

            autoTileVX.Rules.Add(new ConverterFormatRule("CornerL", 17, 18, 13, 14));
            autoTileVX.Rules.Add(new ConverterFormatRule("CornerR", 19, 20, 15, 16));
            autoTileVX.Rules.Add(new ConverterFormatRule("CornerT", 11, 10, 15, 15));
            autoTileVX.Rules.Add(new ConverterFormatRule("CornerB", 19, 18, 23, 22));
            
            autoTileVX.Rules.Add(new ConverterFormatRule("LineT", 9, 12, 13, 16));
            autoTileVX.Rules.Add(new ConverterFormatRule("LineB", 17, 20, 21, 24));
            autoTileVX.Rules.Add(new ConverterFormatRule("LineL", 9, 10, 21, 22));
            autoTileVX.Rules.Add(new ConverterFormatRule("LineR", 11, 12, 23, 24));
            
            autoTileVX.Rules.Add(new ConverterFormatRule("LineH", 11, 10, 23, 22));
            autoTileVX.Rules.Add(new ConverterFormatRule("LineV", 17, 20, 13, 16));
            
            autoTileVX.Rules.Add(new ConverterFormatRule("LineDiagonalTL", 9, 10, 13, 8));
            autoTileVX.Rules.Add(new ConverterFormatRule("LineDiagonalTR", 11, 12, 7, 16));
            autoTileVX.Rules.Add(new ConverterFormatRule("LineDiagonalBL", 17, 4, 21, 22));
            autoTileVX.Rules.Add(new ConverterFormatRule("LineDiagonalBR", 3, 20, 23, 24));

            autoTileVX.Rules.Add(new ConverterFormatRule("LineC", 3, 4, 7, 8));
        }

        public void RegisterFormat(ConverterFormat format)
        {
            if (format == null)
                throw new ArgumentNullException(nameof(format));

            _formats.Add(format);
        }

        public IReadOnlyCollection<ConverterFormat> Formats
        {
            get { return _formats; }
        }
    }
}