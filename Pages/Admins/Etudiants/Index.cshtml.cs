using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Model;

namespace WebApp.Pages.Shared
{
    [Authorize]
    public class IndexModel : PageModel
    {

        private readonly WebApp.Data.DataContext _context;
        public IndexModel(WebApp.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Etudiant> Etudiant { get; set; }

        public async Task OnGetAsync()
        {
            Etudiant = await _context.Etudiant.ToListAsync();
        }


    }
}
