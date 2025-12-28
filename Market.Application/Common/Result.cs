using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string? ErrorCode { get; }
        public string? Message { get; }


        protected Result(bool isSuccess , string? errorCode , string? message)
        { 
            IsSuccess = isSuccess;
            ErrorCode = errorCode;
            Message = message;
        }

        public static Result Success() => new(true, null, null);
        public static Result Failure(string errorCode, string message) => new(false, errorCode, message);

    }

    public class Result<T> : Result
    { 
    public T? Data { get; }

        protected Result(bool isSuccess,T? data, string? errorcode, string? message) : base(isSuccess, errorcode, message)
        {
            Data = data;
        }


        public static Result<T> Success(T data) => new(true,data,null,null);
        public static Result<T> Failure(string errorCode, string message) => new(false, default, errorCode, message);


    }
}
