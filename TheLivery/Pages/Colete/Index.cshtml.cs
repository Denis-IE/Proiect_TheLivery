using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheLivery.Data;
using TheLivery.Models;

namespace TheLivery.Pages.Colete
{
    public class IndexModel : PageModel
    {
        private readonly TheLivery.Data.CurieratContext _context;

        public IndexModel(TheLivery.Data.CurieratContext context)
        {
            _context = context;
        }

        public IList<Colet> Colet { get;set; }

        public async Task OnGetAsync()
        {
            Colet = await _context.Colete
                .Include(c => c.Client)
                .Include(c => c.Firma).ToListAsync();
        }
    }
}
