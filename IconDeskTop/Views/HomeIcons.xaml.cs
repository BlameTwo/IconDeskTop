using IconDeskTop.Models;
using IconDeskTop.ViewModels;
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
using System.Windows.Shapes;

namespace IconDeskTop.Views
{
    /// <summary>
    /// HomeIcons.xaml 的交互逻辑
    /// </summary>
    public partial class HomeIcons : Window
    {
        public HomeIcons()
        {
            InitializeComponent();
            this.DataContext = new HomeIconsVM();
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth-50;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight-50;
            Loaded += HomeIcons_Loaded;
            this.Closing += HomeIcons_Closing;
        }

        private void HomeIcons_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //临时处理
            this.Hide();
            e.Cancel = true;
        }

        private void HomeIcons_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
