using System.Collections.Generic;
using RestResponse.Enums;
using RestResponse.Interface;

namespace RestResponse
{
    public class RestDataResponse : IRestDataResponse
    {
        public RestStatusResponse<T> Ok200<T>(T data) where T: class
        {
            return new RestStatusResponse<T>(){
                data = data,
                statusCode = StatusCode.Ok200,
            };
        }

        public RestStatusResponse<T> NotFound404<T>(T data = null) where T : class
        {
            return new RestStatusResponse<T>(){
                data = data,
                statusCode = StatusCode.NotFound404,
            };
        }

        public RestStatusResponse<List<T>> RestStatusWithList<T>(List<T> list, StatusCode statusCodeSucess = StatusCode.Ok200, StatusCode statusCodeEmpty = StatusCode.NotFound404, StatusCode statusCodeNull = StatusCode.InternalError500) where T : class
        {
            RestStatusResponse<List<T>> response = new RestStatusResponse<List<T>>();
            if(list == null)
                response.statusCode = statusCodeNull;
            else if(list.Count == 0)
                response.statusCode = statusCodeEmpty;
            else
            {
                response.statusCode = statusCodeSucess;
                response.data = list;
            }

            return response;
        }

        public RestStatusResponse<T> RestStatusWithObject<T>(T data, StatusCode statusCodeSucess = StatusCode.Ok200, StatusCode statusCodeNull = StatusCode.NotFound404) where T : class
        {
            RestStatusResponse<T> response = new RestStatusResponse<T>();

            if(data == null)
                response.statusCode = statusCodeNull;
            else
            {
                response.statusCode = statusCodeSucess;
                response.data = data;
            }

            return response;
        }
    }
}