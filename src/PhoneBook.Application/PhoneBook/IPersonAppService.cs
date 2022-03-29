using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PhoneBook.PhoneBook.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.PhoneBook
{
    public interface IPersonAppService: IApplicationService
    {
        Task<PagedResultDto<PersonDto>> GetPagedResultAsync(GetPersonInput input);
        Task<PersonDto> GetPersonByIdAsync(EntityDto input);
        Task CreateOrUpdatePersonAsync(PersonDto input);
        Task DeletePersonAsync(EntityDto input);

    }
}
