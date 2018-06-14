using System;
using System.Collections.Generic;

namespace AutoTilesConverter.Formats
{
    public class ConverterFormat
    {
        private readonly string _name;

        private readonly HashSet<ConverterFormatRule> _rules;

        private readonly ushort _tileWidth;
        private readonly ushort _tileHeight;

        private readonly ushort _tilesCountX;
        private readonly ushort _tilesCountY;

        private readonly ushort _optimalWidth;

        public ConverterFormat(string name, ushort tileWidth, ushort tileHeight, ushort tilesCountX, ushort tilesCountY, ushort optimalWidth = 0)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            _name = name;
            _rules = new HashSet<ConverterFormatRule>();
            _tileWidth = tileWidth;
            _tileHeight = tileHeight;
            _tilesCountX = tilesCountX;
            _tilesCountY = tilesCountY;
            _optimalWidth = optimalWidth;
        }

        public string Name
        {
            get { return _name; }
        }

        public ushort OptimalWidth
        {
            get { return _optimalWidth; }
        }

        public ushort FrameWidth
        {
            get { return (ushort)(_tilesCountX * _tileWidth); }
        }

        public ushort FrameHeight
        {
            get { return (ushort)(_tilesCountY * _tileHeight); }
        }

        public ushort TilesCountX
        {
            get { return _tilesCountX; }
        }

        public ushort TilesCountXInternal
        {
            get { return (ushort)(_tilesCountX * 2); }
        }

        public ushort TilesCountYInternal
        {
            get { return (ushort)(_tilesCountY * 2); }
        }

        public ushort TilesCountY
        {
            get { return _tilesCountY; }
        }

        public ushort TileWidth
        {
            get { return _tileWidth; }
        }

        public ushort TileHeight
        {
            get { return _tileHeight; }
        }

        public ushort TileWidthInternal
        {
            get { return (ushort)(_tileWidth / 2); }
        }

        public ushort TileHeightInternal
        {
            get { return (ushort)(_tileHeight / 2); }
        }

        public HashSet<ConverterFormatRule> Rules
        {
            get { return _rules; }
        }
    }
}