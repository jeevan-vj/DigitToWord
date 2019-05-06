using System;
using System.Globalization;
using System.Text;
using static DigitToWord.DigitToWordService.Numerals;

namespace DigitToWord.DigitToWordService
{
    public class NumberReader 
    {
        private const double MaxInputLimit = 1000000000000000000;

        public virtual string Read(double number)
        {
            //Lets limit the input
            if (number > MaxInputLimit)
            {
                throw new Exception("Invalid Inputs",
                    new ArgumentException($"Input is over the readable limit. Max: {MaxInputLimit}, Provided: {number}."));
            }

            StringBuilder numbersInWords = new StringBuilder();
            NumberFormatInfo numberFormatInfo = new CultureInfo("en-US", false).NumberFormat;
            numberFormatInfo.NumberDecimalDigits = 0;
            var periods = number.ToString("N", numberFormatInfo).Split(',');

            int periodIndex = periods.Length - 1;
            foreach (var period in periods)
            {
                numbersInWords.Append(ReadPeriodDigits(period));
                if (int.Parse(period) > 0)
                {
                    numbersInWords.Append($"{ReadPeriod(periodIndex)} ");
                }
                periodIndex--;
            }

            return numbersInWords.ToString().TrimEnd();
        }

        private string ReadPeriodDigits(string period)
        {
            var hundreds = (period.Length == 3) ? int.Parse(period.Substring(0, 1)) : 0;
            var tens = (period.Length >= 2) ? int.Parse(period.Substring(period.Length - 2, 1)) : 0;
            var ones = (period.Length >= 1) ? int.Parse(period.Substring(period.Length - 1, 1)) : 0;

            StringBuilder digitsInWords = new StringBuilder();

            if (hundreds > 0)
            {
                string hundredsInWord = ReadHundreds(hundreds);
                string hundredsPostfix = (tens > 0 || ones > 0) ? " And " : " ";
                digitsInWords.Append($"{hundredsInWord}{hundredsPostfix}");
            }

            if (tens > 0)
            {
                string tensInWords;
                string tensPostfix;
                if (tens == 1 && ones > 0)
                {
                    tensInWords = ReadTeens(ones);
                    tensPostfix = " ";
                }
                else
                {
                    tensInWords = ReadTens(tens);
                    tensPostfix = (ones > 0) ? "-" : " ";
                }
                digitsInWords.Append($"{tensInWords}{tensPostfix}");
            }

            if (ones > 0 && tens != 1)
            {
                digitsInWords.Append($"{ReadOnes(ones)} ");
            }

            return digitsInWords.ToString();
        }
    }
}
