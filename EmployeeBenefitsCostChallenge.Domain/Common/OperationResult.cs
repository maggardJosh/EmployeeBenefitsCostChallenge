using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBenefitsCostChallenge.Domain.Common
{
    public class OperationResult
    {
        private OperationResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public bool Success { get; }
        public string Message { get; }

        public static OperationResult Ok => new OperationResult(true, "");
        public static OperationResult Error(string message) => new OperationResult(false, message);
    }

    public class OperationResult<T>
    {
        private OperationResult(bool success, string message, T result)
        {
            Success = success;
            Message = message;
            Result = result;
        }
        public bool Success { get; }
        public string Message { get; }
        public T Result { get; }

        public static OperationResult<T> Ok(T result) => new OperationResult<T>(true, "", result);
        public static OperationResult<T> Error(string message) => new OperationResult<T>(false, message, default);
    }


}
