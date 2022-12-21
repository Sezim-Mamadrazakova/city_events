using AutoMapper;
using city_events.Services.Abstract;
using city_events.Services.Models;
using city_events.webAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace city_events.webAPI.Controllers
{
    /// <summary>
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService eventServise;
        private readonly IMapper mapper;

        /// <summary>
        /// Users controller
        /// </summary>
        public EventController(IEventService eventServise,IMapper mapper)
        {
            this.eventServise=eventServise;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get events by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetEvents([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =eventServise.GetEvents(limit,offset);

            return Ok(mapper.Map<PageResponse<EventResponse>>(pageModel));
        }
        /// <summary>
        /// Delete events
        /// </summary>
        /// <param name="events"></param>
        [HttpDelete]
        public IActionResult DeleteEvent([FromRoute] Guid id)
        {
            try
            {
                eventServise.DeleteEvent(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get event
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEvent([FromRoute] Guid id)
        {
            try
            {
                var eventModel =eventServise.GetEvent(id);
                return Ok(mapper.Map<EventResponse>(eventModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update event
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateEvent([FromRoute] Guid id, [FromBody] UpdateEventRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel = eventServise.UpdateEvent(id,mapper.Map<UpdateEventModel>(model));
            return Ok(mapper.Map<EventResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
        /// <summary>
        /// create event
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateEvent([FromBody] EventModel eventModel){
            var response=eventServise.CreateEvent(eventModel);
            return Ok(response);

        }
          
    }
}