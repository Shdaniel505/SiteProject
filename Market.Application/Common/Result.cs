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

        protected Result(bool isSuccess, string? errorCode, string? message)
        {
            IsSuccess = isSuccess;
            ErrorCode = errorCode;
            Message = message;
        }

        public static Result Success(string? message = null)
            => new(true, null, message);

        public static Result Failure(string errorCode, string message)
            => new(false, errorCode, message);
    }

    public sealed class Result<T> : Result
    {
        public T? Data { get; }

        private Result(bool isSuccess, T? data, string? errorCode, string? message)
            : base(isSuccess, errorCode, message)
        {
            Data = data;
        }

        public static Result<T> Success(T data, string? message = null)
            => new(true, data, null, message);

        public static Result<T> Failure(string errorCode, string message)
            => new(false, default, errorCode, message);
    }
}
