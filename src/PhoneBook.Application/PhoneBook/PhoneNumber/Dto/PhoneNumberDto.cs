using Abp.AutoMapper;
using PhoneBook.PhoneBook.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.PhoneBook.PhoneNumber.Dto
{
    [AutoMapFrom(typeof(PhoneBook.PhoneNumbers.PhoneNumber))]
    public class PhoneNumberDto
    {
        public string Number { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
