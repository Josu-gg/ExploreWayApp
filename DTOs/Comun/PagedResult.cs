namespace ExploreWayApp.DTOs.Comun;

// Forma del PagedModel de Spring: { "content": [...], "page": { size, number, totalElements, totalPages } }
public class PagedResult<T>
{
    public List<T> Content { get; set; } = [];
    public PageInfo Page { get; set; } = new();
}
