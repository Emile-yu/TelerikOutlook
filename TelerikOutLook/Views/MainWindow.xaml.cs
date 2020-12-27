using Prism.Regions;
using System.Windows;
using Telerik.Windows.Controls;
using TelerikOutLook.Core;

namespace TelerikOutLook.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RadRibbonWindow
    {
        private readonly IApplicationCommands _applicationCommands;

        public MainWindow(IApplicationCommands applicationCommands)
        {
            InitializeComponent();
            this._applicationCommands = applicationCommands;
        }

        private void RadOutlookBar_SelectionChanged(object sender, RadSelectionChangedEventArgs e)
        {
            //RadOutlookBarItem newSelectedItem = (sender as RadOutlookBar).SelectedItem as RadOutlookBarItem;
            var item = ((RadOutlookBar)sender).SelectedItem as IOutlookBarItem;

            if (item != null)
            {
                _applicationCommands.NavigateCommand.Execute(item.DefaultNavigationPath);
                //_regionManager.RequestNavigate(RegionNames.ContentRegion, item.DefaultNavigationPath);
                //todo
            }
        }
    }
}
