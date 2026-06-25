
using Portfolio.Entities;

namespace Portfolio.Models
{
    public class ProfileViewVm
    {
        public PersonalinfoVm PersonalInfo { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Education> Education { get; set; }
        public List<Experience> Experience { get; set; }
    }
}
