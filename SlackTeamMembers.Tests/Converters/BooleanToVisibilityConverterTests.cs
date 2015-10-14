using Windows.UI.Xaml;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using SlackTeamMembers.Converters;

namespace SlackTeamMembers.Tests
{
    [TestClass]
    public class BooleanToVisibilityConverterTests
    {
        private BooleanToVisibilityConverter _booleanToVisibilityConverter;

        [TestInitialize]
        public void Init()
        {
            _booleanToVisibilityConverter = new BooleanToVisibilityConverter();
        }
        [TestMethod]
        public void ConvertTestShouldBeVisible()
        {
            Assert.AreEqual(_booleanToVisibilityConverter.Convert(true, typeof(bool), null, null), Visibility.Visible);
        }
        [TestMethod]
        public void ConvertTestShouldNotBeVisible()
        {
            Assert.AreNotEqual(_booleanToVisibilityConverter.Convert(false, typeof(bool), null, null), Visibility.Visible);
        }
        [TestMethod]
        public void ConvertTestShouldBeCollapsed()
        {
            Assert.AreEqual(_booleanToVisibilityConverter.Convert(false, typeof(bool), null, null), Visibility.Collapsed);
        }
        [TestMethod]
        public void ConvertTestShouldNotBeCollapsed()
        {
            Assert.AreNotEqual(_booleanToVisibilityConverter.Convert(true, typeof(bool), null, null), Visibility.Collapsed);
        }
    }
}