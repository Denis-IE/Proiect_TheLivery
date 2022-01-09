using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheLivery.Data;
using TheLivery.Models;

namespace TheLivery.Pages.Curieri
{
    public class DetailsModel : PageModel
    {
        private readonly TheLivery.Data.CurieratContext _context;

        public DetailsModel(TheLivery.Data.CurieratContext context)
        {
            _context = context;
        }

        public Curier Curier { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Curier = await _context.Curieri.FirstOrDefaultAsync(m => m.ID == id);

            if (Curier == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
