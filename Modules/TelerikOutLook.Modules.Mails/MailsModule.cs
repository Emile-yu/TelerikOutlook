using TelerikOutLook.Modules.Mails.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using TelerikOutLook.Modules.Mails.Menus;
using Prism.Mvvm;
using TelerikOutLook.Modules.Mails.ViewModels;
using TelerikOutlook.Services.Interfaces;
using TelerikOutlook.Services;

namespace TelerikOutLook.Modules.Mails
{
    public class MailsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<RegionManager>();
            //regionManager.RegisterViewWithRegion(Core.RegionNames.ContentRegion, typeof(ViewA));
            //regionManager.RegisterViewWithRegion(Core.RegionNames.RibbonRegion, typeof(HomeTab));
            regionManager.RegisterViewWithRegion(Core.RegionNames.OutlookGroupRegion, typeof(MailGroup));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<MailGroup, MailGroupViewModel>();

            containerRegistry.RegisterForNavigation<MailList, MailListViewModel>();

            containerRegistry.RegisterSingleton<IMailService, MailService>();

            containerRegistry.RegisterDialog<MessageView, MessageViewModel>();
        }
    }
}