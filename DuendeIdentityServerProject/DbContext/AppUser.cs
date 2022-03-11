using Microsoft.AspNetCore.Identity;

namespace DuendeIdentityServerProject.DbContext
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
