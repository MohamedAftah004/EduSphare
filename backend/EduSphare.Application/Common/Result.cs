using EduSphare.Domain.Common;

namespace EduSphare.Application.Common;

public class Result
{
    protected Result(
        bool isSuccess,
        Error? error)
    {
        if (isSuccess && error is not null)
            throw new InvalidOperationException();

        if (!isSuccess && error is null)
            throw new InvalidOperationException();

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error? Error { get; }

    public static Result Success()
        => new(true, null);

    public static Result Failure(Error error)
        => new(false, error);

    public static Result<T> Success<T>(T value)
        => Result<T>.Success(value);

    public static Result<T> Failure<T>(Error error)
        => Result<T>.Failure(error);
}

public sealed class Result<T> : Result
{
    private Result(
        T? value,
        bool isSuccess,
        Error? error)
        : base(isSuccess, error)
    {
        Value = value;
    }

    public T? Value { get; }

    public static Result<T> Success(T value)
        => new(value, true, null);

    public static Result<T> Failure(Error error)
        => new(default, false, error);
}