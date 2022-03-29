using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Authorization;
using PhoneBook.Controllers;
using PhoneBook.PhoneBook;
using PhoneBook.PhoneBook.Dto;

namespace PhoneBook.Web.Mvc.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Persons)]
    public class PersonsController : PhoneBookControllerBase
    {
        private readonly IPersonAppService personAppService;

        public PersonsController(IPersonAppService personAppService)
        {
            this.personAppService = personAppService;
        }
        public async Task<IActionResult> Index(GetPersonInput input)
        {
            input.MaxResultCount = int.MaxValue;
            var persons = await personAppService.GetPagedResultAsync(input);
            return View(persons);
        }

        public async Task<ActionResult> EditPersonModal(int personId)
        {
            var person = await personAppService.GetPersonByIdAsync(new EntityDto(personId));
            var personDto = ObjectMapper.Map<PersonDto>(person);

            //var model = new EditUserModalViewModel
            //{
            //    User = user,
            //    Roles = roles
            //};
            return View("_EditPersonModal", personDto);
        }
    }
}