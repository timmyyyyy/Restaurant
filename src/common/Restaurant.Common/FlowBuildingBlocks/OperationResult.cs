using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

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
        readonly Exception exception;

        public OperationResult(OperationResultState state, Exception exception)
        {
            this.state = state;
            this.exception = exception;
        }
    }

    public readonly struct OperationResult<T>
    {
        internal readonly OperationResultState state;
        internal readonly T value;
        readonly Exception exception;

        public OperationResult(T val)
        {
            value = val;
            state = OperationResultState.Success;
            exception = null!;
        }

        public OperationResult(Exception ex)
        {
            value = default(T)!;
            state = OperationResultState.Failed;
            exception = ex;
        }

        public static implicit operator OperationResult(OperationResult<T> operationResult)
        {
            return new OperationResult(operationResult.state, operationResult.exception);
        }

        public bool IsSuccess => state == OperationResultState.Success;

        public bool IsFailed => state == OperationResultState.Failed;

        public T Value => value;

        //public static implicit operator OperationResult<T>(T value) => new OperationResult<T>(value);
        // TODO
        //https://github.com/louthy/language-ext/blob/main/LanguageExt.Core/Common/Result/OptionalResult.cs
    }
}
