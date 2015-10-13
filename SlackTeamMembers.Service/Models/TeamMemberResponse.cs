using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SlackTeamMembers.Service.Models
{
    [DataContract]
    public class TeamMemberResponse
    {
        [DataMember(Name = "members")]
        public List<TeamMember> Members { get; set; }
    }
}
