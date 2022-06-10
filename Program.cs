using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRepresentation
{
    internal class Program
    {
        static public string _inputNumber;
        static public string _textRepresentation;
        static public NumToTextConverter _numToTextConverter;

        static void Main(string[] args)
        {
            Console.WriteLine("Please input number: ");
            _inputNumber = Console.ReadLine();

            _numToTextConverter = new NumToTextConverter();

            if (_numToTextConverter.TryConvertNumToText(_inputNumber, out _textRepresentation))
            {
                Console.WriteLine($"Text representatin: { _textRepresentation }");
            }
            else
            {
                Console.WriteLine($"Error: { _textRepresentation }");
            }
            
            Console.ReadLine();
        }
    }
}
