using Microsoft.AspNetCore.Identity;

namespace Pixelstats.Models
{
    public class User : IdentityUser
    {
        public string StudyGroup { get; set; }
    }
}
