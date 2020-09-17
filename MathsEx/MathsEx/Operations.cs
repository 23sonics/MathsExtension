using System;
using System.Collections.Generic;

namespace MathsEx
{
    /// <summary>
    /// Maths extension for .NET Core.
    /// </summary>
    public class Operations
    {

        #region public static GetFactors(value)

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

        #region
    }
}
