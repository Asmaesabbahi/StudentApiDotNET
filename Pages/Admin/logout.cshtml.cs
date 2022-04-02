using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Admin
{
    public class logoutModel : PageModel
    {
        internal const String CK_KEY_NAME = "_name";
       /* public async Task<IActionResult> OnGetDeleteCookieAsync()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.Response.Cookies.Delete($".AspNetCore.{CookieAuthenticationDefaults.AuthenticationScheme}");
                Response.Cookies.Delete(CK_KEY_NAME);
                return Redirect("/Index");
            }
            return RedirectToPage();
            //return Redirect("/Index");
        }*/

        public async Task<IActionResult> OnPost()
        {
            // SomeOtherPage is where we redirect to after signout
           
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Response.Cookies.Delete($".AspNetCore.{CookieAuthenticationDefaults.AuthenticationScheme}");
            Response.Cookies.Delete(CK_KEY_NAME);
            return Redirect("/Index");
        }

        public String CookieValue { get; set; }

        // handle the get request 
        public void OnGet()
        {

            // read the cookie 
            CookieValue =
            Request.Cookies.TryGetValue(CK_KEY_NAME, out string strVal)
            ? strVal : null;

        }

    }
}
