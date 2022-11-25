using city_events.Services.Models;
namespace city_events.Services.Abstract;

public interface IEventService
{
    EventModel GetEvent(Guid id);

    EventModel UpdateEvent(Guid id,UpdateEventModel even);

    void DeleteEvent(Guid id);

    PageModel<EventPreviewModel> GetEvents(int limit = 20, int offset = 0);
}