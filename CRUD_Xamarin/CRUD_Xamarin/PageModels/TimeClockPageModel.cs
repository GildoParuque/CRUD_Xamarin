using CRUD_Xamarin.Models;
using CRUD_Xamarin.PageModels.Base;
using CRUD_Xamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Xamarin.PageModels
{
    public class TimeClockPageModel : PageModelBase
    {
        TimeSpan _runningTotal;

        public TimeSpan RunningTotal
        {
            get => _runningTotal;
            set => SetProperty(ref _runningTotal, value);
        }

        DateTime _currentStartTime;

        public DateTime CurrentStartTime
        {
            get => _currentStartTime;
            set => SetProperty(ref _currentStartTime, value);
        }

        ObservableCollection<WorkItem> _workItems;

        public ObservableCollection<WorkItem> WorkItems
        {
            get => _workItems;
            set => SetProperty(ref _workItems, value);
        }

        double _todayEarnings;

        public double TodayEarnings
        {
            get => _todayEarnings;
            set => SetProperty(ref _todayEarnings, value);
        }

        ButtonModel _clockInOutButtonModel;

        public ButtonModel ClockInOutButtonModel
        {
            get => _clockInOutButtonModel;
            set => SetProperty(ref _clockInOutButtonModel, value);
        }

        public TimeClockPageModel()
        {
            WorkItems = new ObservableCollection<WorkItem>();
            ClockInOutButtonModel = new ButtonModel("CLock In", OnClockInOutAction);
        }

        public override Task InitializeAsync(object navigationDate = null)
        {
            RunningTotal = new TimeSpan();
            return base.InitializeAsync(navigationDate);
        }
        private void OnClockInOutAction()
        {
            throw new NotImplementedException();
        }
    }
}
