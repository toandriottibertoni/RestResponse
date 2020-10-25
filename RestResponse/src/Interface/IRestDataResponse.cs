using System.Collections.Generic;
using RestResponse.Enums;

namespace RestResponse.Interface
{
    public interface IRestDataResponse
    {
        RestStatusResponse<T> Ok200<T>(T data) where T : class;
        RestStatusResponse<T> NotFound404<T>(T data) where T : class;
        RestStatusResponse<List<T>> RestStatusWithList<T>(List<T> list, StatusCode statusCodeSucess = StatusCode.Ok200, StatusCode statusCodeEmpty = StatusCode.NotFound404, StatusCode statusCodeNull = StatusCode.InternalError500) where T : class;
        RestStatusResponse<T> RestStatusWithObject<T>(T data, StatusCode statusCodeSucess = StatusCode.Ok200, StatusCode statusCodeNull = StatusCode.NotFound404) where T : class;
    }
}