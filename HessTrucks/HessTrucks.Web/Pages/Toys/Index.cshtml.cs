using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HessTrucks.Web.Pages.Toys
{
    public class IndexModel : PageModel
    {
       
        public async  Task<IActionResult> OnGet()
        {
           
            return Page();
        }
    }
}
