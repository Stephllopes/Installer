﻿#region (C) Koninklijke Philips Electronics N.V. 2019
//
// All rights are reserved. Reproduction or transmission in whole or in part, in 
// any form or by any means, electronic, mechanical or otherwise, is prohibited 
// without the prior written permission of the copyright owner.
// 
#endregion

namespace Project.MainInstaller.Gui.Bootstrapper
{
    using System.ComponentModel;

    /// <summary>
    /// 
    /// </summary>
    public class BootstrapperAwareViewModel : INotifyPropertyChanged
    {
        public BootstrapperAwareViewModel(SetupProgram bootstrapper)
        {
            this.Bootstrapper = bootstrapper;
        }

        public SetupProgram Bootstrapper { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}