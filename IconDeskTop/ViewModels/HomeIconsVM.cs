using IconDeskTop.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconDeskTop.ViewModels
{
    internal class HomeIconsVM:ObservableRecipient
    {
        public HomeIconsVM()
        {
            IsActive = true;
            _MyList = new ObservableCollection<IconModel>();
            
            Loaded = new RelayCommand(() => loaded());
        }

        private void loaded()
        {
            for (int i = 0; i < 25; i++)
            {
                _MyList.Add(new IconModel() { FilePath = "D://t.txt", Name = "VSCode" });
            };
        }

        private ObservableCollection<IconModel> MyList;

        public ObservableCollection<IconModel> _MyList
        {
            get => MyList;
            set =>SetProperty(ref MyList, value);
        }

        public RelayCommand Loaded { get; set; }

    }
}
