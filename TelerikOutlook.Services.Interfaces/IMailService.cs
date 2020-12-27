using System;
using System.Collections.Generic;
using System.Text;
using TelerikOutLook.Business;

namespace TelerikOutlook.Services.Interfaces
{
    public interface IMailService
    {
        IList<MailMessage> GetInboxItems();

        IList<MailMessage> GetSentItems();

        IList<MailMessage> GetDeletedItems();
    }
}
