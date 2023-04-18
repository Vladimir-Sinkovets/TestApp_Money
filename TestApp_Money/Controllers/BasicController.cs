using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TestApp_Money.Web.Controllers
{
    public class BasicController : Controller
    {
        protected string UserId => !User.Identity.IsAuthenticated
            ? string.Empty
            : User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
