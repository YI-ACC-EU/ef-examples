namespace AirportExample.Models;
public class Result<T>
{
    public T? Content { get; set; }
    public List<string>? Errors { get; set; }
    public bool IsSuccess => Errors?.Any() != true;

    public static Result<T> Create(T? content) =>
        new()
        {
            Content = content
        };

    public static Result<T> CreateWithErrors(IEnumerable<string> errors) =>
        new Result<T>
        {
            Errors = errors.ToList()
        };

    public static Result<T> CreateWithError(string error) =>
        new Result<T>
        {
            Errors = new () { error}
        };
}