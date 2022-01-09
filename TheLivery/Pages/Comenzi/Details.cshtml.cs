using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheLivery.Data;
using TheLivery.Models;

namespace TheLivery.Pages.Comenzi
{
    public class DetailsModel : PageModel
    {
        private readonly TheLivery.Data.CurieratContext _context;

        public DetailsModel(TheLivery.Data.CurieratContext context)
        {
            _context = context;
        }

        public Comanda Comanda { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Comanda = await _context.Comenzi
                .Include(c => c.Colet)
                .Include(c => c.Curier).FirstOrDefaultAsync(m => m.ID == id);

            if (Comanda == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
