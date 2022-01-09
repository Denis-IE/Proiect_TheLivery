using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheLivery.Data;
using TheLivery.Models;

namespace TheLivery.Pages
{
    public class CurierModel : PageModel
    {
        public string Message { get; set; }

        public void OnPost()
        {
            string x = Request.Form["email"];
            Message = "he!";
        }
    }
}
