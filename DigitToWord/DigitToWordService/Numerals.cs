using System;
namespace DigitToWord.DigitToWordService
{
    internal static class Numerals
    {
        private static readonly string[] _oneNumerals =
        {
            "Zero",
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine"
        };

        private static readonly string[] _periodNumerals =
        {
            "",
            "Thousand",
            "Million",
            "Billion",
            "Trillion",
            "Quadrillion",
            "Quintillion",
            "Sextillion"
        };

        private static readonly string[] _teenNumerals =
        {
            "",
            "Eleven",
            "Twelve",
            "Thirteen",
            "Fourteen",
            "Fifteen ",
            "Sixteen",
            "Seventeen",
            "Eighteen",
            "Nineteen"
        };

        private static readonly string[] _tenNumerals =
        {
            "",
            "Ten",
            "Twenty",
            "Thirty",
            "Forty",
            "Fifty",
            "Sixty",
            "Seventy",
            "Eighty",
            "Ninety"
        };

        internal static string ReadHundreds(int number) => $"{ReadOnes(number)} Hundred";

        internal static string ReadOnes(int number) => _oneNumerals[number];

        internal static string ReadPeriod(int number) => _periodNumerals[number];

        internal static string ReadTeens(int number) => _teenNumerals[number];

        internal static string ReadTens(int number) => _tenNumerals[number];
    }
}
