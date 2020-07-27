#region (C) Koninklijke Philips Electronics N.V. 2019
//
// All rights are reserved. Reproduction or transmission in whole or in part, in 
// any form or by any means, electronic, mechanical or otherwise, is prohibited 
// without the prior written permission of the copyright owner.
// 
#endregion

namespace Project.MainInstaller.Gui.ViewModels
{
    using System;
    using System.Windows;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Project.MainInstaller.Gui.Utils;
    using Project.MainInstaller.Gui.Enum;
    using Project.MainInstaller.Gui.Views.Pages;
    using Project.MainInstaller.Gui.Bootstrapper;

    /// <summary>
    /// class to control commands of the SetupWizard class
    /// </summary>
    public class SetupWizardViewModel : BootstrapperManager, INotifyPropertyChanged
    {
        private List<PageType> viewOrderList;
        private PageType currentPageType;
        private int posCurrentType = 0;
        private UIElement currentPageView;

        public SimpleCommand CancelCommand { get; set; }
        public SimpleCommand NextPageCommand { get; set; }

        public SetupWizardViewModel(SetupProgram bootstrapper) : base(bootstrapper)
        {
            //Load the sequence of the pages
            LoadPagesSequence();
            this.CancelCommand = new SimpleCommand(_ => this.RequestCancellation(),
                _ => !CancelButtonPressed && !ShouldCancel);
            this.NextPageCommand = new SimpleCommand(_ => this.GoToPage(NextPageType), _ => true);
        }

        private PageType? GetNextPage()
        {
            return viewOrderList[++posCurrentType];
        }

        private PageType? GetPreviousPage()
        {
            return viewOrderList[--posCurrentType];
        }

        public PageType CurrentPageType
        {
            get => this.currentPageType;
            set
            {
                this.currentPageType = value;
                this.OnPropertyChanged(nameof(this.CurrentPageType));
            }
        }

        public UIElement CurrentPageView
        {
            get => this.currentPageView;
            set
            {
                this.currentPageView = value;
                this.OnPropertyChanged(nameof(this.CurrentPageView));
            }
        }

        public PageType NextPageType
        {
            get
            {
                if (posCurrentType + 1 < viewOrderList.Count)
                {
                    return (PageType)this.GetNextPage();
                }

                return PageType.InitializationStep; //the last
            }
        }

        public PageType PreviousPageType
        {
            get
            {
                if (posCurrentType - 1 >= 0)
                {
                    return (PageType)this.GetPreviousPage();
                }

                return PageType.SetupWizard; //the first
            }
        }

        private void LoadPagesSequence()
        {
            // TODO: Make the execution list according the paramethers and configurations
            viewOrderList = new List<PageType>();
            viewOrderList.Add(PageType.SetupWizard);
            viewOrderList.Add(PageType.InitializationStep);
            viewOrderList.Add(PageType.WelcomeStep);
            viewOrderList.Add(PageType.LicenseStep);
            viewOrderList.Add(PageType.PrerequisiteCheckStep);
            viewOrderList.Add(PageType.FeatureSelectionStep);
            viewOrderList.Add(PageType.DatabaseServerInputStep);
            viewOrderList.Add(PageType.LanguageSelectionStep);
            viewOrderList.Add(PageType.StudyTypeStep);
            viewOrderList.Add(PageType.ReviewSettingStep);
            viewOrderList.Add(PageType.InstallationStep);
            viewOrderList.Add(PageType.FinishStep);
        }

        private UIElement CreateNewView(PageType pageType)
        {
            switch (pageType)
            {
                //case PageType.FatalErrorStep:
                //    return new FatalErrorStep(this);
                case PageType.InitializationStep:
                    return new InitializationStep(this);
                //case PageType.InstallationModeStep:
                //    return new InstallationModeStep(this);
                case PageType.WelcomeStep:
                    return new WelcomeStep(this);
                case PageType.LicenseStep:
                    return new LicenseStep(this);
                //case PageType.PreviousInstallationFoundStep:
                //    return new PreviousInstallationFoundStep(this);
                //case PageType.PrerequisiteAutoInstallStep:
                //    return new PrerequisiteAutoInstallStep(this);
                //case PageType.LegacyUninstallationStep:
                //    return new LegacyUninstallationStep(this);
                case PageType.PrerequisiteCheckStep:
                    return new PrerequisiteCheckStep(this);
                case PageType.FeatureSelectionStep:
                    return new FeatureSelectionStep(this);
                case PageType.DatabaseServerInputStep:
                    return new DatabaseServerInputStep(this);
                case PageType.LanguageSelectionStep:
                    return new LanguageSelectionStep(this);
                case PageType.StudyTypeStep:
                    return new StudyTypeStep(this);
                case PageType.ReviewSettingStep:
                    return new ReviewSettingStep(this);
                case PageType.InstallationStep:
                    return new InstallationStep(this);
                case PageType.FinishStep:
                    return new FinishStep(this);
            }
            throw new ArgumentOutOfRangeException(nameof(pageType));
        }

        public void GoToPage(PageType pageType)
        {
            if (pageType == this.CurrentPageType)
                return;

            this.CurrentPageType = pageType;

            FrameworkElement view = null;
            view = (FrameworkElement)this.CreateNewView(pageType);
            this.CurrentPageView = view;
        }

        protected override MessageBoxResult ShowCancelDialog()
        {
            // se nao for silent ou autoupdate
            var result = MessageBox.Show(SetupProgram.RootView,
                "Are you sure you want to cancel the installation?",
                "",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            return result;
        }

        protected override void OnBootstrapperShouldGoToFirstPage()
        {
            this.GoToFirstPage();
        }

        public void GoToFirstPage()
        {
            posCurrentType++;
            this.GoToPage(PageType.InitializationStep);
        }

    }
}
