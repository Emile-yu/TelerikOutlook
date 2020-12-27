using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TelerikOutlook.Services.Interfaces;
using TelerikOutLook.Business;

namespace TelerikOutlook.Services
{
    public class MailService : IMailService
    {
        static List<MailMessage> InboxItems = new List<MailMessage>()
        {
            new MailMessage()
            {
                Id = 1,
                From = "Micheal@gmail.com",
                To = new ObservableCollection<string>()
                {
                    "Claire@gmail.com",
                    "Emil@gmail.com"
                },
                Subject = "this is a test email",
                Body = "this is a body of an email",
                DateSent = DateTime.Now
            },
            new MailMessage()
            {
                Id = 2,
                From = "Micheal@gmail.com",
                To = new ObservableCollection<string>()
                {
                    "Claire@gmail.com",
                    "Emil@gmail.com"
                },
                Subject = "this is a test email 2",
                Body = "this is a body of an email 2",
                DateSent = DateTime.Now.AddDays(-1)
            },
            new MailMessage()
            {
                Id = 3,
                From = "Micheal@gmail.com",
                To = new ObservableCollection<string>()
                {
                    "Claire@gmail.com",
                    "Emil@gmail.com"
                },
                Subject = "this is a test email 3",
                Body = "this is a body of an email 3",
                DateSent = DateTime.Now.AddDays(-3)
            },
        };
        static List<MailMessage> SentItems = new List<MailMessage>();

        static List<MailMessage> DeletedItems = new List<MailMessage>();

        public IList<MailMessage> GetDeletedItems()
        {
            return DeletedItems;
        }

        public IList<MailMessage> GetInboxItems()
        {
            return InboxItems;
        }

        public IList<MailMessage> GetSentItems()
        {
            return SentItems;
        }
    }
}
