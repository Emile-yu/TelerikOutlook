﻿using System;
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
using TelerikOutLook.Core;
using TelerikOutLook.Modules.Contacts.Menus;

namespace TelerikOutLook.Modules.Contacts.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    [DependentView(RegionNames.RibbonRegion, typeof(HomeTab))]
    public partial class ViewA : UserControl
    {
        public ViewA()
        {
            InitializeComponent();
        }
    }
}
