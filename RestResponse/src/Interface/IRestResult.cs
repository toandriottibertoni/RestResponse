using Microsoft.AspNetCore.Mvc;

namespace RestResponse.Interface
{
    public interface IRestResult
    {
        void setController(ControllerBase controllerBase);
        IActionResult Gen<T>(RestStatusResponse<T> status) where T : class;
    }
}