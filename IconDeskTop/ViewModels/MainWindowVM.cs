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
                _HomeList = await HomeXml.GetRead(Resources.DocPath+"\\IconDesTop\\Xml.xml");
            });
        }


        private ObservableCollection<HomeIconArgs> HomeList;

        public ObservableCollection<HomeIconArgs> _HomeList
        {
            get { return HomeList; }
            set => SetProperty(ref HomeList, value);
        }


        public RelayCommand Loaded { get; private set; }

    }
}
