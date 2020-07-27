#region (C) Koninklijke Philips Electronics N.V. 2019
//
// All rights are reserved. Reproduction or transmission in whole or in part, in 
// any form or by any means, electronic, mechanical or otherwise, is prohibited 
// without the prior written permission of the copyright owner.
// 
#endregion

namespace Project.MainInstaller.Gui.Bootstrapper
{
    using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

    public class PackageInstallationStrategy : PackageInstallationStrategyBase<PackageCombinationConfiguration,
        InstallationType>
    {
        public PackageInstallationStrategy(PackageCombinationConfiguration packageCombinationConfiguration) : base(
            PackageConfiguration.PackageList, packageCombinationConfiguration, packageCombinationConfiguration)
        {
            this.PackageCombinationConfiguration = packageCombinationConfiguration;
        }

        public PackageCombinationConfiguration PackageCombinationConfiguration { get; }

        public override FeatureState? PlanMsiFeature(LaunchAction launchAction, string packageId, string featureId)
        {
            //if (packageId != PackageConfiguration.)
            //    return null;
            var installationType = this.PackageCombinationConfiguration.InstallationType;
            return FeatureState.Local;
        }

        /*public override void DetectAdditionalInformation()
        {
            this.PackageCombinationConfiguration.InstallationType =
                this.PackageCombinationConfiguration.CheckSqlServer64BitInstanceExists() ||
                this.PackageCombinationConfiguration.CheckSqlServer32BitInstanceInstanceExists()
                    ? InstallationType.MasterServer
                    : InstallationType.Client;
        }*/
    }
}