using Microsoft.AspNetCore.Mvc;
using RestResponse.Enums;
using RestResponse.Interface;

namespace RestResponse
{
    public class RestResult : IRestResult
    {
        private ControllerBase controllerBase;
        public void setController(ControllerBase controllerBase)
        {
            this.controllerBase = controllerBase;
        }

        public IActionResult Gen<T>(RestStatusResponse<T> status) where T : class
        {
            switch(status.BaseStatusCode)
            {
                case 200:
                    return Gen200<T>(status);
                case 400:
                    return Gen400(status);
            }
            return controllerBase.Ok();
        }

        private IActionResult Gen200<T>(RestStatusResponse<T> status) where T : class
        {
            switch (status.statusCode)
            {
                case StatusCode.Ok200:
                    return controllerBase.Ok(status.data);
            }
            return controllerBase.Ok();
        }

        private IActionResult Gen400<T>(RestStatusResponse<T> status)where T : class
        {
            switch (status.statusCode)
            {
                case StatusCode.NotFound404:
                    return controllerBase.NotFound();
            }
            return controllerBase.Ok();
        }
    }
}