using TelerikOutLook.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using TelerikOutLook.Modules.Mails;
using TelerikOutLook.Modules.Contacts;
using TelerikOutLook.Core;
using Prism.Regions;
using TelerikOutLook.Core.Regions;

namespace TelerikOutLook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
       
        protected override Window CreateShell()
        {
            /*Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            loginScreen loginScreen = new loginScreen();

            bool? res = loginScreen.ShowDialog();
            Application.Current.MainWindow = null;
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            if (res.HasValue && res.Value)
            {
                return Container.Resolve<MainWindow>();
            }
            Window w = new Window();
            w.Title = "Erreur";
            return w;*/
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MailsModule>();
            moduleCatalog.AddModule<ContactsModule>();
        }

        protected override void ConfigureDefaultRegionBehaviors(IRegionBehaviorFactory regionBehaviors)
        {
            base.ConfigureDefaultRegionBehaviors(regionBehaviors);
            regionBehaviors.AddIfMissing(DependentViewRegionBehavior.BehaviorKey, typeof(DependentViewRegionBehavior));
        }
    }
}
