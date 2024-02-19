using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserRegistration2.Data;
using UserRegistration2.Models;

namespace UserRegistration2.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly UserRegistration2.Data.UserRegistrationDbContext _context;

        public CreateModel(UserRegistration2.Data.UserRegistrationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserRegistration UserRegistration { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserRegistrations.Add(UserRegistration);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ThankYou");
        }
    }
}
