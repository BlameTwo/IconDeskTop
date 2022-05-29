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
    /// HomeIconDT.xaml 的交互逻辑
    /// </summary>
    public partial class HomeIconDT : Button
    {
        public HomeIconDT()
        {
            InitializeComponent();
            this.Click += HomeIconDT_Click;
        }

        private void HomeIconDT_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(MyData.Prcess,MyData.ProcessArg);
        }

        public HomeIconArgs MyData
        {
            get { return ( HomeIconArgs)GetValue(MyDataProperty); }
            set { SetValue(MyDataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyDataProperty =
            DependencyProperty.Register("MyData", typeof( HomeIconArgs), typeof(HomeIconDT), new PropertyMetadata(default(HomeIconDT)));
    }
}
