using RestResponse.Enums;

namespace RestResponse
{
    public class RestDataResponse
    {
        public RestStatusResponse OK_200(dynamic data)
        {
            return new RestStatusResponse(){
                data = data,
                statusCode = StatusCode._200OK
            };
        }

        public RestStatusResponse NotFound_404()
        {
            return new RestStatusResponse(){
                data = string.Empty,
                statusCode = StatusCode._404NotFound
            };
        }
    }
}