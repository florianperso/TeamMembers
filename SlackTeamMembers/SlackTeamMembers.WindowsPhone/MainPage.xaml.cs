using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using SlackTeamMembers.Common;
using SlackTeamMembers.Service.Modules;
using SlackTeamMembers.ViewModels;

namespace SlackTeamMembers
{
    public sealed partial class MainPage
    {
        #region Fields

        private readonly NavigationHelper _navigationHelper;

        #endregion

        #region Constructor

        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
            _navigationHelper = new NavigationHelper(this);
            _navigationHelper.LoadState += NavigationHelper_LoadState;
            _navigationHelper.SaveState += NavigationHelper_SaveState;
        }

        #endregion

        #region Navigation

        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            e.PageState["mainDc"] = JsonConvert.SerializeObject(DataContext);
        }

        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            if (e.PageState != null)
                DataContext = JsonConvert.DeserializeObject<MainWindowViewModel>(e.PageState["mainDc"].ToString());
            else
                DataContext = new MainWindowViewModel(new TeamModule());

            RequestLoadMembers();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedTo(e);

            if (e.NavigationMode == NavigationMode.New)
            {
                DataContext = new MainWindowViewModel(new TeamModule());

                RequestLoadMembers();
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);

            base.OnNavigatedFrom(e);
        }

        #endregion

        #region Methods

        private void RequestLoadMembers()
        {
            if (DataContext != null)
                ((MainWindowViewModel)DataContext).LoadMembers();
        }

        #endregion
    }
}
