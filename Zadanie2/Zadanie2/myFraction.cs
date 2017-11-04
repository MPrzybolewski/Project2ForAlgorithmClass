using System;
using System.Numerics;

namespace Zadanie2
{
    public class MyFraction
    {
        public BigInteger numerator { get; }
        public BigInteger denominator { get; }

        public MyFraction(BigInteger numerator, BigInteger denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
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
    }
}
