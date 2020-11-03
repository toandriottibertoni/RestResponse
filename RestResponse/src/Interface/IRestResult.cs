using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace RestResponse.Interface
{
    public interface IRestResult
    {
        IActionResult RestResponse<T>(List<T> list,
                                      ControllerBase controllerBase,
                                      HttpStatusCode httpStatusCodeSucess = HttpStatusCode.OK,
                                      HttpStatusCode httpStatusCodeEmpty  = HttpStatusCode.NotFound,
                                      HttpStatusCode httpStatusCodeNull   = HttpStatusCode.InternalServerError) where T : class;
        IActionResult RestResponse<T>(T data,
                                      ControllerBase controllerBase,
                                      HttpStatusCode httpStatusCodeSucess = HttpStatusCode.OK,
                                      HttpStatusCode HttpStatusCodeNull   = HttpStatusCode.NotFound) where T : class;

        IActionResult RestResponse<T>(T data,
                                      ControllerBase controllerBase,
                                      Func<T, bool> isEmpty,
                                      HttpStatusCode httpStatusCodeSucess = HttpStatusCode.OK,
                                      HttpStatusCode httpStatusCodeEmpty  = HttpStatusCode.NotFound,
                                      HttpStatusCode httpStatusCodeNull   = HttpStatusCode.InternalServerError) where T : class;
        IActionResult RestResponse<T>(IEnumerable<T> list,
                                      ControllerBase controllerBase,
                                      HttpStatusCode httpStatusCodeSucess = HttpStatusCode.OK,
                                      HttpStatusCode httpStatusCodeEmpty  = HttpStatusCode.NotFound,
                                      HttpStatusCode httpStatusCodeNull   = HttpStatusCode.InternalServerError) where T : class;
        
    }
}