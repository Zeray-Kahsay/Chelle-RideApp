namespace Chelle.Core.Common;

public record Result<T>
{
  public bool IsSuccess { get; set; }
  public T? Data { get; set; }
  public IEnumerable<string> Errors { get; set; } = [];

  public static Result<T> Success(T data) => new() { IsSuccess = true, Data = data };
  public static Result<T> Failure(params string[] errors) => new() { IsSuccess = false, Errors = errors };
  public static Result<T> Failure(IEnumerable<string> errors) => new() { IsSuccess = false, Errors = errors };
}


public record Result
{
  public bool IsSuccess { get; set; }
  public IEnumerable<string> Errors { get; set; } = [];

  public static Result Success() => new() { IsSuccess = true };
  public static Result Failure(params string[] errors) => new() { IsSuccess = false, Errors = errors };
  public static Result Failure(IEnumerable<string> errors) => new() { IsSuccess = false, Errors = errors };
}