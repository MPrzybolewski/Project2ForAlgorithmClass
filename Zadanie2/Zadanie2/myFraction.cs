using System;
using System.Numerics;

namespace Zadanie2
{
    public class MyFraction
    {
        public BigInteger numerator { get; set; }
        public BigInteger denominator { get; set; }

        public MyFraction(BigInteger numerator, BigInteger denominator)
        {
            if(denominator != 0)
            {
                this.numerator = numerator;
                this.denominator = denominator;
                Simplify(this.numerator, this.denominator);
            } else
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
                
        }

        public MyFraction(BigInteger numerator)
            : this(numerator, 1) { }

        public MyFraction()
        {
            numerator = 0;
            denominator = 1;
            Simplify(this.numerator, this.denominator);
        }

        private void Simplify(BigInteger num, BigInteger den)
        {
            //Console.WriteLine("poczatek");
            //Console.WriteLine("{0}/{1}",num,den);
            if(num != 0)
            {
                if(num < 0)
                {
                    num = -num;
                }

                if(den < 0)
                {
                    den = -den;
                }

                BigInteger gcd = countGCD(num, den);
                try
                {
                    numerator = numerator / gcd;
                    denominator = denominator / gcd;
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Division of {0} by zero.");
                }
            }
        }


        private BigInteger countGCD(BigInteger num, BigInteger den)
        {
            while (num != den)
            {
                if (num < den)
                {
                    den -= num;
                }
                else
                {
                    num -= den;
                }
            }

            return num;
        }

        

        public static MyFraction operator *(MyFraction firstFraction, MyFraction secondFraction)
        {
            return new MyFraction(firstFraction.numerator * secondFraction.numerator, firstFraction.denominator * secondFraction.denominator);
        }

        public static MyFraction operator +(MyFraction firstFraction, MyFraction secondFraction)
        {
            BigInteger numerator = (firstFraction.numerator * secondFraction.denominator) + (secondFraction.numerator * firstFraction.denominator);
            BigInteger denominator = firstFraction.denominator * secondFraction.denominator;
            return new MyFraction(numerator, denominator);
        }

        public static MyFraction operator -(MyFraction firstFraction, MyFraction secondFraction)
        {
            BigInteger numerator = (firstFraction.numerator * secondFraction.denominator) - (secondFraction.numerator * firstFraction.denominator);
            BigInteger denominator = (firstFraction.denominator * secondFraction.denominator);
            return new MyFraction(numerator, denominator);
        }

        public static MyFraction operator /(MyFraction firstFraction, MyFraction secondFraction)
        {

            return new MyFraction(firstFraction.numerator * secondFraction.denominator, firstFraction.denominator * secondFraction.numerator);
        }

        public override string ToString()
        {
            return string.Format("{0:N3}", (double)numerator / (double)denominator);
        }

        public static bool operator <(MyFraction firstFraction, MyFraction secondFraction)
        {
            double firstFractionValue = (double)firstFraction.numerator / (double)firstFraction.denominator;
            double secondFractionValue = (double)secondFraction.numerator / (double)secondFraction.denominator;
            if (firstFractionValue < secondFractionValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >(MyFraction firstFraction, MyFraction secondFratcion)
        {
            double firstFractionValue = (double)firstFraction.numerator / (double)firstFraction.denominator;
            double secondFractionValue = (double)secondFratcion.numerator / (double)secondFratcion.denominator;
            if (firstFractionValue > secondFractionValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}