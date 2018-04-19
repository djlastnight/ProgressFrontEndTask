﻿// <copyright file="MainWindow.xaml.cs" company="Progress">
//     Copyright (c) Ivan Yankov. All rights reserved.
// </copyright>
// <author>Ivan Yankov</author>

namespace FrontEndTask
{
    using System.Collections.Generic;
    using System.Windows;
    using FrontEndTask.Common;
    using FrontEndTask.Models;

    /// <summary>
    /// Our MainWindow class
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// CheckedRadListBoxItemsSource dependency property, used for data bindings.
        /// </summary>
        public static readonly DependencyProperty CheckedRadListBoxItemsSourceProperty =
            DependencyProperty.Register(
            "CheckedRadListBoxItemsSource",
            typeof(IEnumerable<object>),
            typeof(MainWindow),
            new PropertyMetadata(null));

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.CheckedRadListBoxItemsSource = this.CreateDefaultDataItems();
        }

        /// <summary>
        /// Gets or sets the CheckedRadListBox collection.
        /// </summary>
        public IEnumerable<object> CheckedRadListBoxItemsSource
        {
            get { return (IEnumerable<object>)this.GetValue(CheckedRadListBoxItemsSourceProperty); }
            set { this.SetValue(CheckedRadListBoxItemsSourceProperty, value); }
        }

        /// <summary>
        /// Creates a default list of Persons.
        /// </summary>
        /// <returns>The default Persons list.</returns>
        private IEnumerable<Person> CreateDefaultDataItems()
        {
            var dataItems = new List<Person>()
            {
                new Person("Ivan", AgeHelper.CalculatePersonAge(1986)),
                new Person("Teodor", AgeHelper.CalculatePersonAge(2017)),
                new Person("Yana", AgeHelper.CalculatePersonAge(1988)),
                new Person("Vesela", AgeHelper.CalculatePersonAge(1983)),
                new Person("Georgi", AgeHelper.CalculatePersonAge(1986)),
                new Person("Krasimir", AgeHelper.CalculatePersonAge(1987)),
                new Person("Andrean", AgeHelper.CalculatePersonAge(1971))
            };

            return dataItems;
        }
    }
}