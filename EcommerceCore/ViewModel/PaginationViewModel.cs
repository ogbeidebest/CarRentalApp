using System;
using System.Collections;
using System.Collections.Generic;
using EcommerceCore.Models;

namespace EcommerceCore.ViewModel
{
    public class PaginationViewModel
    {
        public IEnumerable<CarViewModel> Cars { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int NumberPages { get; set; }
        public int PreviousPage { get; set; }

    }
}
