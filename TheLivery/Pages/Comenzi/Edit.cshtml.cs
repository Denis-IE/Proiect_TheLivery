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

namespace TheLivery.Pages.Comenzi
{
    public class EditModel : PageModel
    {
        private readonly TheLivery.Data.CurieratContext _context;

        public EditModel(TheLivery.Data.CurieratContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["ColetID"] = new SelectList(_context.Set<Colet>(), "ID", "ID");
           ViewData["CurierID"] = new SelectList(_context.Set<Curier>(), "ID", "ID");
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

            _context.Attach(Comanda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComandaExists(Comanda.ID))
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

        private bool ComandaExists(int id)
        {
            return _context.Comenzi.Any(e => e.ID == id);
        }
    }
}
