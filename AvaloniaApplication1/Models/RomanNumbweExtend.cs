using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Models
{
    public class RomanNumberExtend : RomanNumber
    {
        public ushort UshortValue() => this.n;
        public RomanNumberExtend(string number) : base(convert_roman_to_arabic(number)) { }
        public RomanNumberExtend(ushort n) : base(n) { }
        private static ushort ToArabic(char Char)
        {
            switch(Char)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    throw new RomanNumberException("Не существующий элемент");
            }
        }

        private static ushort convert_roman_to_arabic(string number)
        {
            ushort result = 0;
            for (int i = 0; i < number.Length; ++i)
            {
                ushort num_1 = ToArabic(number[i]);
                if (i + 1 < number.Length)
                {
                    ushort num_2 = ToArabic(number[i + 1]);
                    if (num_1 >= num_2)
                    {
                        result = (ushort)(result + num_1);
                    }
                    else
                    {
                        result = (ushort)(result - num_1);
                    }
                }

                else
                {
                    result = (ushort)(result + num_1);
                }
            }

            return result;
        }
    }
}