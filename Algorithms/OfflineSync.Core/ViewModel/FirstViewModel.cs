using Microsoft.Practices.Prism.Commands;
using OfflineSync.Core.Model;
using OfflineSync.Core.Service.Interfaces;
using System.Collections.Generic;
using System.Windows.Input;

namespace OfflineSync.Core.ViewModel
{
    public class FirstViewModel : Microsoft.Practices.Prism.Mvvm.BindableBase
    {
        private readonly IBmsService _bmsService;

        private IEnumerable<Banners> _banners;

        public FirstViewModel(IBmsService bmsService)
        {
            _bmsService = bmsService;
        }

        public IEnumerable<Banners> Banners
        {
            get { return _banners; }
            set
            {
                _banners = value;
                OnPropertyChanged(() => Banners);
            }
        }

        public ICommand LoadDataCommand
        {
            get { return new DelegateCommand(LoadData); }
        }

        private async void LoadData()
        {
            Banners = await _bmsService.GetBanners();
        }
    }
}
