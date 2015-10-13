using System.Runtime.Serialization;

namespace SlackTeamMembers.Service.Models
{
    [DataContract]
    public class TeamMemberProfile
    {
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        [DataMember(Name = "last_Name")]
        public string LastName { get; set; }

        [DataMember(Name = "real_name_normalized")]
        public string RealNameNormalized { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "skype")]
        public string SkypeId { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "image_48")]
        public string ImageSmallUrl { get; set; }

        [DataMember(Name = "image_192")]
        public string ImageLargeUrl { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }
    }
}