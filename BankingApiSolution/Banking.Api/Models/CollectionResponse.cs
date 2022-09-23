namespace Banking.Api.Models;

public record CollectionResponse<T>
{
    public List<T> Data { get; init; } = new();
}