namespace Poc.Foxit.Api.Responses
{
    public class OkResponse
    {
        public OkResponse(object data)
        {
            Data = data;
        }

        public bool Success { get; set; } = true;
        public object Data { get; set; }
    }
}
