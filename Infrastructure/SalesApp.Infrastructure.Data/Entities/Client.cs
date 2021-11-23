using System;
using System.Collections.Generic;

#nullable disable

namespace SalesApp.Infrastructure.Data.Entities
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        public Guid ClientId { get; set; }
        public string ClientFname { get; set; }
        public string ClientLname { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
