// <copyright file="RelayCommand.cs" company="Progress">
//     Copyright (c) Ivan Yankov. All rights reserved.
// </copyright>
// <author>Ivan Yankov</author>
namespace FrontEndTask.Commands
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// A simple execute delegate.
    /// </summary>
    /// <param name="parameter">The parameter to the execute delegate.</param>
    public delegate void ExecuteDelegate(object parameter);

    /// <summary>
    /// A simple can execute delegate.
    /// </summary>
    /// <param name="parameter">The parameter to the can execute delegate.</param>
    /// <returns>Returns true, if the ICommand can be executed.</returns>
    public delegate bool CanExecuteDelegate(object parameter);

    /// <summary>
    /// A simple class, which implements ICommand interface.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// execute field.
        /// </summary>
        private ExecuteDelegate execute;
        
        /// <summary>
        /// canExecute field.
        /// </summary>
        private CanExecuteDelegate canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand" /> class.
        /// </summary>
        /// <param name="execute">A delegate, which will be executed along with the ICommand itself.</param>
        public RelayCommand(ExecuteDelegate execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand" /> class.
        /// </summary>
        /// <param name="execute">A delegate, which will be executed along with the ICommand itself.</param>
        /// <param name="canExecute">A CanExecuted delegate.</param>
        public RelayCommand(ExecuteDelegate execute, CanExecuteDelegate canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Fired, when Can execute is changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Checks whether the RelayCommand can be executed.
        /// </summary>
        /// <param name="parameter">A parameter of any type.</param>
        /// <returns>Returns true, when the command can be executed.</returns>
        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }

            return this.canExecute(parameter);
        }

        /// <summary>
        /// Executes the RelayCommand with given parameter.
        /// </summary>
        /// <param name="parameter">A parameter of any type.</param>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}