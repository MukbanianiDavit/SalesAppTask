using System;
using System.Collections.Generic;
using System.Text;

namespace SalesApp.Infrastructure.Models.Models.ViewModels
{
    public class OrderViewModel
    {
        public Guid OrderId { get; set; }
        public Guid OrderClientId { get; set; }
        public Guid OrderSellerId { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderTotalAmount { get; set; }
        public int OrderSubordersCount { get; set; }
    }

    public class OrderListingViewModel
    {
        public List<OrderViewModel> Orders { get; set; }
    }

}
