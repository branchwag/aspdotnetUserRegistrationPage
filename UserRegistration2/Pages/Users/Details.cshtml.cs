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
    public class DetailsModel : PageModel
    {
        private readonly UserRegistration2.Data.UserRegistrationDbContext _context;

        public DetailsModel(UserRegistration2.Data.UserRegistrationDbContext context)
        {
            _context = context;
        }

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
    }
}
