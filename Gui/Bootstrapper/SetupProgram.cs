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
    using System.Windows.Threading;
    using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
    using Project.MainInstaller.Gui.Views;

    /// <summary>
    /// The base class to manage the bootstrapper
    /// </summary>
    public class SetupProgram : BootstrapperApplication
    {
        public static Dispatcher BootstrapperDispatcher { get; private set; }

        //private string[] argStrings;

        public static SetupWizard RootView { get; set; }
        public string BundleName => this.Engine.StringVariables["WixBundleName"];

        /// <summary>
        /// 
        /// </summary>
        protected override void Run()
        {
            // To get the command line arguments
            /*foreach (var commandLineArgs in this.Command.GetCommandLineArgs())
            {
                
            }*/

            MessageBox.Show(BundleName);

            try
            {
                this.Engine.CloseSplashScreen();

                BootstrapperDispatcher = Dispatcher.CurrentDispatcher;

                BootstrapperDispatcher.UnhandledException +=
                    (sender, args) =>
                    {
                        this.Engine.Log(LogLevel.Error, $"Critical bootstrapper exception: {args.Exception}");
                    };

                RootView = new SetupWizard(this);
                RootView.Closed += (sender, args) => BootstrapperDispatcher.InvokeShutdown();
                this.Engine.Detect();

                RootView.Show();
                Dispatcher.Run();

            }
            catch (Exception e)
            {
                this.Engine.Log(LogLevel.Error, $"Critical bootstrapper exception: {e}");
                throw e;
            }
        }

        public void CloseUIAndExit()
        {
            RootView.Dispatcher.BeginInvoke(new Action(() => RootView.Close()));
        }
    }
}
