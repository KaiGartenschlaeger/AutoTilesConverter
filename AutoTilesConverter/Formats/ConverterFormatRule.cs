namespace AutoTilesConverter.Formats
{
    public class ConverterFormatRule
    {
        public ConverterFormatRule(string name, ushort index1, ushort index2, ushort index3, ushort index4)
        {
            Name = name;
            SourceIndexes = new ushort[4] { index1, index2, index3, index4 };
        }

        public string Name { get; private set; }
        public ushort[] SourceIndexes { get; private set; }


        public override int GetHashCode()
        {
            return $"{SourceIndexes[0]}_{SourceIndexes[1]}_{SourceIndexes[2]}_{SourceIndexes[3]}".GetHashCode();
        }
        public override bool Equals(object other)
        {
            ConverterFormatRule otherRule = (ConverterFormatRule)other;

            return
                SourceIndexes[0] == otherRule.SourceIndexes[0] &&
                SourceIndexes[1] == otherRule.SourceIndexes[1] &&
                SourceIndexes[2] == otherRule.SourceIndexes[2] &&
                SourceIndexes[3] == otherRule.SourceIndexes[3];
        }
    }
}