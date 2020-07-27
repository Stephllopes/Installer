#region (C) Koninklijke Philips Electronics N.V. 2019
//
// All rights are reserved. Reproduction or transmission in whole or in part, in 
// any form or by any means, electronic, mechanical or otherwise, is prohibited 
// without the prior written permission of the copyright owner.
// 
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Project.MainInstaller.Gui.Enum
{
    /// <summary>
    /// 
    /// </summary>
    public enum PageType
    {
        SetupWizard,
        InitializationStep,
        InstallationModeStep,
        WelcomeStep,
        LicenseStep,
        PreviousInstallationFoundStep,
        PrerequisiteAutoInstallStep,
        LegacyUninstallationStep,
        PrerequisiteCheckStep,
        FeatureSelectionStep,
        DatabaseServerInputStep,
        LanguageSelectionStep,
        StudyTypeStep,
        ReviewSettingStep,
        InstallationStep,
        FinishStep,
        FatalErrorStep
    }
}
