#region (C) Koninklijke Philips Electronics N.V. 2019
//
// All rights are reserved. Reproduction or transmission in whole or in part, in 
// any form or by any means, electronic, mechanical or otherwise, is prohibited 
// without the prior written permission of the copyright owner.
// 
#endregion

namespace ProjectMainInstaller.Gui.Views
{
    using System.Windows;
    using System.Windows.Interop;
    using System.ComponentModel;
    using ProjectMainInstaller.Gui.ViewModels;
    using ProjectMainInstaller.Gui.Bootstrapper;
    using ProjectMainInstaller.Gui.Enum;

    /// <summary>
    /// Interaction logic for SetupWizard.xaml
    /// The main window
    /// </summary>
    public partial class SetupWizard
    {
        public SetupWizard()
        {
            this.DataContext = new SetupWizardViewModel(null);
            this.InitializeComponent();
        }

        public SetupWizard(SetupProgram bootstrapper)
        {
            this.DataContext = new SetupWizardViewModel(bootstrapper)
            {
                WindowHandle = new WindowInteropHelper(this).Handle
            };

            this.InitializeComponent();
        }

        public SetupWizardViewModel ViewModel => (SetupWizardViewModel)this.DataContext;

    }
}
