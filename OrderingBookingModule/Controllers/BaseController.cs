using Entitites.Common;
using Entitites.Dto;
using EntityLayer.Common;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OrderingBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected UserClaimDto GetUserClaimDto()
        {
            try
            {
                var token = HttpContext.Request.Headers[AuthConstants.Authorization].ToString().Replace("Bearer ", "");
                if (string.IsNullOrWhiteSpace(token))
                {
                    throw new UnauthorizedAccessException(StringConstant.TokenMissing);
                }
                var user = User;
                if (user != null && user.FindFirst(AuthConstants.Id) != null)
                {
                    var id = user.FindFirstValue(AuthConstants.Id);
                    // Verify with user Module Needs to be integrated.
                    return new UserClaimDto
                    {
                        Token = token,
                        UserId = Convert.ToUInt64(id),
                        Email = user.FindFirstValue(AuthConstants.Email),
                        Name = user.FindFirstValue(AuthConstants.Name),
                        Role = user.FindFirstValue(AuthConstants.Role)
                    };
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                throw ex;
            }
            return null;
        }

    }
}
