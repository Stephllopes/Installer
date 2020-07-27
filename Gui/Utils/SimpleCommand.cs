#region (C) Koninklijke Philips Electronics N.V. 2019
//
// All rights are reserved. Reproduction or transmission in whole or in part, in 
// any form or by any means, electronic, mechanical or otherwise, is prohibited 
// without the prior written permission of the copyright owner.
// 
#endregion

namespace Project.MainInstaller.Gui.Utils
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Class to call commands and execute actions generically
    /// Class to implement ICommand Interface
    /// </summary>
    public class SimpleCommand : ICommand
    {
        #region Fields
        private readonly Func<object, bool> canExecuteAction;
        private readonly Action<object> executeAction;

        #endregion Fields

        #region Constructor
        public SimpleCommand(Action<object> executeAction, Func<object, bool> canExecuteAction)
        {
            this.executeAction = executeAction;
            this.canExecuteAction = canExecuteAction;
        }

        #endregion Constructor

        #region Public Methods
        public void Execute(object parameter)
        {
            this.executeAction(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecuteAction(parameter);
        }

        #endregion Public Methods

        #region Events
        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        #endregion Events
    }
}