namespace Poc.Foxit.Api.Responses
{
    public abstract class BaseResponse
    {
        protected BaseResponse(bool success, object data)
        {
            Success = success;
            Data = data;
        }

        public bool Success { get; set; }
        public object Data { get; set; }
    }
}
