using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TelerikOutlook.Services.Interfaces;
using TelerikOutLook.Business;
using TelerikOutLook.Core;

namespace TelerikOutLook.Modules.Mails.ViewModels
{
    public class MailListViewModel : ViewModelBase
    {
        private string _title = "Default";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private readonly IMailService _mailService;
        private readonly IDialogService _dialogService;
        private MailMessage _selectedMessage;
        public MailMessage SelectedMessage
        {
            get { return _selectedMessage; }
            set { SetProperty(ref _selectedMessage, value); }
        }

        private ObservableCollection<MailMessage> _messages;
        public ObservableCollection<MailMessage> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }
        private DelegateCommand<object> _selected;
        public DelegateCommand<object> Selected =>
            _selected ?? (_selected = new DelegateCommand<object>(ExecuteTestCommand));

        private DelegateCommand<string>  _messageCommand;
        public DelegateCommand<string> MessageCommand =>       
             _messageCommand ?? ( _messageCommand = new DelegateCommand<string>(ExecuteCommandName));

        void ExecuteCommandName(string parameter)
        {
            _dialogService.Show("MessageView",null,null);
        }
        void ExecuteTestCommand(object parameter)
        {
            SelectedMessage = parameter as MailMessage;
        }

        public MailListViewModel(IMailService mailService, IDialogService dialogService)
        {
            this._mailService = mailService;
            this._dialogService = dialogService;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            var folder = navigationContext.Parameters.GetValue<string>(FolderParameters.FolderKey);

            switch (folder)
            {
                case FolderParameters.Inbox:
                    {
                        Messages = new ObservableCollection<MailMessage>(_mailService.GetInboxItems());
                        break;
                    }
                case FolderParameters.Deleted:
                    {
                        Messages = new ObservableCollection<MailMessage>(_mailService.GetDeletedItems());
                        break;
                    }
                case FolderParameters.Sent:
                    {
                        Messages = new ObservableCollection<MailMessage>(_mailService.GetSentItems());
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
