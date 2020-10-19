using Microsoft.AspNetCore.Mvc;
using RestResponse.Enums;

namespace RestResponse
{
    public class RestResult
    {
        private ControllerBase controllerBase;
        public RestResult(ControllerBase controllerBase)
        {
            this.controllerBase = controllerBase;
        }

        public IActionResult Gen (RestStatusResponse status)
        {
            switch(status.statusCode)
            {
                case StatusCode._200OK:
                    return controllerBase.Ok(status.data);
                case StatusCode._404NotFound:
                    return controllerBase.NotFound();
                default :
                    return controllerBase.Ok();
            }
        }
    }
}