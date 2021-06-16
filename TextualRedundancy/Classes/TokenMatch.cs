using System;

namespace TextualRedundancy.Classes
{
    public class TokenMatch
    {
        public string Token { get; set; } = "";
        public int Amount { get; set; } = 0;
        public double DistributionLength { get; set; } = 0;
        public string DistributionLengthString { get { return Math.Floor(DistributionLength).ToString(); } }
        public double RelativeTokenLength { get; set; } = 0;
        public string RelativeTokenLengthString { get { return Math.Floor(RelativeTokenLength).ToString(); } }
        public double Position { get; set; } = 0;
        public double Length { get; set; } = 0;
    }
}
