using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Milky.DTO.Login;
using Milky.Entity.Concrete;
using Milky.WebUI.Models;
using Newtonsoft.Json;
using System.Text;

namespace Milky.WebUI.Controllers;
public class LoginController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public LoginController(IHttpClientFactory httpClientFactory, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _httpClientFactory = httpClientFactory;
        _signInManager = signInManager;
        _userManager = userManager;
    }
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SignIn(UserLoginDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var read = JsonConvert.SerializeObject(dto);
        var content = new StringContent(read, Encoding.UTF8, "application/json");
        var result = await client.PostAsync("https://localhost:7226/api/Login/Login", content);
        if (result.IsSuccessStatusCode)
        {
            var user = await _userManager.FindByEmailAsync(dto.Mail);
            await _signInManager.PasswordSignInAsync(user, dto.Password, false, false);
            return RedirectToAction("Index", "Default");
        }
        else
        {
            return View();
        }
    }
    [HttpPost]
    public async Task<IActionResult> SignUp(CreateUserDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var read = JsonConvert.SerializeObject(dto);
        var content = new StringContent(read, Encoding.UTF8, "application/json");
        var res = await client.PostAsync("https://localhost:7226/api/Login/Register", content);
        if (res.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Login");
        }
        else
        {
            
            return View();
        }
    }
    public async Task<IActionResult> Logout()
    {
        var client = _httpClientFactory.CreateClient();
        var res = await client.GetAsync("https://localhost:7226/api/Login/Logout");
        if (res.IsSuccessStatusCode)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }
        return View();
    }
}
