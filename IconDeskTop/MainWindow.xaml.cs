using IconDeskTop.Models;
using IconDeskTop.Theme;
using IconDeskTop.ViewModels;
using IconDeskTop.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IconDeskTop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            this.DataContext = new MainWindowVM();

        }


        public static HomeIcons Home = new HomeIcons();
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            double x = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
            double y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
            this.Top = y - (y / 2) + 300;
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, (-20), 0x80);
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, int NewLong);

        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Home.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ThemeStat.ThemeApply(Theme.Theme.Light);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

            ThemeStat.ThemeApply(Theme.Theme.Dark);
        }
    }


}