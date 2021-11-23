using System;
using System.Collections.Generic;

#nullable disable

namespace SalesApp.Infrastructure.Data.Entities
{
    public partial class Seller
    {
        public Seller()
        {
            InverseSellerBoss = new HashSet<Seller>();
            Orders = new HashSet<Order>();
        }

        public Guid SellerId { get; set; }
        public Guid? SellerBossId { get; set; }
        public string SellerFname { get; set; }
        public string SellerLname { get; set; }

        public virtual Seller SellerBoss { get; set; }
        public virtual ICollection<Seller> InverseSellerBoss { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
