using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Milky.DTO.Login;
using Milky.Entity.Concrete;
using Milky.WebApi.Model;

namespace Milky.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUp(CreateUserDto dto)
    {

        if (dto.Password == dto.ConfirmPassword)
        {
            var user = new AppUser()
            {
                Name = dto.Name,
                Email = dto.Mail,
                Surname = dto.Surname,
                UserName = dto.Username,
            };
            var createUser = await _userManager.CreateAsync(user, dto.Password);
            if (createUser.Succeeded)
            {
                //await _userManager.AddToRoleAsync(user, "Member");
                return Ok("Kullanıcı başarıyla oluşturuldu.");
            }
            else
            {
                foreach (var item in createUser.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
                return BadRequest(createUser.Errors);
            }
        }

        return Ok();
    }

    [HttpPost("SignIn")]
    public async Task<IActionResult> SignIn(UserLoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Mail);
        var loginuser = await _signInManager.PasswordSignInAsync(dto.Mail, dto.Password, false, false);
        if (loginuser.Succeeded)
        {
            return Ok(loginuser);
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpGet("Logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }

}
