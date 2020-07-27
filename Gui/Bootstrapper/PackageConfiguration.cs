#region (C) Koninklijke Philips Electronics N.V. 2019
//
// All rights are reserved. Reproduction or transmission in whole or in part, in 
// any form or by any means, electronic, mechanical or otherwise, is prohibited 
// without the prior written permission of the copyright owner.
// 
#endregion

namespace Project.MainInstaller.Gui.Bootstrapper
{
    using System.Collections.Generic;

    /// <summary>
    ///
    /// </summary>
    public static class PackageConfiguration
    {
        //public const string Netfx472Installer = "Netfx472";
        //public const string VcRedistributable2013Installer = "vc120";
        //public const string VcRedistributable2017Installer = "vc140";
        //public const string CwisEncryptInstaller64 = "CwisEncryptInstall64";
        //public const string CwisEncryptInstaller = "CwisEncryptInstall";
        //public const string SqlNativeClientInstaller = "SQLNativeClient";
        public const string SetupProject = "SetupProject2";

        public static IList<Package> PackageList { get; } =
            new List<Package>
            {
                new Package
                {
                    PackageId = SetupProject,
                    DisplayName = "Setup Project Test",
                }
                /*new Package
                {
                    PackageId = Netfx35RedistPackageId,
                    DisplayName = Localisation.PackageConfiguration_PackageList__NET_Framework_3_5,
                    Architectures = Architecture.X86 | Architecture.X64,
                    InstallationTypes = new[]
                        {InstallationType.Client, InstallationType.MasterServer, InstallationType.SlaveServer},
                    IsRemovable = false
                },
                new Package
                {
                    PackageId = Netfx462RedistPackageId,
                    DisplayName = Localisation.PackageConfiguration_PackageList__NET_Framework_4_6_2,
                    Architectures = Architecture.X86 | Architecture.X64,
                    InstallationTypes = new[]
                        {InstallationType.Client, InstallationType.MasterServer, InstallationType.SlaveServer},
                    IsRemovable = false
                },
                new Package
                {
                    PackageId = Sql2014ExpressPackage86Id,
                    DisplayName = Localisation
                        .PackageConfiguration_PackageList_SQL_Server_2014_with_Advanced_Services__32_bit_,
                    Architectures = Architecture.X86,
                    InstallationTypes = new[] {InstallationType.MasterServer},
                    AdditionalPredicate =
                        packageCombinationConfiguration => packageCombinationConfiguration.SqlServerInstallationType !=
                                                           SqlServerInstallationType.None,
                    IsRemovable = false,
                    IsRepairable = false
                },
                new Package
                {
                    PackageId = Sql2014ExpressUpgradePackage86Id,
                    DisplayName = Localisation
                        .PackageConfiguration_PackageList_Upgrade_to_SQL_Server_2014_with_Advanced_Services__32_bit_,
                    Architectures = Architecture.X86 | Architecture.X64,
                    InstallationTypes = new[] {InstallationType.MasterServer},
                    AdditionalPredicate =
                        packageCombinationConfiguration =>
                            packageCombinationConfiguration.SqlServerInstallationType ==
                            SqlServerInstallationType.UpgradeMajor
                            && packageCombinationConfiguration.CheckSqlServer32BitInstanceInstanceExists(),
                    IsRemovable = false,
                    IsRepairable = false,
                    AcquireDuringLayout = false
                },
                new Package
                {
                    PackageId = Sql2014ExpressPatchPackage86Id,
                    DisplayName = Localisation
                        .PackageConfiguration_PackageList_SQL_Server_2014_with_Advanced_Services__32_bit__patch,
                    Architectures = Architecture.X86 | Architecture.X64,
                    InstallationTypes = new[] {InstallationType.MasterServer},
                    AdditionalPredicate =
                        packageCombinationConfiguration => packageCombinationConfiguration.SqlServerInstallationType ==
                                                           SqlServerInstallationType.UpgradeMinor
                                                           && packageCombinationConfiguration
                                                               .CheckSqlServer32BitInstanceInstanceExists(),
                    IsRemovable = false,
                    IsRepairable = false,
                    AcquireDuringLayout = false
                },
                new Package
                {
                    PackageId = Sql2014ExpressPackage64Id,
                    DisplayName = Localisation
                        .PackageConfiguration_PackageList_SQL_Server_2014_with_Advanced_Services__64_bit_,
                    Architectures = Architecture.X64,
                    InstallationTypes = new[] {InstallationType.MasterServer},
                    AdditionalPredicate =
                        packageCombinationConfiguration => packageCombinationConfiguration.SqlServerInstallationType !=
                                                           SqlServerInstallationType.None,
                    IsRemovable = false,
                    IsRepairable = false
                },
                new Package
                {
                    PackageId = Sql2014ExpressUpgradePackage64Id,
                    DisplayName = Localisation
                        .PackageConfiguration_PackageList_Upgrade_to_SQL_Server_2014_with_Advanced_Services__64_bit_,
                    Architectures = Architecture.X64,
                    InstallationTypes = new[] {InstallationType.MasterServer},
                    AdditionalPredicate =
                        packageCombinationConfiguration => packageCombinationConfiguration.SqlServerInstallationType ==
                                                           SqlServerInstallationType.UpgradeMajor
                                                           && packageCombinationConfiguration
                                                               .CheckSqlServer64BitInstanceExists(),
                    IsRemovable = false,
                    IsRepairable = false,
                    AcquireDuringLayout = false
                },
                new Package
                {
                    PackageId = Sql2014ExpressPatchPackage64Id,
                    DisplayName = Localisation
                        .PackageConfiguration_PackageList_SQL_Server_2014_with_Advanced_Services__64_bit__patch,
                    Architectures = Architecture.X64,
                    AdditionalPredicate =
                        packageCombinationConfiguration => packageCombinationConfiguration.SqlServerInstallationType ==
                                                           SqlServerInstallationType.UpgradeMinor &&
                                                           packageCombinationConfiguration
                                                               .CheckSqlServer64BitInstanceExists(),
                    IsRemovable = false,
                    IsRepairable = false,
                    AcquireDuringLayout = false
                }*/
            };
    }
}