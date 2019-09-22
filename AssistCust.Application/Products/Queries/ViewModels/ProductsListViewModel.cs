using System;
using System.Collections.Generic;
using System.Text;

namespace AssistCust.Application.Products.Queries.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
