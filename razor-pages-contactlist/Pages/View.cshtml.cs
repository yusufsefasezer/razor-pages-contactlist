using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razor_pages_contactlist.Data;

namespace razor_pages_contactlist.Pages
{
    public class ViewModel : PageModel
    {
        private readonly ContactContext _db;

        public ViewModel(ContactContext db)
        {
            _db = db;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Models.Contact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Contact = await _db.Contacts.FindAsync(id);

            if (Contact == null)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}