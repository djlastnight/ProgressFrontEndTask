// <copyright file="AgeHelper.cs" company="Progress">
//     Copyright (c) Ivan Yankov. All rights reserved.
// </copyright>
// <author>Ivan Yankov</author>

namespace FrontEndTask.Common
{
    using System;
    using FrontEndTask.Models;

    /// <summary>
    /// Helper class intended to interact with age data.
    /// </summary>
    public static class AgeHelper
    {
        /// <summary>
        /// Calculates age from given birth year.
        /// </summary>
        /// <param name="birthYear">The Person's birth year</param>
        /// <returns>The calculated age</returns>
        /// <exception cref="InvalidOperationException">Thrown, when negative age is calculated.</exception>
        /// <exception cref="OverflowException">Thrown, when the calculated age exceeds the max allowed value.</exception>
        public static byte CalculatePersonAge(uint birthYear)
        {
            var age = DateTime.Now.Year - birthYear;
            if (age < 0)
            {
                throw new InvalidOperationException(
                    string.Format("Negative age is not allowed: {0}", age));
            }

            if (age > Person.MaxAllowedAge)
            {
                throw new OverflowException(
                    string.Format("The max allowed age value {0} have been exceed: {1}", Person.MaxAllowedAge, age));
            }

            return Convert.ToByte(age);
        }
    }
}
