﻿// <copyright file="MainWindow.xaml.cs" company="Progress">
//     Copyright (c) Ivan Yankov. All rights reserved.
// </copyright>
// <author>Ivan Yankov</author>

namespace FrontEndTask
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;
    using FrontEndTask.Commands;
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
        /// Holds the private command for adding random persons.
        /// </summary>
        private ICommand addRandomPersonCommand;
        
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
        /// Gets or sets the command, which adds a random Person to the collection.
        /// </summary>
        public ICommand AddRandomPersonCommand
        {
            get
            {
                if (this.addRandomPersonCommand == null)
                {
                    this.addRandomPersonCommand = new RelayCommand(this.OnAddRandomPersonRequested);
                }

                return this.addRandomPersonCommand;
            }

            set
            {
                this.addRandomPersonCommand = value;
            }
        }

        /// <summary>
        /// Creates a default list of Persons.
        /// </summary>
        /// <returns>The default Persons list.</returns>
        private IEnumerable<Person> CreateDefaultDataItems()
        {
            var dataItems = new ObservableCollection<Person>()
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
        
        /// <summary>
        /// Executed, when a request to the AddRandomPersonCommand is made.
        /// </summary>
        /// <param name="parameter">A parameter passed from XAML.</param>
        private void OnAddRandomPersonRequested(object parameter)
        {
            var persons = this.CheckedRadListBoxItemsSource as ObservableCollection<Person>;
            if (persons != null)
            {
                var random = new Random();
                var age = Convert.ToByte(random.Next(0, Person.MaxAllowedAge));
                var person = new Person("AutoGeneratedPerson", age);
                persons.Add(person);
            }
        }
    }
}