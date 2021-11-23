using System.ComponentModel.DataAnnotations;

namespace SalesApp.Infrastructure.Models.Enums
{
    public enum ResponseCode
    {
        [Display(Name = "Completed Successfully")]
        Success = 1,
        [Display(Name = "Client Could Not Be Added")]
        CouldNotAddClient,
        [Display(Name = "Unknown Error Occured")]
        UnknownError,
        [Display(Name = "Unknown Seller")]
        UnknownSeller,
        [Display(Name = "Order Could Not Be Added")]
        CouldNotAddOrder,
        [Display(Name = "Order Parent Not Found")]
        OrderParentNotFound
    }

}
