using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneBook.PhoneBook.Dto
{
    public class PagedAndSortedResultRequestDto : IPagedAndSortedResultRequest
    {
        [Range(0, int.MaxValue)]
        public int SkipCount { get ; set ; }
        [Range(0, int.MaxValue)]
        public int MaxResultCount { get ; set ; }
        public string Sorting { get ; set ; }
    }
}
