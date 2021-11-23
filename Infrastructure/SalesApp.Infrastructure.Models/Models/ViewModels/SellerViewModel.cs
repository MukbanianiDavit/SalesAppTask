using System;
using System.Collections.Generic;
using System.Text;

namespace SalesApp.Infrastructure.Models.Models.ViewModels
{
    public class SellerViewModel
    {
        public Guid SellerId { get; set; }
        public Guid SellerBossId { get; set; }
        public string SellerFname { get; set; }
        public string SellerLname { get; set; }
    }

    public class SellerListingViewModel
    {
        public List<SellerViewModel> Sellers { get; set; }
    }

}
