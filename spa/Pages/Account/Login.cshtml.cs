using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using spa.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;
using BCrypt.Net;
using spa.Models;

namespace spa.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly spaContext _context;

        public LoginModel(spaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Admin Admin { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var admin = _context.Adminz.FirstOrDefault(a => a.Username == Admin.Username);

            if (admin == null || !BCrypt.Net.BCrypt.Verify(Admin.Password, admin.Password))
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            // Set the admin session
            HttpContext.Session.SetString("AdminId", admin.Id.ToString());
            HttpContext.Session.SetString("Username", admin.Username);

            return RedirectToPage("/Customers/Create");
        }
    }
}