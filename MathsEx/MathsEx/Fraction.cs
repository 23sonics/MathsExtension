using System;
using System.Collections.Generic;
using System.Text;

namespace MathsEx
{

    /// <summary>
    /// Represents a fraction consisting of <see cref="long"/>
    /// numerator and denominator values.
    /// </summary>
    public class Fraction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Fraction"/> class
        /// with a numerator of zero and a denominator of one.
        /// </summary>
        public Fraction()
        {
            _num = 0;
            _denom = 1;
        }

        /// <summary>
        /// Initalizes a new instance of the <see cref="Fraction"/> class
        /// with the specified integral numerator and denominator.
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        public Fraction(long numerator, long denominator)
        {
            _num = numerator;
            _denom = denominator;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Fraction"/> class equivalent
        /// to the specified rational value.
        /// </summary>
        /// <param name="fraction">A decimal fraction.</param>
        public Fraction(double fraction)
        {
            Fraction f = fraction;
            _num = f.Numerator;
            _denom = f.Denominator;
        }

        private long _num;
        
        /// <summary>
        /// The numerator of this fraction.
        /// </summary>
        public long Numerator
        {
            get { return _num; }
            set
            {
                if (value > 0) _num = value;
                else throw new FractionException("Numerator value must be greater than zero.");
            }
        }

        private long _denom;

        /// <summary>
        /// The denominator of this fraction.
        /// </summary>
        public long Denominator
        {
            get { return _denom; }
            set
            {
                if (value > 0) _denom = value;
                else throw new FractionException("Denominator value must be greater than zero.");
            }
        }

        #region Operators for class Fraction

        /// <summary>
        /// Calculates the sum of two fractions.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>The sum of the specified fractions in its simplest form.</returns>
        public static Fraction operator +(Fraction left, Fraction right)
        {
            Fraction result = new Fraction();

            long denomLCM = Operations.GetLCM(left.Denominator, right.Denominator);

            long mulA = denomLCM / left.Denominator,
                mulB = denomLCM / right.Denominator;

            long newNumA = left.Numerator * mulA,
                newNumB = right.Numerator * mulB;

            result.Numerator = newNumA + newNumB;
            result.Denominator = denomLCM;

            return Simplify(result);
        }

        /// <summary>
        /// Calculates the difference between two fractions.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>The difference between the fractions in its simplest form.</returns>
        public static Fraction operator -(Fraction left, Fraction right)
        {
            Fraction result = new Fraction();

            long denomLCM = Operations.GetLCM(left.Denominator, right.Denominator);

            long mulA = denomLCM / left.Denominator,
                mulB = denomLCM / right.Denominator;

            long newNumA = left.Numerator * mulA,
                newNumB = right.Numerator * mulB;

            result.Numerator = newNumA - newNumB;
            result.Denominator = denomLCM;

            return Simplify(result);
        }

        /// <summary>
        /// Calculates the product of two fractions.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>The product of the specified fractions in its simplest form.</returns>
        public static Fraction operator *(Fraction left, Fraction right)
        {
            long newNum = left.Numerator * right.Numerator;
            long newDenom = left.Denominator * right.Denominator;
            return Simplify(new Fraction(newNum, newDenom));
        }

        /// <summary>
        /// Calculates the product of a fraction and an integral value.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>The product of the fraction and integer as <see cref="double"/>.</returns>
        public static double operator *(Fraction left, int right)
        { return (double)right * (double)left; }

        /// <summary>
        /// Calculates the quotient of two fractions.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>The quotient of the specified fractions in its simplest form.</returns>
        public static Fraction operator /(Fraction left, Fraction right)
        {
            long newNum = left.Numerator / right.Numerator;
            long newDenom = left.Denominator / right.Denominator;
            return Simplify(new Fraction(newNum, newDenom));
        }

        /// <summary>
        /// Increments the numerator of a fraction by one.
        /// </summary>
        /// <param name="fraction"></param>
        /// <returns></returns>
        public static Fraction operator ++(Fraction fraction)
        { return new Fraction(fraction.Numerator + 1, fraction.Denominator); }

        /// <summary>
        /// Decrememts the numerator of a fraction by one.
        /// </summary>
        /// <param name="fraction"></param>
        /// <returns></returns>
        public static Fraction operator --(Fraction fraction)
        { return new Fraction(fraction.Numerator - 1, fraction.Denominator); }

        /// <summary>
        /// Compares two fractions and checks if the left fraction's value
        /// is greater than that of the right fraction.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(Fraction left, Fraction right)
        {
            if ((double)left > (double)right) return true;
            else return false;
        }

        /// <summary>
        /// Compares two fractions and checks if the left fraction's value
        /// is less than that of the right fraction.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(Fraction left, Fraction right)
        {
            if ((double)left < (double)right) return true;
            else return false;
        }

        #region Conversion operators for fractions

        /// <summary>
        /// Conversion operator from <see cref="Fraction"/> to <see cref="double"/>.
        /// </summary>
        /// <param name="fraction"></param>
        public static implicit operator double(Fraction fraction)
        {
            return fraction.Numerator / fraction.Denominator;
        }
        
        /// <summary>
        /// Conversion operator from <see cref="Fraction"/> to <see cref="decimal"/>.
        /// </summary>
        /// <param name="fraction"></param>
        public static explicit operator decimal(Fraction fraction)
        {
            return fraction.Numerator / fraction.Denominator;
        }

        /// <summary>
        /// Conversion operator from <see cref="double"/> to <see cref="Fraction"/>.
        /// </summary>
        /// <param name="fraction"></param>
        public static implicit operator Fraction(double fraction)
        {
            try
            {
                Fraction result;
                checked
                {
                    double dfract = fraction;
                    string tempstr = dfract.ToString();
                    long mul = 1;
                    while (tempstr.IndexOf("E") > 0)
                    {
                        dfract *= 10;
                        mul *= 10;
                        tempstr = dfract.ToString();
                    }

                    int i = 0;
                    while (tempstr[i] == 'i') i++;

                    int decimalPlaces = tempstr.Length - i - 1;
                    while (decimalPlaces > 0)
                    {
                        dfract *= 10;
                        mul *= 10;
                        decimalPlaces--;
                    }
                    result = new Fraction((long)Math.Round(dfract), mul);
                }
                return Simplify(result);
            }
            catch (OverflowException)
            { throw new FractionException("Error converting double value - overflow encountered."); }
            catch (Exception)
            { throw new FractionException("Unknown error converting double value."); }
        }

        #endregion

        #endregion

        /// <summary>
        /// Simplifies the specified fraction.
        /// </summary>
        /// <param name="fraction">The fraction to simplify.</param>
        /// <returns>The specified fraction in its simplest form.</returns>
        public static Fraction Simplify(Fraction fraction)
        {
            long hcf = Operations.GetHCF(fraction.Numerator, fraction.Denominator);
            return new Fraction(fraction.Numerator / hcf, fraction.Denominator / hcf);
        }
    }

