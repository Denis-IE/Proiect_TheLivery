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
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        private readonly TheLivery.Data.CurieratContext _context;

        public IndexModel(TheLivery.Data.CurieratContext context)
        {
            _context = context;
        }

        public IList<Comanda> Comenzi { get;set; }
        public IList<Colet> Colete { get; set; }
        public IList<Curier> Curieri { get; set; }

        public async Task OnGetAsync()
        {
            Comenzi = await _context.Comenzi
                .Include(c => c.Colet)
                .Include(c => c.Curier).ToListAsync();
            Colete = await _context.Colete
                .Include(c => c.Client)
                .Include(c => c.Firma).ToListAsync();
            Curieri = await _context.Curieri.ToListAsync();
        }
        public void OnPost()
        {
            string x = Request.Form["email"];
            //var ceva = Curieri.Where(x => x.Email.Equals(x)).Single();
            /*if (x.Equals(ceva))
            {
                //Console.WriteLine("daaaa");
                Message = "Da";
            }
            else
            {
                Message = ceva.Nume_complet;
            }*/
        }
    }
}
