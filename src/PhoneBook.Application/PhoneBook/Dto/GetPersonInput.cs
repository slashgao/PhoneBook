using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.PhoneBook.Dto
{
    public class GetPersonInput : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        public void Normalize()
        {
            if(String.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}