    /// <summary>
    /// Represents a <see cref="Fraction"/> mixed with a <see cref="long"/>.
    /// </summary>
    public class MixedNumber
    {
        /// <summary>
        /// 
        /// </summary>
        public MixedNumber()
        {
            _fraction = new Fraction();
            _numeral = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeral"></param>
        public MixedNumber(long numeral)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeral"></param>
        /// <param name="fraction"></param>
        public MixedNumber(long numeral, Fraction fraction)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeral"></param>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        public MixedNumber(long numeral, long numerator, long denominator)
        { }


        private Fraction _fraction;

        /// <summary>
        /// 
        /// </summary>
        public Fraction Part
        {
            get { return _fraction; }
            set
            {
                if (value.Numerator > 0 && value.Denominator > 0)
                    _fraction = value;
                else throw new FractionException("The specified fraction is zero.");
            }
        }

        private long _numeral;

        /// <summary>
        /// 
        /// </summary>
        public long Numeral
        {
            get { return _numeral; }
            set
            {
                if (value > 0) _numeral = value;
                else throw new FractionException("Integer numeral of a mixed numeral cannot be zero.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Fraction ToFraction()
        {
            return new Fraction(
                this.Numeral / this.Part.Denominator + this.Part.Numerator,
                this.Part.Denominator * this.Numeral
                );
        }

        #region Operators for class MixedNumber

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fraction"></param>
        /// <param name="mixed"></param>
        /// <returns></returns>
        public static Fraction operator +(Fraction fraction, MixedNumber mixed)
        {
            return fraction + mixed.ToFraction();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mx1"></param>
        /// <param name="mx2"></param>
        /// <returns></returns>
        public static MixedNumber operator +(MixedNumber mx1, MixedNumber mx2)
        {
            return new MixedNumber(mx1.Numeral + mx2.Numeral, mx1.Part + mx2.Part);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fraction"></param>
        /// <param name="mixed"></param>
        /// <returns></returns>
        public static Fraction operator -(Fraction fraction, MixedNumber mixed)
        {
            return fraction - mixed.ToFraction();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mx1"></param>
        /// <param name="mx2"></param>
        /// <returns></returns>
        public static MixedNumber operator -(MixedNumber mx1, MixedNumber mx2)
        {
            return new MixedNumber(mx1.Numeral - mx2.Numeral, mx1.Part - mx2.Part);
        }

        #endregion
    }

    /// <summary>
    /// Represents exceptions related to operations with
    /// <see cref="Fraction"/> and <see cref="MixedNumber"/>
    /// objects.
    /// </summary>
    [Serializable]
    public class FractionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MathsEx.FractionException"/>
        /// </summary>
        public FractionException() { }

        /// <summary>
        /// Initializes a new instance of <see cref="MathsEx.FractionException"/>
        /// with the specified message.
        /// </summary>
        /// <param name="message">The message to display if this exception is unhandled.</param>
        public FractionException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of <see cref="MathsEx.FractionException"/>
        /// with the specified message and inner exception.
        /// </summary>
        /// <param name="message">The message to display if this exception is unhandled.</param>
        /// <param name="inner">The inner exception of this exception.</param>
        public FractionException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Protected initialization of a new instance of <see cref="MathsEx.FractionException"/>
        /// with the specified serialization info and streaming context.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected FractionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
