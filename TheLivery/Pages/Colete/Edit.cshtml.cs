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

namespace TheLivery.Pages.Colete
{
    public class EditModel : PageModel
    {
        private readonly TheLivery.Data.CurieratContext _context;

        public EditModel(TheLivery.Data.CurieratContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Colet Colet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Colet = await _context.Colete
                .Include(c => c.Client)
                .Include(c => c.Firma).FirstOrDefaultAsync(m => m.ID == id);

            if (Colet == null)
            {
                return NotFound();
            }
           ViewData["ClientID"] = new SelectList(_context.Clienti, "ID", "ID");
           ViewData["FirmaID"] = new SelectList(_context.Firme, "ID", "ID");
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

            _context.Attach(Colet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColetExists(Colet.ID))
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

        private bool ColetExists(int id)
        {
            return _context.Colete.Any(e => e.ID == id);
        }
    }
}
