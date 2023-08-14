using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OrderingBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase 
    {
        protected IHttpContextAccessor HttpContextAccessor { get; }
        protected HttpContext CurrentHttpContext => HttpContextAccessor.HttpContext;

       // UserManager<User> UserManager => HttpContext?.RequestServices?.GetService<UserManager<User>>();
        protected IDictionary<string, string> GetUserClaims()
        {
            var claims = CurrentHttpContext.User.Claims;
            return claims.ToDictionary(claim => claim.Type, claim => claim.Value);
        }
    }
}
