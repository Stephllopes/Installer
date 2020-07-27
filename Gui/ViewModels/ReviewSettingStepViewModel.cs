#region (C) Koninklijke Philips Electronics N.V. 2019
//
// All rights are reserved. Reproduction or transmission in whole or in part, in 
// any form or by any means, electronic, mechanical or otherwise, is prohibited 
// without the prior written permission of the copyright owner.
// 
#endregion

namespace Project.MainInstaller.Gui.ViewModels
{
    /// <summary>
    /// class to control commands of the ReviewSettingStep class
    /// </summary>
    public class ReviewSettingStepViewModel : PageViewModel
    {
        public ReviewSettingStepViewModel(SetupWizardViewModel setupWizardViewModel) : base(setupWizardViewModel)
        {
            this.CanGoToPreviousPage = true;
            this.CanGoToNextPage = true;
            this.CanCancel = true;
        }
    }
}
