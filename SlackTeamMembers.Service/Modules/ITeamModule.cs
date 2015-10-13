using System.Collections.Generic;
using System.Threading.Tasks;
using SlackTeamMembers.Service.Models;

namespace SlackTeamMembers.Service.Modules
{
    public interface ITeamModule
    {
        Task<TeamMemberResponse> GetTeamMembersAsync();
    }
}