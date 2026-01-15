using System;

namespace Restaurant.Common.FlowBuildingBlocks
{
    public enum OperationResultState
    {
        Failed,
        Success
    }

    public readonly struct OperationResult
    {
        internal readonly OperationResultState state;
        internal readonly Exception exception;

        internal OperationResult(OperationResultState state, Exception exception)
        {
            this.state = state;
            this.exception = exception;
        }
    }

    public readonly struct OperationResult<T>
    {
        readonly OperationResultState state;
        readonly T value; 
        readonly Exception exception;

        private OperationResult(T val)
        {
            value = val;
            state = OperationResultState.Success;
            exception = null!;
        }

        private OperationResult(Exception ex)
        {
            value = default(T)!;
            state = OperationResultState.Failed;
            exception = ex;
        }

        internal OperationResult(OperationResultState state, Exception ex)
        {
            this.state = state;
            exception = ex;
            value = default(T)!;
        }

        public static OperationResult<T> Success(T val) => new OperationResult<T>(val);

        public static OperationResult<T> Failed(Exception ex) => new OperationResult<T>(ex); 

        public static implicit operator OperationResult(OperationResult<T> operationResult)
        {
            return new OperationResult(operationResult.state, operationResult.exception);
        }

        public static implicit operator OperationResult<T>(OperationResult operationResult)
        {
            return new OperationResult<T>(operationResult.state, operationResult.exception);
        }

        public bool IsSuccess => state == OperationResultState.Success;

        public bool IsFailed => state == OperationResultState.Failed;

        public T Value => value;

        //public static implicit operator OperationResult<T>(T value) => new OperationResult<T>(value);
        // TODO
        //https://github.com/louthy/language-ext/blob/main/LanguageExt.Core/Common/Result/OptionalResult.cs
    }
}
