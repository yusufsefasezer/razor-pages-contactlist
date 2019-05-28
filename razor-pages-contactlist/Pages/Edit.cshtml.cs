using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using razor_pages_contactlist.Data;

namespace razor_pages_contactlist.Pages
{
    public class EditModel : PageModel
    {

        private readonly ContactContext _db;
        private readonly ILogger<EditModel> _logger;

        public EditModel(ContactContext db, ILogger<EditModel> logger)
        {
            _db = db;
            _logger = logger;
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _db.Attach(Contact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _db.SaveChangesAsync();
                Message = $"{Contact.FullName} updated successfully.";
                _logger.LogInformation(Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong!");
                _logger.LogError(ex, "Something went wrong!");
            }

            return RedirectToPage("/Index");
        }
    }
}