using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using spa.Data;
using spa.Models;

namespace spa.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly spa.Data.spaContext _context;

        public IndexModel(spa.Data.spaContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = await _context.Customerz.ToListAsync();
        }
    }
}
