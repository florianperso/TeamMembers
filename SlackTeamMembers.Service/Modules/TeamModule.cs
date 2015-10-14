using System.Threading.Tasks;
using SlackTeamMembers.Service.Models;

namespace SlackTeamMembers.Service.Modules
{
    public class TeamModule : ITeamModule
    {
        public async Task<TeamMemberResponse> GetTeamMembersAsync()
        {
            return await SlackRestClient.Instance.SendGetAsync<TeamMemberResponse>(@"/users.list");
        }
    }
}
