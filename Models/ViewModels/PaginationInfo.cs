namespace Mission10_Sheffield.Models.ViewModels;

public class PaginationInfo
{
    public int CurrentPage { get; set; }
    public int ItemsPerPage { get; set; }
    public int TotalNumItems { get; set; }
    
    public int TotalPages => (int)Math.Ceiling((decimal)TotalNumItems / (decimal)ItemsPerPage);
}