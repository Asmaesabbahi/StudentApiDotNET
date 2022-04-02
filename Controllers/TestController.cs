using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Model;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("test")]
    public class TestController : ControllerBase
    {
        private readonly WebApp.Data.DataContext _context;
        public TestController(WebApp.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Etudiant> Etudiant { get; set; }
        public async Task<IList<Etudiant>> OnGetAsync()
        {
            Etudiant = await _context.Etudiant.ToListAsync();
            return Etudiant;
        }
    }
}
