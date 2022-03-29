using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Authorization;
using PhoneBook.PhoneBook.Dto;
using PhoneBook.PhoneBook.Persons;

namespace PhoneBook.PhoneBook
{
    [AbpAuthorize(PermissionNames.Pages_Persons)]
    public class PersonAppService : PhoneBookAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> personRepository;

        public PersonAppService(IRepository<Person> personRepository)
        {
            this.personRepository = personRepository;
        }
        public async Task CreateOrUpdatePersonAsync(PersonDto input)
        {
            //if(input.Id > 0)
            //{
            //    var person = personRepository.GetAsync(input.Id);
            //}
            //else
            //{

            //}

            var person = ObjectMapper.Map<Person>(input);
            //var person = input.MapTo<Person>();
            await personRepository.InsertOrUpdateAsync(person);
        }

        public async Task DeletePersonAsync(EntityDto input)
        {
            await personRepository.DeleteAsync(input.Id);
        }

        public async Task<PagedResultDto<PersonDto>> GetPagedResultAsync(GetPersonInput input)
        {
            //var query = personRepository.GetAll();
            var query = personRepository.GetAll().Include("PhoneNumbers");

            var count = await query.CountAsync();
            var persons = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            //MapTo is obsolete
            //var personsDto = persons.MapTo<List<PersonDto>>();
            var personsDto = ObjectMapper.Map<List<PersonDto>>(persons);

            return new PagedResultDto<PersonDto>(count, personsDto);
        }

        public async Task<PersonDto> GetPersonByIdAsync(EntityDto input)
        {
            //var person = await personRepository.GetAsync(input.Id);
            var person = await personRepository.GetAllIncluding(a => a.PhoneNumbers).FirstOrDefaultAsync(a => a.Id == input.Id);
            var personsDto = ObjectMapper.Map<PersonDto>(person);
            return personsDto;
        }
    }
}
