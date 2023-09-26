using ApiProject.DTO;
using ApiProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private  UserManager<AppUser> _UserManager { get; }

        public AccountController( UserManager<AppUser> userManager )
        {
            _UserManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(AppUserDTo Appdto)
        {
            if (ModelState.IsValid)
            {
                var Errors = new List<string>();
                AppUser appUser = new AppUser()
                {
                    UserName = Appdto.UserName,
                    PasswordHash = Appdto.Password
                };

                IdentityResult identityResult = await _UserManager.CreateAsync(appUser, Appdto.Password);
                if (identityResult.Succeeded)
                    return Ok("User Added");
                foreach (var item in identityResult.Errors)
                {
                    Errors.Add(item.Description);
                }

                return BadRequest(Errors);
            }

            return BadRequest(ModelState);
        }
    }
}
