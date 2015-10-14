using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using SlackTeamMembers.Common;
using SlackTeamMembers.Service.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace SlackTeamMembers
{
    public sealed partial class ProfileDetails
    {
        #region Fields

        private readonly NavigationHelper _navigationHelper;

        #endregion

        #region Constructor

        public ProfileDetails()
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
            e.PageState["dc"] = JsonConvert.SerializeObject(DataContext);
        }

        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            if (e.PageState != null)
                DataContext = JsonConvert.DeserializeObject<TeamMember>(e.PageState["dc"].ToString());
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
                if (e.Parameter != null)
                    DataContext = JsonConvert.DeserializeObject<TeamMember>(e.Parameter.ToString());
            }

            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;

            base.OnNavigatedFrom(e);
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }

        #endregion
    }
}
