using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using spa.Data;
using spa.Models;
using BCrypt.Net;

namespace spa.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly spaContext _context;

        public RegisterModel(spaContext context)
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

            // Hash the password before saving
            Admin.Password = BCrypt.Net.BCrypt.HashPassword(Admin.Password);

            _context.Adminz.Add(Admin);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Account/Login");
        }
    }
}