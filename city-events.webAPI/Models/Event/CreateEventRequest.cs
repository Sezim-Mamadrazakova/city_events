namespace city_events.webAPI.Models;
public class CreateEventRequest : UpdateEventRequest{
    public Guid UserId{get;set;}
}