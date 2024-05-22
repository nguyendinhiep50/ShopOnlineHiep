using ShopOnline.Hiep.Application.Common.Interfaces;
using System.Security.Claims;

namespace ShopOnline.Hiep.Services
{
    public class CurrentUser : IUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public decimal? Id
        {
            get
            {
                string userIdString = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

                if (decimal.TryParse(userIdString, out decimal userIdDecimal))
                {
                    return userIdDecimal;
                }

                return null;
            }
        }
    }

}
