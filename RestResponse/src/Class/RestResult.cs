using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using RestResponse.Interface;

namespace RestResponse
{
    
    public class RestResult : IRestResult
    {
        public IActionResult RestResponse<T>(List<T> list,
                                             ControllerBase controllerBase,
                                             HttpStatusCode httpStatusCodeSucess = HttpStatusCode.OK,
                                             HttpStatusCode httpStatusCodeEmpty  = HttpStatusCode.NotFound,
                                             HttpStatusCode httpStatusCodeNull   = HttpStatusCode.InternalServerError) where T : class
        {
            if(list == null)
                return controllerBase.StatusCode((int) httpStatusCodeNull);
            else if(list.Count == 0)
                return controllerBase.StatusCode((int) httpStatusCodeEmpty);
            else
                return controllerBase.StatusCode((int) httpStatusCodeSucess, list);
        }

        public IActionResult RestResponse<T>(T data,
                                             ControllerBase controllerBase,
                                             HttpStatusCode httpStatusCodeSucess = HttpStatusCode.OK,
                                             HttpStatusCode htppStatusCodeNull   = HttpStatusCode.NotFound) where T : class
        {

            if(data == null)
                return controllerBase.StatusCode((int) htppStatusCodeNull);
            else
                return controllerBase.StatusCode((int) httpStatusCodeSucess, data);
        }

        public IActionResult RestResponse<T>(T data,
                                             ControllerBase controllerBase,
                                             Func<T, bool> isEmpty,
                                             HttpStatusCode httpStatusCodeSucess = HttpStatusCode.OK,
                                             HttpStatusCode httpStatusEmpty      = HttpStatusCode.NotFound,
                                             HttpStatusCode httpStatusCodeNull   = HttpStatusCode.InternalServerError) where T : class
        {
            if(data == null)
                return controllerBase.StatusCode((int) httpStatusCodeNull);            
            else if(isEmpty(data))
                return controllerBase.StatusCode((int) httpStatusEmpty);
            else
                return controllerBase.StatusCode((int) httpStatusCodeSucess, data);
        }

        public IActionResult RestResponse<T>(IEnumerable<T> list,
                                             ControllerBase controllerBase,
                                             HttpStatusCode httpStatusCodeSucess = HttpStatusCode.OK,
                                             HttpStatusCode httpStatusCodeEmpty  = HttpStatusCode.NotFound,
                                             HttpStatusCode httpStatusCodeNull   = HttpStatusCode.InternalServerError) where T : class
        {
            if(list == null)
                return controllerBase.StatusCode((int) httpStatusCodeNull);            
            else if (list.Any() != true)
                return controllerBase.StatusCode((int) httpStatusCodeEmpty);         
            else
                return controllerBase.StatusCode((int) httpStatusCodeSucess, list);
        }
    }
}