#region (C) Koninklijke Philips Electronics N.V. 2019
//
// All rights are reserved. Reproduction or transmission in whole or in part, in 
// any form or by any means, electronic, mechanical or otherwise, is prohibited 
// without the prior written permission of the copyright owner.
// 
#endregion

namespace ProjectMainInstaller.Gui.ViewModels
{
    using System.Windows.Input;
    using ProjectMainInstaller.Gui.Utils;
    using ProjectMainInstaller.Gui.Bootstrapper;

    /// <summary>
    /// abstract class to control all viewModel classes
    /// </summary>
    public abstract class PageViewModel : BootstrapperAwareViewModel
    {
        private bool canGoToNextPage;
        private bool canGoToPreviousPage;
        private bool canCancel;

        public SetupWizardViewModel setupWizardViewModel { get; }

        public virtual ICommand CancelCommand { get; }
        public virtual ICommand NextPageCommand { get; }
        public virtual ICommand PreviousPageCommand { get; }

        protected PageViewModel(SetupWizardViewModel setupWizardViewModel)
            : base(setupWizardViewModel.Bootstrapper)
        {
            this.setupWizardViewModel = setupWizardViewModel;

            this.CancelCommand = new SimpleCommand(_ => this.setupWizardViewModel.RequestCancellation(),
                _ => this.CanCancel && !setupWizardViewModel.CancelButtonPressed && !setupWizardViewModel.ShouldCancel);
            this.NextPageCommand = new SimpleCommand(_ => this.BeginNextPhase(), _ => this.CanGoToNextPage);
            this.PreviousPageCommand = new SimpleCommand(_ => this.GoToPreviousPage(), _ => this.CanGoToPreviousPage);
        }

        public bool CanCancel
        {
            get => this.canCancel;
            set
            {
                if (this.canCancel != value)
                {
                    this.canCancel = value;
                    this.OnPropertyChanged(nameof(this.CanCancel));
                }
            }
        }

        public bool CanGoToPreviousPage
        {
            get => this.canGoToPreviousPage;
            set
            {
                if (this.canGoToPreviousPage != value)
                {
                    this.canGoToPreviousPage = value;
                    this.OnPropertyChanged(nameof(this.CanGoToPreviousPage));
                }
            }
        }

        public bool CanGoToNextPage
        {
            get => this.canGoToNextPage;
            set
            {
                if (this.canGoToNextPage != value)
                {
                    this.canGoToNextPage = value;
                    this.OnPropertyChanged(nameof(this.CanGoToNextPage));
                }
            }
        }

        public void BeginNextPhase()
        {
            this.setupWizardViewModel.GoToPage(this.setupWizardViewModel.NextPageType);
        }

        private void GoToPreviousPage()
        {
            this.setupWizardViewModel.GoToPage(this.setupWizardViewModel.PreviousPageType);
        }
    }
}
