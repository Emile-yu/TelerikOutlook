using TelerikOutLook.Modules.Contacts.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using TelerikOutLook.Modules.Contacts.Menus;
using TelerikOutLook.Modules.Contacts.ViewModels;

namespace TelerikOutLook.Modules.Contacts
{
    public class ContactsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<RegionManager>();
            //regionManager.RegisterViewWithRegion(Core.RegionNames.OutlookGroupRegion, typeof(ViewA));
            regionManager.RegisterViewWithRegion(Core.RegionNames.OutlookGroupRegion, typeof(ContactsGroup));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
        }
    }
}