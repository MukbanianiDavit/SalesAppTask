using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesApp.Infrastructure.Models.Models.RequestModels
{
    public class ClientAddRequest
    {
        [Required]
        public string ClientFname { get; set; }
        [Required]
        public string ClientLname { get; set; }
    }
}
