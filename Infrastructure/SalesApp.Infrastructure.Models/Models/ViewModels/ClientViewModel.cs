using System;
using System.Collections.Generic;
using System.Text;

namespace SalesApp.Infrastructure.Models.Models.ViewModels
{
    public class ClientViewModel
    {
        public Guid ClientId { get; set; }
        public string ClientFname { get; set; }
        public string ClientLname { get; set; }
    }

    public class ClientListingViewModel
    {
        public List<ClientViewModel> Clients { get; set; }
    }

}
