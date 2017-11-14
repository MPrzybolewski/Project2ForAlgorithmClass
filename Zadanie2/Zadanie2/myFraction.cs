using System;
using System.Numerics;

namespace Zadanie2
{
    public struct MyFraction
    {
        public BigInteger numerator { get; }
        public BigInteger denominator { get; }

        public MyFraction(BigInteger numerator, BigInteger denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public MyFraction(BigInteger numerator)
            : this(numerator, 1) { }
        
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
            return string.Format("{0}", (double)numerator/(double)denominator);
        }

        public static bool operator <(MyFraction firstFraction, MyFraction secondFraction)
        {
            double firstFractionValue = (double)firstFraction.numerator / (double)firstFraction.denominator;
            double secondFractionValue = (double)secondFraction.numerator / (double)secondFraction.denominator;
            if (firstFractionValue < secondFractionValue)
            {
                return true;
            } else 
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
