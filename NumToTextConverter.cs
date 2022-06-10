using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextRepresentation
{
    public class NumToTextConverter
    {
        public bool TryConvertNumToText(string number, out string textRepresentation)
        {
            try
            {
                //remove all invalid characters and symbols
                number = string.Concat(Regex.Matches(number, @"\d+\.?").Cast<Match>().Select(i => i.Value).ToArray());
                textRepresentation = "";

                if (string.IsNullOrEmpty(number))
                {
                    throw new ArgumentException("Not correcrt iuput number, please using olny nmber and one sybol '.' to separate cents");
                }

                string[] dollarsAndCents = number.Split('.');
                //parse dollar part
                if (!string.IsNullOrEmpty(dollarsAndCents[0]))
                {
                    string dollars = dollarsAndCents[0];
                    //add leading zeros
                    while (dollars.Length < 12)
                    {
                        dollars = string.Concat('0', dollars);
                    }

                    string billions = TranslateCharArrayToText(dollars.ToCharArray().Where((c, i) => i >= 0 && i <= 2).ToArray());
                    string millions = TranslateCharArrayToText(dollars.ToCharArray().Where((c, i) => i >= 3 && i <= 5).ToArray());
                    string thousands = TranslateCharArrayToText(dollars.ToCharArray().Where((c, i) => i >= 6 && i <= 8).ToArray());
                    string hundreds = TranslateCharArrayToText(dollars.ToCharArray().Where((c, i) => i >= 9 && i <= 11).ToArray());

                    if (!string.IsNullOrEmpty(billions))
                        textRepresentation += billions + "billion, ";
                    if (!string.IsNullOrEmpty(millions))
                        textRepresentation += millions+"million, ";
                    if (!string.IsNullOrEmpty(thousands))
                        textRepresentation += thousands + "thousand, ";
                    if (!string.IsNullOrEmpty(hundreds))
                        textRepresentation += hundreds + "dollars ";
                }
                if (dollarsAndCents.Length > 1)
                {
                    string cents = TranslateCharArrayToText(string.Concat('0', dollarsAndCents[1]).ToCharArray());
                    if (!string.IsNullOrEmpty(cents))
                        textRepresentation += "and " + cents + "cents";
                }
            }
            catch (Exception ex)
            {
                textRepresentation = ex.Message;
                return false;
            }
            return true;
        }

        private string TranslateCharArrayToText(char[] chars)
        {
            string result = string.Empty;
            bool specialCase = false;
            //parse hundreds
            switch (chars[0])
            {
                case '0':
                    result += "";
                    break;
                case '1':
                    result += "one hundred ";
                    break;
                case '2':
                    result += "two hundred ";
                    break;
                case '3':
                    result += "three hundred ";
                    break;
                case '4':
                    result += "four hundred ";
                    break;
                case '5':
                    result += "five hundred ";
                    break;
                case '6':
                    result += "six hundred ";
                    break;
                case '7':
                    result += "seven hundred ";
                    break;
                case '8':
                    result += "eight hundred ";
                    break;
                case '9':
                    result += "nine hundred ";
                    break;
            }
            //parse dozens
            switch (chars[1])
            {
                case '0':
                    result += "";
                    break;
                case '1':
                    //set special names from 10 to 19
                    specialCase = true;
                    break;
                case '2':
                    result += "twenty ";
                    break;
                case '3':
                    result += "thirty ";
                    break;
                case '4':
                    result += "forty ";
                    break;
                case '5':
                    result += "fifty ";
                    break;
                case '6':
                    result += "sixty ";
                    break;
                case '7':
                    result += "seventy ";
                    break;
                case '8':
                    result += "eightty ";
                    break;
                case '9':
                    result += "ninety ";
                    break;
            }
            //parse units
            switch (chars[2])
            {
                case '0':
                    result += specialCase ? "ten " : "";
                    break;
                case '1':
                    result += specialCase ? "eleven " : "one ";
                    break;
                case '2':
                    result += specialCase ? "twelve " : "two ";
                    break;
                case '3':
                    result += specialCase ? "thirteen " : "three ";
                    break;
                case '4':
                    result += specialCase ? "fourteen " : "four ";
                    break;
                case '5':
                    result += specialCase ? "fifteen " : "five ";
                    break;
                case '6':
                    result += specialCase ? "sixteen " : "six ";
                    break;
                case '7':
                    result += specialCase ? "seventeen " : "seven ";
                    break;
                case '8':
                    result += specialCase ? "eighteen " : "eight ";
                    break;
                case '9':
                    result += specialCase ? "nineteen " : "nine ";
                    break;
            }
            return result;
        }
    }
}
