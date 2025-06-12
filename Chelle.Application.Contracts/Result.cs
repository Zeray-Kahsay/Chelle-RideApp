namespace Chelle.Application;

public record Result<T>
{
  public bool IsSuccess { get; set; }
  public T? Data { get; set; }
  public IEnumerable<string> Errors { get; set; } = [];

  public static Result<T> Success(T data) => new Result<T> { IsSuccess = true, Data = data };
  public static Result<T> Failure(params string[] errors) => new Result<T> { IsSuccess = false, Errors = errors };
}
