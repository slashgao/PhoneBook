using Abp.Domain.Entities.Auditing;
using PhoneBook.PhoneBook.PhoneNumbers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneBook.PhoneBook.Persons
{
    public class Person: FullAuditedEntity
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
