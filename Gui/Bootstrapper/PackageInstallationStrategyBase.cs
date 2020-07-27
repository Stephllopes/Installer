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
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
    using Project.MainInstaller.Gui.Interfaces;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TParam"></typeparam>
    /// <typeparam name="TInstallationType"></typeparam>
    public class PackageInstallationStrategyBase<TParam, TInstallationType> : IPackageInstallationStrategy
    {
        private readonly TParam _param;

        public PackageInstallationStrategyBase(IList<Package> packageList,
            TParam param, IInstallationTypeProvider<TInstallationType> installationTypeProvider)
        {
            this._param = param;
            this.PackageList = packageList;
            this.InstallationTypeProvider = installationTypeProvider;
        }

        public IList<Package> PackageList { get; }
        public IInstallationTypeProvider<TInstallationType> InstallationTypeProvider { get; }

        public virtual FeatureState? PlanMsiFeature(LaunchAction launchAction, string packageId, string featureId)
        {
            // Let Burn decide what to do with packages we don't know about
            if (this.PackageList.All(x => x.PackageId != packageId))
                return null;

            // Unless stated otherwise, install the feature.
            return FeatureState.Local;
        }

        public virtual RequestState? PlanPackage(LaunchAction launchAction, string packageId)
        {
            var installationType = this.InstallationTypeProvider.InstallationType;

            //var architecture = SystemInformationUtilities.Is64BitSystem() ? Architecture.X64 : Architecture.X86;
            var packageConfig = this.PackageList.FirstOrDefault(x => x.PackageId == packageId);
            switch (launchAction)
            {
                case LaunchAction.Layout:
                    if (packageConfig == null
                        || packageConfig.AcquireDuringLayout)
                    {
                        return RequestState.Present;
                    }
                    else
                    {
                        return RequestState.None;
                    }
                case LaunchAction.Uninstall:
                    if (packageConfig == null
                        || packageConfig.IsRemovable)
                        return RequestState.Absent;
                    return RequestState.None;
                case LaunchAction.Cache:
                case LaunchAction.Install:
                case LaunchAction.Modify:
                    if (packageConfig == null)
                        return RequestState.Present;
                    else
                        return RequestState.Absent;
                case LaunchAction.Repair:
                    if (packageConfig == null || packageConfig.IsRepairable)
                    {
                        return RequestState.Repair;
                    }
                    return RequestState.None;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return null;
        }

        public virtual void DetectAdditionalInformation()
        {
        }

        public virtual string GetPackageNameFromId(string packageId)
        {
            var packageConfig = this.PackageList.FirstOrDefault(x => x.PackageId == packageId);
            if (packageConfig != null)
                return packageConfig.DisplayName;
            return packageId;
        }
    }
}