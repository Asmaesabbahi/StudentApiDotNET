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
    public class DeleteModel : PageModel
    {
        private readonly WebApp.Data.DataContext _context;

        public DeleteModel(WebApp.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Etudiant = await _context.Etudiant.FindAsync(id);

            if (Etudiant != null)
            {
                _context.Etudiant.Remove(Etudiant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
