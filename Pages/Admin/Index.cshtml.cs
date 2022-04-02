using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Model;

namespace WebApp.Admin
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
           if (User.Identity.IsAuthenticated)   return Redirect("/Index");
            return Page();
        }
        [BindProperty]
        public admins admins { get; set; }
        public async Task<IActionResult> OnPost(string username, string password, string ReturnUrl)
        {
            if (username == "admin@gmail.com"&& password =="admin")
            {
                var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name, username)
            };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.
                AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Redirect(ReturnUrl == null ? "/Index" : ReturnUrl);
            }
            return Page();
        }

    }
}

