using Microsoft.EntityFrameworkCore;
using razor_pages_contactlist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace razor_pages_contactlist.Data
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact { Id = 1, FirstName = "Yusuf", LastName = "SEZER", Email = "yusufsezer@mail.com", WebAddress = "https://www.yusufsezer.com", Address = "N/A", Notes = "N/A", PhoneNumber = "+90 538 693 4533" },
                new Contact { Id = 2, FirstName = "Ramazan", LastName = "SEZER", Email = "ramazan.sezer@hotmail.com", Address = "N/A", Notes = "N/A" },
                new Contact { Id = 3, FirstName = "Sinan", LastName = "SEZER", Email = "sinan.sezer44@gmail.com", Address = "N/A", Notes = "N/A" },
                new Contact { Id = 4, FirstName = "Mehmet", LastName = "SEZER", Email = "memo.sezer@gmail.com", Address = "N/A", Notes = "N/A" }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
