using AutoMapper;
using PhoneBook.PhoneBook.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.PhoneBook.Dto
{
    public class PersonMapProfile : Profile
    {
        public PersonMapProfile()
        {
            CreateMap<PersonDto, Person>();
        }
    }
}
