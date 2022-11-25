namespace city_events.Services.Models;
public class PageModel<T>
{
    public IEnumerable<T> Items { get; set; }
    public int TotalCount { get; set; }

    public PageModel() { }
}