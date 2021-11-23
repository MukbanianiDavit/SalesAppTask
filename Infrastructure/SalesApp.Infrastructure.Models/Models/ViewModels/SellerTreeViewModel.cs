using System;
using System.Collections.Generic;
using System.Text;

namespace SalesApp.Infrastructure.Models.Models.ViewModels
{
    public class SellerTreeNodeViewModel
    {
        public Guid SellerId { get; set; }
        public string SellerFname { get; set; }
        public string SellerLname { get; set; }
        public List<SellerTreeNodeViewModel> Employees { get; set; }
    }

    public class SellerTreeViewModel
    {
        public List<SellerTreeNodeViewModel> Nodes { get; set; }
    }

}
