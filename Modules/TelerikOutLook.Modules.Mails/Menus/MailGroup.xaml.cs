using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using TelerikOutLook.Business;
using TelerikOutLook.Core;
using TelerikOutLook.Modules.Mails.ViewModels;

namespace TelerikOutLook.Modules.Mails.Menus
{
    /// <summary>
    /// Interaction logic for MailGroup.xaml
    /// </summary>
    public partial class MailGroup : RadOutlookBarItem, IOutlookBarItem
    {
        NavigationItem _selectedItem;

        public MailGroup()
        {
            InitializeComponent();
            _dataTree.Loaded += _DataTree_Loaded;
        }

        private void _DataTree_Loaded(object sender, RoutedEventArgs e)
        {
            //_dataTree.Loaded -= _DataTree_Loaded;
            //var node = _dataTree.Parent;
            //var nodeToSelect = node.
            TreeViewItem item = (TreeViewItem)(_dataTree.ItemContainerGenerator.ContainerFromIndex(_dataTree.Items.CurrentPosition));
            if (item != null)
            {
                item.IsSelected = true;

            }
           
        }

        public string DefaultNavigationPath
        {
            get
            {
                var item = _dataTree.SelectedItem as NavigationItem;
                if (item != null)
                    return item.NavigationPath;

                //((MailGroupViewModel)DataContext).Items.FirstOrDefault(x => x.Caption == Properties.Resources.Folder_Inbox);
                return $"MailList?{FolderParameters.FolderKey}={Properties.Resources.Folder_Inbox}";
            }
        }
    }
}
