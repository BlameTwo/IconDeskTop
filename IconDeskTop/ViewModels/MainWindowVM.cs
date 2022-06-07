using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IconXml;
using Microsoft.Toolkit.Mvvm.Input;
using IconDeskTop.Model;
using System.IO;
using IconDeskTop.Views;
using System.Diagnostics;

namespace IconDeskTop.ViewModels
{
    public class MainWindowVM:ObservableObject
    {
        public MainWindowVM()
        {
            Loaded = new RelayCommand(async () =>
            {
                if(!System.IO.Directory.Exists(Resources.DocPath + "\\IconDesTop\\"))
                {
                    Directory.CreateDirectory(Resources.DocPath + "\\IconDesTop\\");
                }
                try
                {
                    _HomeList = await HomeXml.GetRead(Resources.DocPath + "\\IconDesTop\\Xml.xml");
                    _AppList = await AppIconXml.ReadArgs(Resources.DocPath + "\\IconDesTop\\AppXml.xml");
                }
                catch (Exception)
                {
                    Debug.WriteLine("没有找到文件");
                }
            });


            ShowApps = new RelayCommand(() =>
            {
                HomeIcons apps = new HomeIcons();
                apps.Show();
            });
        }


        private ObservableCollection<HomeIconArgs> HomeList;

        public ObservableCollection<HomeIconArgs> _HomeList
        {
            get { return HomeList; }
            set => SetProperty(ref HomeList, value);
        }


        private ObservableCollection<IconArgs> AppList;

        public ObservableCollection<IconArgs> _AppList
        {
            get { return AppList; }
            set => SetProperty(ref AppList, value);
        }


        public RelayCommand ShowApps { get; private set; }
        public RelayCommand Loaded { get; private set; }

    }
}
