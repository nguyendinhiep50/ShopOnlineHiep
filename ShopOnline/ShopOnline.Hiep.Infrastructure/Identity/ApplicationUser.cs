using Microsoft.AspNetCore.Identity;

namespace ShopOnline.Hiep.Infrastructure.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public string NameUser { get; set; } = string.Empty;
    public Boolean IsActive { get; set; }
    public Boolean IsDeleted { get; set; }
    public string Picture { get; set; } = string.Empty;
    public string Introduction { get; set; } = string.Empty;
    public string NickName { get; set; } = string.Empty;
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }

    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = new List<ApplicationUserRole>();
}
