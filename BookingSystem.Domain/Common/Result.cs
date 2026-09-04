using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Domain.Common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string Error { get; }

        protected Result(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, string.Empty);
        public static Result Failure(string error) => new(false, error);
        public static Result<TValue> Success<TValue>(TValue value) => new(value, true, string.Empty);
        public static Result<TValue> Failure<TValue>(string error) => new(default!, false, error);
    }

    public class Result<TValue> : Result
    {
        private readonly TValue _value;

        public TValue Value => IsSuccess
            ? _value
            : throw new InvalidOperationException("Can't get value for failed result.");

        internal Result(TValue value, bool isSuccess, string error) : base(isSuccess, error)
        {
            _value = value;
        }
    }

}
