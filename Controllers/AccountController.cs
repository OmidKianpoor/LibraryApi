using LibraryApi.Models;
using LibraryApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace LibraryApi.Controllers
{
    public class AccountController : Controller
      
    {

        
        public IActionResult Login() => View();

        public IActionResult Signup() => View();
        [AllowAnonymous]

     
        public IActionResult Books()
        {
            return View();
        }

        public IActionResult Categories()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View();
        }
    }
}
