using System;
using System.Collections.Generic;

namespace MathsEx
{
    /// <summary>
    /// 
    /// </summary>
    public static class Operations
    {

        // MathsEx.Operations.GetFactors() overloads
        #region integers GetFactors(value)
        // Visual Basic: Public Shared Sub GetFactors(value)

        /// <summary>
        /// Calculates the factors of the provided integral value.
        /// </summary>
        /// <param name="value">An unsigned integer to factorise.</param>
        /// <returns>An array of <see cref="ulong"/> factors.</returns>
        public static ulong[] GetFactors(ulong value)
        {
            // Declares and initialises a list of unsigned integers
            List<ulong> factors = new List<ulong>();

            // Begins to calculate factors
            for (ulong i = 1; i <= Math.Sqrt(value); ++i)
            {
                // If the modulo (remainder) of the division of value by i is 0 ...
                if (value % i == 0)
                {
                    // add i to the list
                    factors.Add(i);
                    // and then add the value divided by i to the list if possible
                    if (i != value / i) factors.Add(value / i);
                }
            }
            // numerically sorts the list
            factors.Sort();

            // finally, returns the list as an array of ulong
            return factors.ToArray();
        }

        /// <summary>
        /// Calculates the factors of the provided integral value.
        /// </summary>
        /// <param name="value">An unsigned integer to factorise.</param>
        /// <returns>An array of <see cref="uint"/> factors.</returns>
        public static uint[] GetFactors(uint value)
        {
            // Declares and initialises a list of unsigned integers
            List<uint> factors = new List<uint>();

            // Begins to calculate factors
            for (uint i = 1; i <= Math.Sqrt(value); ++i)
            {
                // If the modulo (remainder) of the division of value by i is 0 ...
                if (value % i == 0)
                {
                    // add i to the list
                    factors.Add(i);
                    // and then add the value divided by i to the list if possible
                    if (i != value / i) factors.Add(value / i);
                }
            }
            // numerically sorts the list
            factors.Sort();

            // finally, returns the list as an array of uint
            return factors.ToArray();
        }

        /// <summary>
        /// Calculates the factors of the provided integral value.
        /// </summary>
        /// <param name="value">A signed integer to factorise.</param>
        /// <returns>An array of <see cref="long"/> factors.</returns>
        public static long[] GetFactors(long value)
        {
            // Declares and initialises a list of unsigned integers
            List<long> factors = new List<long>();

            // Begins to calculate factors
            for (long i = 1; i <= Math.Sqrt(value); ++i)
            {
                // If the modulo (remainder) of the division of value by i is 0 ...
                if (value % i == 0)
                {
                    // add i to the list
                    factors.Add(i);
                    // and then add the value divided by i to the list if possible
                    if (i != value / i) factors.Add(value / i);
                }
            }
            // numerically sorts the list
            factors.Sort();

            // finally, returns the list as an array of ulong
            return factors.ToArray();
        }

        /// <summary>
        /// Calculates the factors of the provided integral value.
        /// </summary>
        /// <param name="value">A signed integer to factorise.</param>
        /// <returns>An array of <see cref="int"/> factors.</returns>
        public static int[] GetFactors(int value)
        {
            // Declares and initialises a list of unsigned integers
            List<int> factors = new List<int>();

            // Begins to calculate factors
            for (int i = 1; i <= Math.Sqrt(value); ++i)
            {
                // If the modulo (remainder) of the division of value by i is 0 ...
                if (value % i == 0)
                {
                    // add i to the list
                    factors.Add(i);
                    // and then add the value divided by i to the list if possible
                    if (i != value / i) factors.Add(value / i);
                }
            }
            // numerically sorts the list
            factors.Sort();

            // finally, returns the list as an array of ulong
            return factors.ToArray();
        }

        #endregion

        // MathsEx.Operations.IsPrime() overloads
        #region bool IsPrime(value)
        // Visual Basic: Public Shared Sub IsPrime(value) As Bool

        /// <summary>
        /// Checks if the specified 32-bit integer is a prime number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer to check.</param>
        /// <returns>True if the value is prime, else, false.</returns>
        public static bool IsPrime(uint value)
        {
            uint i, m = value / 2;

            for (i = 2; i <= m; i++)
                if (value % i == 0) return false;

            return true;
        }

