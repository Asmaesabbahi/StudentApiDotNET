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

namespace WebApp.Admin.Etudiants
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly WebApp.Data.DataContext _context;

        public DetailsModel(WebApp.Data.DataContext context)
        {
            _context = context;
        }

        public Etudiant Etudiant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Etudiant = await _context.Etudiant.FirstOrDefaultAsync(m => m.EtudiantID == id);

            if (Etudiant == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
