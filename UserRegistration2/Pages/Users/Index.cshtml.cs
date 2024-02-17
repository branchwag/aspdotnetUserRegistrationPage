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
    public class IndexModel : PageModel
    {
        private readonly UserRegistration2.Data.UserRegistrationDbContext _context;

        public IndexModel(UserRegistration2.Data.UserRegistrationDbContext context)
        {
            _context = context;
        }

        public IList<UserRegistration> UserRegistration { get;set; } = default!;

        public async Task OnGetAsync()
        {
            UserRegistration = await _context.UserRegistrations.ToListAsync();
        }
    }
}
