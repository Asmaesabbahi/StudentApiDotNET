using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Data;
using WebApp.Model;

namespace WebApp.Admin.Etudiants
{
    [Authorize]
    public class CreateModel : PageModel
    {   
        private readonly WebApp.Data.DataContext _context;

        public CreateModel(WebApp.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Etudiant Etudiant { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Etudiant.Add(Etudiant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
