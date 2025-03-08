using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = string.Empty;
        
    }
}
