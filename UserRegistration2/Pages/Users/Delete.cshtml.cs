using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UserRegistration2.Data;
using UserRegistration2.Models;

namespace UserRegistration2.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly UserRegistration2.Data.UserRegistrationDbContext _context;

        public DeleteModel(UserRegistration2.Data.UserRegistrationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserRegistration UserRegistration { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userregistration = await _context.UserRegistrations.FirstOrDefaultAsync(m => m.UserId == id);

            if (userregistration == null)
            {
                return NotFound();
            }
            else
            {
                UserRegistration = userregistration;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userregistration = await _context.UserRegistrations.FindAsync(id);
            if (userregistration != null)
            {
                UserRegistration = userregistration;
                _context.UserRegistrations.Remove(UserRegistration);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
