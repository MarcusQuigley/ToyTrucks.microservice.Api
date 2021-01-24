 
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace HessTrucks.Web.Controllers
{
    public class TrucksController : Controller
    {


        public TrucksController()
        {
        }

        public async Task<IActionResult>  Index()
        {
            throw new ArgumentNullException(); 
        }
    }
}
