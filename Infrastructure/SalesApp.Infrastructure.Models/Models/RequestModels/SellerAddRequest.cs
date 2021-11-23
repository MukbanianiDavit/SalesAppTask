using System;
using System.ComponentModel.DataAnnotations;

namespace SalesApp.Infrastructure.Models.Models.RequestModels
{
    public class SellerAddRequest
    {
        public Guid? SellerBossId { get; set; }
        [Required]
        public string SellerFname { get; set; }
        [Required]
        public string SellerLname { get; set; }
    }
}
