#region (C) Koninklijke Philips Electronics N.V. 2019
//
// All rights are reserved. Reproduction or transmission in whole or in part, in 
// any form or by any means, electronic, mechanical or otherwise, is prohibited 
// without the prior written permission of the copyright owner.
// 
#endregion

namespace Project.MainInstaller.Gui.Interfaces
{
    using System;

    public interface IInteractionService
    {
        void CloseUIAndExit();
        void RunOnUIThread(Action body);
        IntPtr GetMainWindowHandle();
    }
}
