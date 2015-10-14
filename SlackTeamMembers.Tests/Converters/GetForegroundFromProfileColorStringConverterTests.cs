using Windows.UI;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using SlackTeamMembers.Converters;

namespace SlackTeamMembers.Tests
{
    [TestClass]
    public class GetForegroundFromProfileColorStringConverterTests
    {
        private GetForegroundFromProfileColorStringConverter _invertBooleanToVisibilityConverter;

        [TestInitialize]
        public void Init()
        {
            _invertBooleanToVisibilityConverter = new GetForegroundFromProfileColorStringConverter();
        }

        [TestMethod]
        public void ConvertTestShouldBeBlack()
        {
            Assert.AreEqual(_invertBooleanToVisibilityConverter.Convert("FFFFFF", typeof(bool), null, null), Colors.Black);
            Assert.AreEqual(_invertBooleanToVisibilityConverter.Convert("E0FFFF", typeof(bool), null, null), Colors.Black);
        }

        [TestMethod]
        public void ConvertTestShouldBeWhite()
        {
            Assert.AreEqual(_invertBooleanToVisibilityConverter.Convert("000000", typeof(bool), null, null), Colors.White);
            Assert.AreEqual(_invertBooleanToVisibilityConverter.Convert("0000FF", typeof(bool), null, null), Colors.White);
        }
    }
}