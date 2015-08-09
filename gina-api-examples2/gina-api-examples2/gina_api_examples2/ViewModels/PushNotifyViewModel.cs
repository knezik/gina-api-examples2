using System;
using System.Windows.Input;

using Cirrious.CrossCore;
using Cirrious.CrossCore.Converters;
using Cirrious.MvvmCross.ViewModels;


namespace gina_api_examples2.Core.ViewModels
{
    public class PushNotifyViewModel : TestViewModel
    {
        private readonly Services.IPushNotificationService _pushNofifyService;

        public String State { get; set; }

        public PushNotifyViewModel(Services.IPushNotificationService pushNofifyService)
        {
            _pushNofifyService = pushNofifyService;
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    _pushNofifyService.StartService();
                });
            }
        }

        public ICommand UnregisterCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    _pushNofifyService.StopService();
                });
            }
        }
    }
}
