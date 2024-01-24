namespace Poc.Foxit.Api.Responses
{
    public class OkResponse : BaseResponse
    {
        public OkResponse(object data) : base(true, data)
        {
            Data = data;
        }
    }
}
