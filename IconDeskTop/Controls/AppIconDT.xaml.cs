using IconXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace IconDeskTop.Controls
{
    /// <summary>
    /// AppIconDT.xaml 的交互逻辑
    /// </summary>
    public partial class AppIconDT : Button
    {
        public AppIconDT()
        {
            InitializeComponent();
        }




        public IconArgs MyData
        {
            get { return (IconArgs)GetValue(MyDataProperty); }
            set { SetValue(MyDataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyDataProperty =
            DependencyProperty.Register("MyData", typeof(IconArgs), typeof(AppIconDT), new PropertyMetadata(default(IconArgs)));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(MyData.AppProcess, MyData.AppArgs);
        }
    }
}
