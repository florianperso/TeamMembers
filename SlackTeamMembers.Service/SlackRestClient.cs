
using System.Net.Http;
using System.Threading.Tasks;
using PortableRest;

namespace SlackTeamMembers.Service
{
    public class SlackRestClient : RestClient
    {
        #region Singleton

        private static SlackRestClient _instance;

        public static SlackRestClient Instance => _instance ?? (_instance = new SlackRestClient());

        private SlackRestClient()
        {
            BaseUrl = "https://slack.com/api";
        }

        #endregion

        #region Constants

        private const string TOKEN_VALUE = "xoxp-4698769766-4698769768-4898023905-7a1afa";

        #endregion

        #region Methods

        public async Task<T> SendGetAsync<T>(string endpoint)
            where T : class
        {
            if (string.IsNullOrWhiteSpace(endpoint))
                return null;

            endpoint += $"?token={TOKEN_VALUE}";

            var request = new RestRequest(endpoint, HttpMethod.Get, ContentTypes.Json);

            RestResponse<T> result = await SendAsync<T>(request);

            return result.Content;
        }

        #endregion
    }
}
