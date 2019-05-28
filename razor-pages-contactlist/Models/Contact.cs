using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace razor_pages_contactlist.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required, StringLength(50), Display(Name = "First name")]
        public string FirstName { get; set; }

        [StringLength(50), Display(Name = "Last name")]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [Required, StringLength(100)]
        public string Email { get; set; }

        [StringLength(20), Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(100), Display(Name = "Web address")]
        public string WebAddress { get; set; }

        [StringLength(250)]
        public string Notes { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
