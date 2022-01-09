using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheLivery.Data;
using TheLivery.Models;

namespace TheLivery.Pages.Colete
{
    public class CreateModel : PageModel
    {
        private readonly TheLivery.Data.CurieratContext _context;

        public CreateModel(TheLivery.Data.CurieratContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClientID"] = new SelectList(_context.Clienti, "ID", "ID");
        ViewData["FirmaID"] = new SelectList(_context.Firme, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Colet Colet { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Colete.Add(Colet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
