using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Models
{
    public class RomanNumber : ICloneable, IComparable
    {
        private ushort[] mas1 = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private string[] mas2 = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        protected string s = "";
        protected ushort n;

        public RomanNumber(ushort n) //Конструктор получает число n, которое должен представлять объект класса
        {
            if (n == 0)
                throw new RomanNumberException("Ошибка при вводе: n равняется нулю");
            if (n > 3999)
                throw new RomanNumberException("Ошибка при вводе: n более 3999");
            this.n = n;
        }

        public static RomanNumber operator +(RomanNumber n1, RomanNumber n2)
        => Add(n1, n2);
        public static RomanNumber Add(RomanNumber? n1, RomanNumber? n2) //Сложение римских чисел
        {
            if ((n1 == null)||(n2 == null))
                throw new RomanNumberException("Ошибка при суммировании: одно из чисел не передано");

            ushort sum = (ushort)(n1.n + n2.n);
            RomanNumber romanNumber = new RomanNumber(sum);

            if (sum > 3999)
                throw new RomanNumberException("Ошибка при суммировании: результат более 3999");

            return romanNumber;
        }

        public static RomanNumber operator -(RomanNumber n1, RomanNumber n2)
        => Sub(n1, n2);
        public static RomanNumber Sub(RomanNumber? n1, RomanNumber? n2) //Вычитание римских чисел
        {
            if ((n1 == null) || (n2 == null))
                throw new RomanNumberException("Ошибка при вычитании: одно из чисел не передано");
            if (n2.n > n1.n)
                throw new RomanNumberException("Ошибка при вычитании: результат - отрицательное число");
            if (n2.n == n1.n)
                throw new RomanNumberException("Ошибка при вычитании: результат - ноль");
            ushort dif = (ushort)(n1.n - n2.n);
            RomanNumber romanNumber = new RomanNumber(dif);

            return romanNumber;
        }

        public static RomanNumber operator *(RomanNumber n1, RomanNumber n2)
        => Mul(n1, n2);
        public static RomanNumber Mul(RomanNumber? n1, RomanNumber? n2) //Умножение римских чисел
        {
            if ((n1 == null) || (n2 == null))
                throw new RomanNumberException("Ошибка при умножении: одно из чисел не передано");
            ushort prod = (ushort)(n1.n * n2.n);
            RomanNumber romanNumber = new RomanNumber(prod);

            if (prod>3999)
                throw new RomanNumberException("Ошибка при умножении: результат более 3999");

            return romanNumber;
        }

        public static RomanNumber operator /(RomanNumber n1, RomanNumber n2)
        => Div(n1, n2);
        public static RomanNumber Div(RomanNumber? n1, RomanNumber? n2) //Целочисленное деление римских чисел
        {
            if ((n1 == null) || (n2 == null))
                throw new RomanNumberException("Ошибка при делении: одно из чисел не передано");
            if (n2.n > n1.n)
                throw new RomanNumberException("Ошибка при делении: результат меньше единицы");
            if (n1.n % n2.n != 0)
                throw new RomanNumberException("Ошибка при делении: результат не является целочисленным");
            ushort div = (ushort)(n1.n / n2.n);            
            RomanNumber romanNumber = new RomanNumber(div);

            return romanNumber;
        }

        public override string ToString()  //Возвращает строковое представление римского числа
        {
            s = "";
            int N = n;
            int i = 0;
            while (N > 0)
            {
                if (mas1[i] <= N)
                {
                    N = N - mas1[i];
                    s = s + mas2[i];
                }
                else i++;
            }
            return s;
        }

        public object Clone() //Реализация интерфейса IClonable
        {
            return new RomanNumber(n);
        }

        public int CompareTo(object? obj) //Реализация интерфейса IComparable
        {
            if (obj == null)
                throw new RomanNumberException("Ошибка при сравнении: число не передано");

            RomanNumber romanNumber;
            romanNumber = (RomanNumber)obj;

            return n.CompareTo(romanNumber.n);
        }
    }
}
