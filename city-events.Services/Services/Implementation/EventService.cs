using AutoMapper;
using city_events.Entity.Models;
using city_events.Repository;
using city_events.Services.Abstract;
using city_events.Services.Models;

namespace city_events.Services.Implementation;

public class EventService :IEventService
{
    private readonly IRepository<Events> eventRepository;
    private readonly IMapper mapper;
    public EventService(IRepository<Events> eventRepository, IMapper mapper)
    {
        this.eventRepository=eventRepository;
        this.mapper = mapper;
    }

    public void DeleteEvent(Guid id)
    {
        var eventToDelete =eventRepository.GetById(id);
        if (eventToDelete == null)
        {
            throw new Exception("Admin not found");
        }
        eventRepository.Delete(eventToDelete);
    }

    public EventModel GetEvent(Guid id)
    {
        var events = eventRepository.GetById(id);
        return mapper.Map<EventModel>(events);
    }

    public PageModel<EventPreviewModel> GetEvents(int limit = 20, int offset = 0)
    {
        var events =eventRepository.GetAll();
        int totalCount =events.Count();
        var chunk=events.OrderBy(x=>x.EventName).Skip(offset).Take(limit);

        return new PageModel<EventPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<EventPreviewModel>>(events),
            TotalCount = totalCount
        };
    }

    public EventModel UpdateEvent(Guid id, UpdateEventModel events)
    {
        var existingEvent = eventRepository.GetById(id);
        if (existingEvent == null)
        {
            throw new Exception("Admin not found");
        }
        existingEvent.EventName=events.EventName;
        existingEvent.EventPlace=events.EventPlace;
        existingEvent.DateStart=events.DateStart;
        existingEvent.DateFinish=events.DateFinish;
        existingEvent = eventRepository.Save(existingEvent);
        return mapper.Map<EventModel>(existingEvent);
    }
}