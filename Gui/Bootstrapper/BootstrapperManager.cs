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
    using System.Windows;
    using System.ComponentModel;
    using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
    using Project.MainInstaller.Gui.Interfaces;

    /// <summary>
    /// class to manage the bootstrapper events
    /// </summary>
    public abstract class BootstrapperManager
    {
        public const int CancelErrorCode = 1602;
        private LaunchAction _launchAction;

        public abstract IPackageInstallationStrategy PackageInstallationStrategy { get; }

        protected BootstrapperManager(SetupProgram bootstrapper)
        {
            this.Bootstrapper = bootstrapper;

            bootstrapper.DetectComplete += this.Bootstrapper_DetectComplete;
            bootstrapper.PlanBegin += this.Bootstrapper_PlanBegin;
            bootstrapper.PlanMsiFeature += this.Bootstrapper_PlanMsiFeature;
            bootstrapper.PlanComplete += Bootstrapper_PlanComplete;
        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Bootstrapper_DetectComplete(object sender, DetectCompleteEventArgs e)
        {
            this.ExecuteOnDispatcher(this.OnBootstrapperShouldGoToFirstPage);
        }

        private void Bootstrapper_PlanComplete(object sender, PlanCompleteEventArgs e)
        {
            this.ApplyAction();
        }

        private void Bootstrapper_PlanBegin(object sender, PlanBeginEventArgs e)
        {
            //this.Log(LogLevel.Debug,
            //    $"Bootstrapper has called {nameof(this.Bootstrapper_PlanBegin)}");

            this.ExecuteOnDispatcherOrImmediateIfNotAvailable(
                this.PlanBegin);
        }

        private void Bootstrapper_PlanMsiFeature(object sender, PlanMsiFeatureEventArgs e)
        {
            //this.Log(LogLevel.Standard,
            //    $"Bootstrapper planning MsiFeature {e.FeatureId} of {e.PackageId}!");
            var state = this.PackageInstallationStrategy.PlanMsiFeature(this.LaunchAction, e.PackageId, e.FeatureId);
            if (state != null)
                e.State = (FeatureState)state;
        }

        /// <summary>
        ///     Called when the bootstrapper begins planning the installation
        /// </summary>
        protected abstract void PlanBegin();

        /// <summary>
        ///     Tells the bootstrapper to begin applying the planned changes.
        /// </summary>
        public void ApplyAction()
        {
            this.Bootstrapper.Engine.Apply(this.WindowHandle);
        }

        /// <summary>
        ///     The action that will be executed when the installaiton will begin.
        /// </summary>
        public LaunchAction LaunchAction
        {
            get => this._launchAction;
            set
            {
                if (this._launchAction != value)
                {
                    this._launchAction = value;
                    this.OnPropertyChanged(nameof(this.LaunchAction));
                    //this.Log(LogLevel.Standard,
                    //    $"{nameof(this.LaunchAction)} changed: {this.LaunchAction}");
                }
            }
        }

        protected abstract void OnBootstrapperShouldGoToFirstPage();

        public void ExecuteOnDispatcher(Action action)
        {
            SetupProgram.BootstrapperDispatcher.Invoke(action);
        }

        public void ExecuteOnDispatcherOrImmediateIfNotAvailable(Action action)
        {
            if (this.IsVisible)
                this.ExecuteOnDispatcher(action);
            else
                action();
        }

        /// <summary>
        ///     IsVisible is true when the GUI should be visible. This is false on silent installs.
        /// </summary>
        public bool IsVisible => this.Bootstrapper.Command.Display == Display.Full ||
                                 this.Bootstrapper.Command.Display == Display.Passive;

        public bool CancelButtonPressed { get; set; }

        public bool ShouldCancel { get; set; }

        /// <summary>
        ///     The handle to the main bootstrapper window.
        /// </summary>
        public IntPtr WindowHandle { get; set; }

        /// <summary>
        ///     The Wix bootstrapper.
        /// </summary>
        public SetupProgram Bootstrapper { get; }

        protected void ShutDownWithCancelCode()
        {
            this.Bootstrapper.Engine.Quit(CancelErrorCode);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RequestCancellation()
        {
            this.CancelButtonPressed = true;
            var result = ShowCancelDialog();
            if (result == MessageBoxResult.Yes)
            {
                this.ShouldCancel = true;
                Bootstrapper.Engine.Quit(0);
            }
            else
            {
                this.CancelButtonPressed = false;
            }
        }

        protected abstract MessageBoxResult ShowCancelDialog();
    }
}