using Microsoft.AspNetCore.Identity;

namespace Fedorova.UI.Data
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] AvatarImage { get; set; }
        public string MimeType { get; set; } = string.Empty;
    }
}
