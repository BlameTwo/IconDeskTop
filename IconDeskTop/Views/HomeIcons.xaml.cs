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
            WindowBlur blur = new WindowBlur();
            blur.SetIsEnabled(this, true);
            Loaded += HomeIcons_Loaded;
        }

        private void HomeIcons_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Normal;
            this.WindowStyle = System.Windows.WindowStyle.None;
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
            this.Left = 0.0;
            this.Top = 0.0;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
        }
    }
}
