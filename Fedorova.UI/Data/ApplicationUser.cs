using Microsoft.AspNetCore.Identity;

namespace Fedorova.UI.Data
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] AvatarImage { get; set; }
    }
}
