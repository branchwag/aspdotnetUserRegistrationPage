using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserRegistration2.Data;
using UserRegistration2.Models;

namespace UserRegistration2.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly UserRegistration2.Data.UserRegistrationDbContext _context;

        public EditModel(UserRegistration2.Data.UserRegistrationDbContext context)
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

            var userregistration =  await _context.UserRegistrations.FirstOrDefaultAsync(m => m.UserId == id);
            if (userregistration == null)
            {
                return NotFound();
            }
            UserRegistration = userregistration;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserRegistration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRegistrationExists(UserRegistration.UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserRegistrationExists(int id)
        {
            return _context.UserRegistrations.Any(e => e.UserId == id);
        }
    }
}
