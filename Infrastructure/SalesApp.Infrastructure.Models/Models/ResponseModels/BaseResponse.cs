using SalesApp.Infrastructure.Common.Extensions;
using SalesApp.Infrastructure.Models.Enums;

namespace SalesApp.Infrastructure.Models.Models.ResponseModels
{
    public class BaseResponse
    {
        public bool Success { get; set; } 
        public ResponseCode ResponseCode { get; set; } 
        public string ResponseString { get { return ResponseCode.GetDisplayName(); } } 

        public BaseResponse() { }

        public BaseResponse(bool success, ResponseCode responseCode)
        {
            Success = success;
            ResponseCode = responseCode;
        }
    }
}