        /// <summary>
        /// Checks if the specified 32-bit integer is a prime number.
        /// </summary>
        /// <param name="value">A 32-bit signed integer to check.</param>
        /// <returns>True if the value is prime, else, false.</returns>
        public static bool IsPrime(int value)
        {
            int i, m = value / 2;

            for (i = 2; i <= m; i++)
                if (value % i == 0) return false;

            return true;
        }

        #endregion


        // MathsEx.Operations.GetHCF() overloads
        #region  GetHCF(value)

        /// <summary>
        /// Returns the highest common factor of two integral values.
        /// </summary>
        /// <param name="a">A 64-bit integer.</param>
        /// <param name="b">A 64-bit integer.</param>
        /// <returns>Zero if no HCF can be calculated.</returns>
        public static long GetHCF(long a, long b)
        {
            long result = 0;
            for (long i = 0; i <= a || i<= b; ++i)
            {
                try
                {
                    if ((a % i == 0) && (b % i == 0))
                        result = i;
                }
                catch (DivideByZeroException)
                {
                    result = 0;
                }
            }
            return result;
        }

        /// <summary>
        /// Returns the highest common factor of two integral values.
        /// </summary>
        /// <param name="a">A 32-bit integer.</param>
        /// <param name="b">A 32-bit integer.</param>
        /// <returns>Zero if no HCF can be calculated.</returns>
        public static int GetHCF(int a, int b)
        {
            int result = 0;
            for (int i = 0; i <= a || i<= b; ++i)
            {
                try
                {
                    if ((a % i == 0) && (b % i == 0))
                        result = i;
                }
                catch (DivideByZeroException)
                {
                    result = 0;
                }
            }
            return result;
        }

        /// <summary>
        /// Returns the highest common factor of two integral values.
        /// </summary>
        /// <param name="a">A 16-bit integer.</param>
        /// <param name="b">A 16-bit integer.</param>
        /// <returns>Zero if no HCF can be calculated.</returns>
        public static short GetHCF(short a, short b)
        {
            short result = 0;
            for (short i = 0; i <= a || i<= b; ++i)
            {
                try
                {
                    if ((a % i == 0) && (b % i == 0))
                        result = i;
                }
                catch (DivideByZeroException)
                {
                    result = 0;
                }
            }
            return result;
        }

        #endregion

        // MathsEx.Operations.GetLCM() overloads
        #region GetLCM(value)

        /// <summary>
        /// Returns the lowest common multiple of two integral values.
        /// </summary>
        /// <param name="a">A 64-bit integer.</param>
        /// <param name="b">A 64-bit integer.</param>
        /// <returns></returns>
        public static long GetLCM(long a, long b)
        {
            long x = a, y = b;
            while (a != b)
            {
                if (a > b) a -= b;
                else b -= a;
            }

            return (x * y) / a;
        }

        /// <summary>
        /// Returns the lowest common multiple of two integral values.
        /// </summary>
        /// <param name="a">A 32-bit integer.</param>
        /// <param name="b">A 32-bit integer.</param>
        /// <returns></returns>
        public static int GetLCM(int a, int b)
        {
            int x = a, y = b;
            while (a != b)
            {
                if (a > b) a -= b;
                else b -= a;
            }

            return (x * y) / a;
        }

        /// <summary>
        /// Returns the lowest common multiple of two integral values.
        /// </summary>
        /// <param name="a">A 16-bit integer.</param>
        /// <param name="b">A 16-bit integer.</param>
        /// <returns></returns>
        public static short GetLCM(short a, short b)
        {
            short x = a, y = b;
            while (a != b)
            {
                if (a > b) a -= b;
                else b -= a;
            }

            return (short)((x * y) / a);
        }

        #endregion

        /// <summary>
        /// Gets the mean of a set of <see cref="double"/> numbers.
        /// </summary>
        /// <param name="numbers">An array containing numbers to average.</param>
        /// <returns>The average value for the set as a <see cref="double"/>.</returns>
        public static double GetAverage(params double[] numbers)
        {
            int amount = 0;
            double total = 0;

            foreach (double number in numbers)
            {
                amount += 1;
                total += number;
            }

            return total / amount;
        }

        /// <summary>
        /// Gets the factorial of an integral value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Factorial(int value)
        {
            if (value <= 1) return 1;
            return value * Factorial(value - 1);
        }
    }
}
