using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows;
using Telerik.Windows.Controls;
using TelerikOutLook.Core;
using ViewModelBase = TelerikOutLook.Core.ViewModelBase;

namespace TelerikOutLook.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private readonly IRegionManager _regionManager;

        private DelegateCommand<string> _navigateCommand;
        public DelegateCommand<string> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(ExecuteCommandName));

        public MainWindowViewModel(IRegionManager regionManager, IApplicationCommands applicationCommands)
        {
            this._regionManager = regionManager;
            applicationCommands.NavigateCommand.RegisterCommand(NavigateCommand);
        }

        void ExecuteCommandName(string navigationPath)
        {
            if (string.IsNullOrEmpty(navigationPath))
            {
                throw new ArgumentNullException();
            }
            this._regionManager.RequestNavigate(RegionNames.ContentRegion, navigationPath);
        }



    }
}
