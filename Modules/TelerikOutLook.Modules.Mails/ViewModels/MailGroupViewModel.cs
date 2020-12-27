using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikOutLook.Business;
using TelerikOutLook.Core;

namespace TelerikOutLook.Modules.Mails.ViewModels
{
    public class MailGroupViewModel : ViewModelBase
    {
        private ObservableCollection<NavigationItem> _items;
        public ObservableCollection<NavigationItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        private readonly IApplicationCommands _applicationCommands;
        private DelegateCommand<NavigationItem> _selectedItemChanged;
        public DelegateCommand<NavigationItem> SelectedItemChanged =>
            _selectedItemChanged ?? (_selectedItemChanged = new DelegateCommand<NavigationItem>(ExecuteSelectedItemChanged));

        void ExecuteSelectedItemChanged(NavigationItem parameter)
        {
            if (parameter != null)
                this._applicationCommands.NavigateCommand.Execute(parameter.NavigationPath);
        }

        public MailGroupViewModel(IApplicationCommands applicationCommands)
        {
            GenerateMenu();
            this._applicationCommands = applicationCommands;
        }

        private void GenerateMenu()
        {
            Items = new ObservableCollection<NavigationItem>();

            var root = new NavigationItem() { Caption = "Personal Folder", NavigationPath = "MailList?id=Default", IsExpanded = true };
            root.Items.Add(new NavigationItem() { Caption = Properties.Resources.Folder_Inbox, NavigationPath = GetNavigationPath(FolderParameters.Inbox) });
            root.Items.Add(new NavigationItem() { Caption = Properties.Resources.Folder_Deleted, NavigationPath = GetNavigationPath(FolderParameters.Deleted) });
            root.Items.Add(new NavigationItem() { Caption = Properties.Resources.Folder_Sent, NavigationPath = GetNavigationPath(FolderParameters.Sent) });


            Items.Add(root);

        }

        string GetNavigationPath(string folder)
        {
            return $"MailList?{FolderParameters.FolderKey}={folder}";
        }
    }

    public class FolderParameters
    {
        public const string FolderKey = "Folder";

        public const string Inbox = "Inbox";

        public const string Deleted = "Deleted";

        public const string Sent = "Sent";

    }
}
