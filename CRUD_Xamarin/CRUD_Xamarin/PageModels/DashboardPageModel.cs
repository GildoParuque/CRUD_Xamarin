using CRUD_Xamarin.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Xamarin.PageModels
{
    public class DashboardPageModel : PageModelBase
    {
        
        private ProfilePageModel _profilePM;
        public ProfilePageModel ProfilePageModel
        {
            get => _profilePM;
            set => SetProperty(ref _profilePM, value);
        }
        private SettingsPageModel _settingsPM;
        public SettingsPageModel SettingsPageModel
        {
            get => _settingsPM;
            set => SetProperty(ref _settingsPM, value);
        }
        private SummaryPageModel _summarry;
        public SummaryPageModel SummaryPageModel
        {
            get => _summarry;
            set => SetProperty(ref _summarry, value);
        }
        private TimeClockPageModel _timeClockPM;
        public TimeClockPageModel TimeClockPageModel
        {
            get => _timeClockPM;
            set => SetProperty(ref _timeClockPM, value);
        }

        public DashboardPageModel(ProfilePageModel profilePM,
            SettingsPageModel settingsPM,
            SummaryPageModel summaryPM,
            TimeClockPageModel timeClockPM)
        {
            ProfilePageModel = profilePM;
            SettingsPageModel = settingsPM;
            SummaryPageModel = summaryPM;
            TimeClockPageModel = timeClockPM;
        }
        public override Task InitializeAsync(object navigationDate)
        {
            return Task.WhenAny(base.InitializeAsync(navigationDate),
                ProfilePageModel.InitializeAsync(navigationDate = null),
                SettingsPageModel.InitializeAsync(navigationDate = null),
                SummaryPageModel.InitializeAsync(navigationDate = null),
                TimeClockPageModel.InitializeAsync(navigationDate = null)
                );
            
        }
    }
}
