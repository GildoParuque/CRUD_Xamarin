using CRUD_Xamarin.Models;
using CRUD_Xamarin.PageModels.Base;
using CRUD_Xamarin.Services.Account;
using CRUD_Xamarin.Services.Work;
using CRUD_Xamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CRUD_Xamarin.PageModels
{
    public class TimeClockPageModel : PageModelBase
    {
        bool _isClockedIn;

        public bool IsClockedIn
        {
            get => _isClockedIn;
            set => SetProperty(ref _isClockedIn, value);
        }
        
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

        private Timer _timer;
        private double _hourRate;
        ObservableCollection<WorkItem> _workItems;
        private IAccountService _accountService;
        private IWorkService _workService;
        public TimeClockPageModel(IAccountService accountService, IWorkService workService)
        {
            _accountService = accountService;
            _workService = workService;
            ClockInOutButtonModel = new ButtonModel("Clock In", OnClockInOutAction);
            _timer = new Timer();
            _timer.Enabled = false;
            _timer.Interval = 1000;
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RunningTotal += TimeSpan.FromSeconds(1);
        }

        public override async Task InitializeAsync(object navigationDate)
        {
            RunningTotal = new TimeSpan();
            _hourRate = await _accountService.GetCurrentPayRateAsync();
            WorkItems = await _workService.GetTodaysWorkAsync();
            await base.InitializeAsync(navigationDate);
        }
        private async void OnClockInOutAction()
        {
            if (IsClockedIn)
            {
                _timer.Enabled = false;
                TodayEarnings += _hourRate * RunningTotal.TotalHours;
                RunningTotal = TimeSpan.Zero;
                ClockInOutButtonModel.Text = "Clock In";
                var item = new WorkItem
                {
                    Start = CurrentStartTime,
                    End = DateTime.Now
                };
                WorkItems.Insert(0, item);
                await _workService.LogWorkAsync(item);
            }
            else
            {
                CurrentStartTime = DateTime.Now;
                _timer.Enabled = true;
                ClockInOutButtonModel.Text = "Clock Out";
            }

            IsClockedIn = !IsClockedIn;
        }
    }
}
