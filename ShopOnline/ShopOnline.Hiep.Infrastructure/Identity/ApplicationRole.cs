using Microsoft.AspNetCore.Identity;

namespace ShopOnline.Hiep.Infrastructure.Identity;

public class ApplicationRole : IdentityRole<Guid>
{
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = new List<ApplicationUserRole>();
}
