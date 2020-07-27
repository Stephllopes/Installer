﻿#region (C) Koninklijke Philips Electronics N.V. 2019
//
// All rights are reserved. Reproduction or transmission in whole or in part, in 
// any form or by any means, electronic, mechanical or otherwise, is prohibited 
// without the prior written permission of the copyright owner.
// 
#endregion

namespace ProjectMainInstaller.Gui.Views.Pages
{
    using System.Windows.Controls;
    using ProjectMainInstaller.Gui.ViewModels;

    /// <summary>
    /// Interaction logic for InstallationStep.xaml
    /// </summary>
    public partial class InstallationStep : UserControl
    {
        public InstallationStep(SetupWizardViewModel setupWizardViewModel)
        {
            this.DataContext = new InstallationStepViewModel(setupWizardViewModel);
            this.InitializeComponent();
        }
    }
}
