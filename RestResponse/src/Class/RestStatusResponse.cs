using System;
using RestResponse.Enums;

namespace RestResponse
{
    public class RestStatusResponse<T> where T : class
    {
        public T data {get; set;}
        public StatusCode statusCode 
        {
            get
            {
                return _statusCode;
            } 
            set
            {
                _statusCode = value;
                DefBaseStatusCode(_statusCode);
            }
        }

        public int BaseStatusCode { get; private set; } = 0;

        private StatusCode _statusCode;
        private void DefBaseStatusCode(StatusCode statusCode)
        {
            int status = (int) statusCode;

            if(status >= 100 && status <= 199)
                BaseStatusCode = 100;
            else if(status >= 200 && status <= 299)
                BaseStatusCode = 200;
            else if(status >= 300 && status <= 399)
                BaseStatusCode = 300;
            else if(status >= 400 && status <= 499)
                BaseStatusCode = 400;
            else if(status >= 500 && status <= 599)
                BaseStatusCode = 500;

        }
    }
}