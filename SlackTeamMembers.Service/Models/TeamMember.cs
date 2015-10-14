using System.Runtime.Serialization;

namespace SlackTeamMembers.Service.Models
{
    [DataContract]
    public class TeamMember
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "deleted")]
        public bool IsDeleted { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "color")]
        public string Color { get; set; }

        [DataMember(Name = "profile")]
        public TeamMemberProfile Profile { get; set; }

        [DataMember(Name = "is_admin")]
        public bool IsAdmin { get; set; }

        [DataMember(Name = "is_owner")]
        public bool IsOwner { get; set; }

        [DataMember(Name = "is_primary_owner")]
        public bool IsPrimaryOwner { get; set; }

        [DataMember(Name = "is_restricted")]
        public bool IsRestricted { get; set; }

        [DataMember(Name = "is_ultra_restricted")]
        public bool IsUltraRestricted { get; set; }

        [DataMember(Name = "is_bot")]
        public bool IsBot { get; set; }
    }
}