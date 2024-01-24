namespace Poc.Foxit.Api.Responses
{
    public class BadRequest : BaseResponse
    {
        public BadRequest(object data) : base(false, data)
        {
        }
    }
}
