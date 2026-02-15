using System;

namespace Restaurant.Common.ApplicationBuildingBlocks;


public interface IOperationResult
{
    OperationResultState State { get; }
    Exception Exception { get; }
}

public enum OperationResultState
{
    Failed,
    Success
}

public readonly struct OperationResult : IOperationResult
{
    internal readonly OperationResultState state;
    internal readonly Exception exception;

    internal OperationResult(OperationResultState state, Exception exception)
    {
        this.state = state;
        this.exception = exception;
    }

    public static OperationResult Failed(Exception ex) => new(OperationResultState.Failed, ex);

    public OperationResultState State => state;

    public Exception Exception => exception;
}

public readonly struct OperationResult<T> : IOperationResult
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
        value = default!;
        state = OperationResultState.Failed;
        exception = ex;
    }

    internal OperationResult(OperationResultState state, Exception ex)
    {
        this.state = state;
        exception = ex;
        value = default!;
    }

    public static OperationResult<T> Success(T val) => new(val);

    public static OperationResult<T> Failed(Exception ex) => new(ex);

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

    public OperationResultState State => state;

    public Exception Exception => exception;
}
