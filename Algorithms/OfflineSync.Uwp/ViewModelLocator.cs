using OfflineSync.Core.ViewModel;

namespace OfflineSync.Uwp
{
    public class ViewModelLocator
    {
        private App _App = (App)App.Current;

        public FirstViewModel FirstViewModel
        {
            get
            {
                return _App.IocContainer.Resolve<FirstViewModel>();
            }
        }
    }
}
