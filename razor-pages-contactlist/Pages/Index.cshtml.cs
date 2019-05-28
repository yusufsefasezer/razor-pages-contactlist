using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using razor_pages_contactlist.Data;
using razor_pages_contactlist.Models;

namespace razor_pages_contactlist.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ContactContext _db;
        private readonly ILogger<IndexModel> _logger;

        public IEnumerable<Contact> Contacts { get; set; }

        public IndexModel(ContactContext db, ILogger<IndexModel> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            Contacts = await _db.Contacts.OrderByDescending(p => p.Id).AsNoTracking().ToListAsync();
        }

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            var contact = await _db.Contacts.FindAsync(id);

            if (contact != null)
            {
                try
                {
                    _db.Entry(contact).State = EntityState.Deleted;
                    Message = $"{contact.FullName} deleted successfully.";
                    await _db.SaveChangesAsync();
                    _logger.LogInformation(Message);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Something went wrong!");
                    _logger.LogError(ex, "Something went wrong!");
                }
            }

            return RedirectToPage();
        }
    }
}
