#region (C) Koninklijke Philips Electronics N.V. 2019
//
// All rights are reserved. Reproduction or transmission in whole or in part, in 
// any form or by any means, electronic, mechanical or otherwise, is prohibited 
// without the prior written permission of the copyright owner.
// 
#endregion

namespace ProjectMainInstaller.Gui.ViewModels
{
    /// <summary>
    /// class to control commands of the LicenseStep class
    /// </summary>
    public class LicenseStepViewModel : PageViewModel
    {
        public LicenseStepViewModel(SetupWizardViewModel setupWizardViewModel) : base(setupWizardViewModel)
        {
            this.CanGoToPreviousPage = true;
            this.CanGoToNextPage = true;
            this.CanCancel = true;
        }
    }
}
