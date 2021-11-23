using SalesApp.Infrastructure.Models.Enums;

namespace SalesApp.Infrastructure.Models.Models.ResponseModels
{
    public class GenericResponse<T> : BaseResponse
    {
        public T Data { get; set; }

        public GenericResponse() { }

        public GenericResponse(bool success, ResponseCode responseCode, T data) : base(success, responseCode)
        {
            Data = data;
        }
    }
}
