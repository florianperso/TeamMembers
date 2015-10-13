
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using SlackTeamMembers.Service.Modules;
using SlackTeamMembers.ViewModels;

namespace SlackTeamMembers.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        private MainWindowViewModel _mainWindowViewModel;

        [TestInitialize]
        public void Init()
        {
            _mainWindowViewModel = new MainWindowViewModel(new TeamModuleMock());
            _mainWindowViewModel.LoadMembers().Wait();
        }

        [TestMethod]
        public void MembersCollectionAfterDeserializingShouldNotBeNullOrEmpty()
        {
            Assert.IsNotNull(_mainWindowViewModel.TeamMembers);
            Assert.IsTrue(_mainWindowViewModel.TeamMembers.Any());
        }

        [TestMethod]
        public void MembersCollectionAfterDeserializingShouldContain7Elements()
        {
            Assert.IsTrue(_mainWindowViewModel.TeamMembers.Count == 7);
        }
    }
}
