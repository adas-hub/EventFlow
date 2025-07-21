namespace EventFlow.Domain.Common;

public record Sorting(string SortBy = "CreatedDate", string SortOrder = "desc")
{
    public string SortBy { get; init; } = SortBy;
    public string SortOrder { get; init; } = SortOrder.ToLowerInvariant() == "desc" ? "desc" : "asc";
}
