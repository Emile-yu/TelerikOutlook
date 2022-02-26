using TelerikOutLook.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using TelerikOutLook.Modules.Mails;
using TelerikOutLook.Modules.Contacts;
using TelerikOutLook.Core;
using Prism.Regions;
using TelerikOutLook.Core.Regions;
using Prism.Services.Dialogs;
using TelerikOutLook.Core.Dialog;
using System.Windows.Threading;
using System;

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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //handler for exception global
            this.DispatcherUnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
            e.Handled = true;
        }

        protected override void OnInitialized()
        {
            var login = Container.Resolve<loginScreen>();
            bool? res = login.ShowDialog();
            if (res.HasValue && res.Value)
                base.OnInitialized();
            else
            {
                Application.Current.Shutdown();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();

            containerRegistry.RegisterDialogWindow<RibbonWindow>();

            containerRegistry.RegisterSingleton<IDialogService, MyDialogService>();
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
