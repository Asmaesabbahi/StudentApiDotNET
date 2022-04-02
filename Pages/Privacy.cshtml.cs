using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Model;
using WebApp.Data;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Pages
{
    [Authorize]
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        DataContext dataContext;

        public PrivacyModel(ILogger<PrivacyModel> logger, DataContext dataContext)
        {
            _logger = logger;
            this.dataContext = dataContext;
        }

        public void OnGet()
        {
            /*var Etudiant = new Etudiant() { Name = "Kawtar", Last_name = "Lechhab", Email = "Lechhab@gmail.com", Tel=0612345890};
            dataContext.Etudiant.Add(Etudiant);
            dataContext.SaveChanges();*/
        }
    }
}
