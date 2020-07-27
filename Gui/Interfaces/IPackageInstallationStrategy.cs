#region (C) Koninklijke Philips Electronics N.V. 2019
//
// All rights are reserved. Reproduction or transmission in whole or in part, in 
// any form or by any means, electronic, mechanical or otherwise, is prohibited 
// without the prior written permission of the copyright owner.
// 
#endregion

namespace Project.MainInstaller.Gui.Interfaces
{
    using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

    /// <summary>
    /// 
    /// </summary>
    public interface IPackageInstallationStrategy
    {
        /// <summary>
        ///     Called by the bootstrapper to determine the required state of the msi feature.
        /// </summary>
        /// <param name="launchAction">Launch action of the bootstrapper</param>
        /// <param name="packageId">The package id of the msi</param>
        /// <param name="featureId">The feature id of the msi</param>
        /// <returns>The desired state of the feature, or null if it should be left as set by Burn.</returns>
        FeatureState? PlanMsiFeature(LaunchAction launchAction, string packageId, string featureId);

        /// <summary>
        ///     Called by the bootstrapper to determine the required state of the package.
        /// </summary>
        /// <param name="launchAction">Launch action of the bootstrapper</param>
        /// <param name="packageId">The package id of the msi</param>
        /// <returns>The desired state of the package, or null if it should be left as set by Burn.</returns>
        RequestState? PlanPackage(LaunchAction launchAction, string packageId);

        /// <summary>
        ///     Called after the bootstrapper has finished detecting. This can be used to implement additional detection steps.
        /// </summary>
        void DetectAdditionalInformation();

        /// <summary>
        ///     Method used to get a human-readable name for a package.
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        string GetPackageNameFromId(string packageId);
    }
}