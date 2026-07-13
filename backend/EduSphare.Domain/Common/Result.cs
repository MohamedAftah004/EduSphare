namespace EduSphare.Domain.Common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string Error { get; }
        protected Result(bool isSuccess, string? error)
        {
            if (isSuccess && !string.IsNullOrEmpty(error))
                throw new InvalidOperationException();
            if (!isSuccess && string.IsNullOrEmpty(error))
                throw new InvalidOperationException();
            IsSuccess = isSuccess;
            Error = error;
        }
        public static Result Success()
        {
            return new Result(true, string.Empty);
        }
        public static Result Failure(string error)
        {
            return new Result(false, error);
        }
    }

    //Generic
    public class Result<T> : Result
    {
        public T? Value { get; }

        private Result(
            T? value,
            bool isSuccess,
            string? error)
            : base(isSuccess, error)
        {
            Value = value;
        }

        public static Result<T> Success(T value)
            => new(value, true, null);

        public new static Result<T> Failure(string error)
            => new(default, false, error);
    }
}
