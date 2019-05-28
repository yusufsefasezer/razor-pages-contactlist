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
    public class AddModel : PageModel
    {
        private readonly ContactContext _db;
        private readonly ILogger<AddModel> _logger;

        public AddModel(ContactContext db, ILogger<AddModel> logger)
        {
            _db = db;
            _logger = logger;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Models.Contact Contact { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Contacts.Add(Contact);

            try
            {
                await _db.SaveChangesAsync();
                Message = $"{Contact.FullName} added successfully.";
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