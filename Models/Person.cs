// <copyright file="Person.cs" company="Progress">
//     Copyright (c) Ivan Yankov. All rights reserved.
// </copyright>
// <author>Ivan Yankov</author>

namespace FrontEndTask.Models
{
    using System;

    /// <summary>
    /// A very simple Person class.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Holds the max allowed age value.
        /// </summary>
        public const byte MaxAllowedAge = 120;

        /// <summary>
        /// I am sure, you know what this is :)
        /// </summary>
        private byte age;

        /// <summary>
        /// Initializes a new instance of the <see cref="Person" /> class.
        /// </summary>
        /// <param name="name">The person name</param>
        /// <param name="age">The person age</param>
        /// <exception cref="ArgumentException">Thrown, when passed name is null or empty.</exception>
        public Person(string name, byte age)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name can not be null or empty!");
            }

            this.Name = name;
            this.Age = age;
        }

        /// <summary>
        /// Gets or sets the Person name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Person age
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, when negative or too big values are passed.</exception>
        public byte Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value > Person.MaxAllowedAge)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("Age must be in range 0-{0}! The provided value was {1}", Person.MaxAllowedAge, value));
                }

                this.age = value;
            }
        }

        /// <summary>
        /// Returns combination of Person's name and its age
        /// </summary>
        /// <returns>Combination of Person's name and its age</returns>
        public override string ToString()
        {
            return string.Format("{0} ({1} years old)", this.Name, this.age);
        }
    }
}
