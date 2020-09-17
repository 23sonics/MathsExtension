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

    }

    /// <summary>
    /// Represents a <see cref="Fraction"/> mixed with a <see cref="long"/>.
    /// </summary>
    public class MixedNumber
    {

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
