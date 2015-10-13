using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SlackTeamMembers.Service.Models;
using SlackTeamMembers.Service.Modules;

namespace SlackTeamMembers.ViewModels
{
    public sealed class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Fields

        private readonly ITeamModule _teamModule;
        private ObservableCollection<TeamMember> _teamMembers;

        #endregion

        #region Properties

        public ObservableCollection<TeamMember> TeamMembers
        {
            get { return _teamMembers; }
            set
            {
                if (_teamMembers == value) return;
                _teamMembers = value;

                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public MainWindowViewModel(ITeamModule teamModule)
        {
            _teamModule = teamModule;
        }

        #endregion

        #region Methods

        public async Task LoadMembers()
        {
            var members = await _teamModule.GetTeamMembersAsync();
            if (members != null)
                TeamMembers = new ObservableCollection<TeamMember>(members.Members);
        }

        #endregion

        #region INotifiedPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
