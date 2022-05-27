using IconDeskTop.Model;
using IconDeskTop.Models;
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
            _MyList = new ObservableCollection<AppSetupPathArgs>();
            
            Loaded = new RelayCommand(() => loadedAsync());
        }

        private async Task loadedAsync()
        {
            _MyList = await AppSetupPath.GetAllAppSetup();
        }

        private ObservableCollection<AppSetupPathArgs> MyList;

        public ObservableCollection<AppSetupPathArgs> _MyList
        {
            get => MyList;
            set =>SetProperty(ref MyList, value);
        }

        public RelayCommand Loaded { get; set; }

    }
}
