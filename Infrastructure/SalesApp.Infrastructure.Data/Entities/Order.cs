using System;
using System.Collections.Generic;

#nullable disable

namespace SalesApp.Infrastructure.Data.Entities
{
    public partial class Order
    {
        public Guid OrderId { get; set; }
        public Guid? OrderParentId { get; set; }
        public Guid OrderClientId { get; set; }
        public Guid OrderSellerId { get; set; }
        public double OrderAmount { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Client OrderClient { get; set; }
        public virtual Seller OrderSeller { get; set; }
    }
}
