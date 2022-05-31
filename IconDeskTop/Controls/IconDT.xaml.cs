using IconDeskTop.Model;
using IconXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// IconDT.xaml 的交互逻辑
    /// </summary>
    public partial class IconDT : Button
    {
        public IconDT()
        {
            InitializeComponent();
        }

       





        public AppSetupPathArgs MyData
        {
            get { return (AppSetupPathArgs)GetValue(MyDataProperty); }
            set { SetValue(MyDataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyDataProperty =
            DependencyProperty.Register("MyData", typeof(AppSetupPathArgs), typeof(IconDT), new PropertyMetadata(default(AppSetupPathArgs)));

        private async  void Home_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(!File.Exists(IconDeskTop.Model.Resources.DocPath + "\\IconDesTop\\AppXml.xml"))
            {
                await AppIconXml.CreateHeader(IconXml.IconXml.Icon,
                IconDeskTop.Model.Resources.DocPath + "\\IconDesTop\\AppXml.xml",
                new System.Collections.ObjectModel.ObservableCollection<IconArgs>()
                {
                    new IconArgs()
                    {
                        AppArgs="",
                        IconPath = MyData.Icon,
                        AppProcess = MyData.Icon,
                        Lnk = MyData.lnk,
                        Name = MyData.AppName
                    }
                });
            }
            else
            {
                await AppIconXml.AddArgs(IconXml.IconXml.Icon,
                IconDeskTop.Model.Resources.DocPath + "\\IconDesTop\\AppXml.xml",
                new System.Collections.ObjectModel.ObservableCollection<IconArgs>()
                {
                    new IconArgs()
                    {
                        AppArgs="",
                        IconPath = MyData.Icon,
                        AppProcess = MyData.Icon,
                        Lnk = MyData.lnk,
                        Name = MyData.AppName
                    }
                });
            }
        }
            
    }
}
