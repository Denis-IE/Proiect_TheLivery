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
    public class IndexModel : PageModel
    {
        private readonly TheLivery.Data.CurieratContext _context;

        public IndexModel(TheLivery.Data.CurieratContext context)
        {
            _context = context;
        }

        public IList<Curier> Curier { get;set; }

        public async Task OnGetAsync()
        {
            Curier = await _context.Curieri.ToListAsync();
        }
    }
}
