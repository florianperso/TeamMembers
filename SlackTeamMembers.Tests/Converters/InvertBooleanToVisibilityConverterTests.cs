using Windows.UI.Xaml;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using SlackTeamMembers.Converters;

namespace SlackTeamMembers.Tests
{
    [TestClass]
    public class InvertBooleanToVisibilityConverterTests
    {
        private InvertedBooleanToVisibilityConverter _invertBooleanToVisibilityConverter;

        [TestInitialize]
        public void Init()
        {
            _invertBooleanToVisibilityConverter = new InvertedBooleanToVisibilityConverter();
        }
        [TestMethod]
        public void ConvertTestShouldBeVisible()
        {
            Assert.AreEqual(_invertBooleanToVisibilityConverter.Convert(false, typeof(bool), null, null), Visibility.Visible);
        }
        [TestMethod]
        public void ConvertTestShouldNotBeVisible()
        {
            Assert.AreNotEqual(_invertBooleanToVisibilityConverter.Convert(true, typeof(bool), null, null), Visibility.Visible);
        }
        [TestMethod]
        public void ConvertTestShouldBeCollapsed()
        {
            Assert.AreEqual(_invertBooleanToVisibilityConverter.Convert(true, typeof(bool), null, null), Visibility.Collapsed);
        }
        [TestMethod]
        public void ConvertTestShouldNotBeCollapsed()
        {
            Assert.AreNotEqual(_invertBooleanToVisibilityConverter.Convert(false, typeof(bool), null, null), Visibility.Collapsed);
        }
    }
}