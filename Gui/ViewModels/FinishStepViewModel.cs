#region (C) Koninklijke Philips Electronics N.V. 2019
//
// All rights are reserved. Reproduction or transmission in whole or in part, in 
// any form or by any means, electronic, mechanical or otherwise, is prohibited 
// without the prior written permission of the copyright owner.
// 
#endregion

namespace Project.MainInstaller.Gui.ViewModels
{
    using System.Windows.Input;
    using Project.MainInstaller.Gui.Utils;

    /// <summary>
    /// class to control commands of the FinishStep class
    /// </summary>
    public class FinishStepViewModel : PageViewModel
    {
        public FinishStepViewModel(SetupWizardViewModel setupWizardViewModel) : base(setupWizardViewModel)
        {
            this.NextPageCommand = new SimpleCommand(_ =>
            {
                this.Bootstrapper.CloseUIAndExit();
            }, _ => true);
            this.CanGoToPreviousPage = true;
            this.CanGoToNextPage = true;
            this.CanCancel = true;
        }

        public override ICommand NextPageCommand { get; }
    }
}
