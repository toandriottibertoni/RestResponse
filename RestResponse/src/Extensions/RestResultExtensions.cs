using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace RestResponse.Extensions
{
    public static class RestResponseExtensions
    {
        public static IActionResult RestResponse<T>(this T data,
                                                   ControllerBase controllerBase,
                                                   HttpStatusCode httpStatusCodeSucess = HttpStatusCode.OK,
                                                   HttpStatusCode httpStatusCodeNull   = HttpStatusCode.NotFound) where T : class
        {
            return new RestResult().RestResponse<T>(data,
                                                    controllerBase,
                                                    httpStatusCodeSucess,
                                                    httpStatusCodeNull);
        }

        public static IActionResult RestResponse<T>(this T data, 
                                                    ControllerBase controllerBase,
                                                    Func<T, bool> isEmpty,
                                                    HttpStatusCode httpStatusCodeSucess = HttpStatusCode.OK,
                                                    HttpStatusCode httpStatusCodeEmpty  = HttpStatusCode.NotFound,
                                                    HttpStatusCode httpStatusCodeNull   = HttpStatusCode.InternalServerError) where T : class
        {
            return new RestResult().RestResponse<T>(data,
                                                    controllerBase,
                                                    isEmpty,
                                                    httpStatusCodeSucess,
                                                    httpStatusCodeEmpty,
                                                    httpStatusCodeNull);
        }

        public static IActionResult RestResponse<T>(this List<T> list,
                                                    ControllerBase controllerBase,
                                                    HttpStatusCode httpStatusCodeSucess = HttpStatusCode.OK,
                                                    HttpStatusCode httpStatusCodeEmpty  = HttpStatusCode.NotFound,
                                                    HttpStatusCode httpStatusCodeNull   = HttpStatusCode.InternalServerError) where T : class
        {
            return new RestResult().RestResponse<T>(list,
                                                    controllerBase,
                                                    httpStatusCodeSucess,
                                                    httpStatusCodeEmpty,
                                                    httpStatusCodeNull);
        }

        public static IActionResult RestResponse<T>(IEnumerable<T> list,
                                                    ControllerBase controllerBase,
                                                    HttpStatusCode httpStatusCodeSucess = HttpStatusCode.OK,
                                                    HttpStatusCode httpStatusCodeEmpty = HttpStatusCode.NotFound,
                                                    HttpStatusCode httpStatusCodeNull = HttpStatusCode.InternalServerError) where T : class
        {
            return new RestResult().RestResponse<T>(list,
                                                    controllerBase,
                                                    httpStatusCodeSucess,
                                                    httpStatusCodeEmpty,
                                                    httpStatusCodeNull);
        }
    }
}