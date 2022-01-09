using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheLivery.Data;
using TheLivery.Models;

namespace TheLivery.Pages.Curieri
{
    public class EditModel : PageModel
    {
        private readonly TheLivery.Data.CurieratContext _context;

        public EditModel(TheLivery.Data.CurieratContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Curier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurierExists(Curier.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CurierExists(int id)
        {
            return _context.Curieri.Any(e => e.ID == id);
        }
    }
}
