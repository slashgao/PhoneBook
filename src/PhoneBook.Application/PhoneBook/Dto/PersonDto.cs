using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PhoneBook.PhoneBook.Persons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using PhoneBook.PhoneBook.PhoneNumbers;

namespace PhoneBook.PhoneBook.Dto
{
    [AutoMapFrom(typeof(Person))]
    //public class PersonDto : EntityDto<int>
    public class PersonDto : FullAuditedEntityDto
    {
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        
        public string Address { get; set; }

        public List<PhoneNumbers.PhoneNumber> PhoneNumbers { get; set; }
    }
}
