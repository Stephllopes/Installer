#region (C) Koninklijke Philips Electronics N.V. 2019
//
// All rights are reserved. Reproduction or transmission in whole or in part, in 
// any form or by any means, electronic, mechanical or otherwise, is prohibited 
// without the prior written permission of the copyright owner.
// 
#endregion

namespace Project.MainInstaller.Gui.Bootstrapper
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class Package
    {
        /// <summary>
        ///     The id of the package as described in the bundle definition file.
        /// </summary>
        public string PackageId { get; set; }

        /// <summary>
        ///     The human-readable name of the package.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        ///     The architectures that this package should be installed on.
        /// </summary>
        //public Architecture Architectures { get; set; }

        /// <summary>
        ///     The list of installation types this package is associated with. This can be used to quickly implement various
        ///     package combination presets.
        /// </summary>
        //public TInstallationType[] InstallationTypes { get; set; }

        /// <summary>
        ///     A predicate that must return true if the package is to be installed.
        /// </summary>
        //public Func<TParam, bool> AdditionalPredicate { get; set; } = (TParam param) => true;

        /// <summary>
        ///     Set to false if this package can't be removed.
        /// </summary>
        public bool IsRemovable { get; set; } = true;

        /// <summary>
        ///     Set to false if this package can't be repaired.
        /// </summary>
        public bool IsRepairable { get; set; } = true;

        /// <summary>
        ///     Set to false if this package shouldn't be downloaded when creating an offline installer.
        /// </summary>
        public bool AcquireDuringLayout { get; set; } = true;
    }
}