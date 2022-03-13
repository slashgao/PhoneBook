using System.Collections.Generic;
using PhoneBook.Roles.Dto;

namespace PhoneBook.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}