using Abp.Domain.Entities.Auditing;
using PhoneBook.PhoneBook.Persons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneBook.PhoneBook.PhoneNumbers
{
    public class PhoneNumber : FullAuditedEntity
    {
        [Required]
        [MaxLength(11)]
        public string Number { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }

    }
}
