using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class ApiResponse<T> where T : class
    {
        public ApiResponse()
        {

        }

        public ApiResponse(TableStatic.StatusCodes _status)
        {
            Status = _status;
        }

        public ApiResponse(TableStatic.StatusCodes _status, string _message)
        {
            Status = _status;
            Message = _message;
        }

        public ApiResponse(TableStatic.StatusCodes _status, T _data)
        {
            Status = _status;
            Message = "sucess";
            Data = _data;
        }

        public TableStatic.StatusCodes Status { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

    }
}
