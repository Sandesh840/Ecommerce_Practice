namespace Ecommerce.Models.ViewModels;

public class PaginatedViewModel<T> where T : class
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public List<T> Items { get; set; }
}
