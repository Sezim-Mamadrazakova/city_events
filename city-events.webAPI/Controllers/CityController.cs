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
    public class CityController : ControllerBase
    {
        private readonly ICityService cityServise;
        private readonly IMapper mapper;

        /// <summary>
        /// Cities controller
        /// </summary>
        public CityController(ICityService cityServise,IMapper mapper)
        {
            this.cityServise=cityServise;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get cities by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetCitys([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =cityServise.GetCitys(limit,offset);

            return Ok(mapper.Map<PageResponse<CityResponse>>(pageModel));
        }
        /// <summary>
        /// Delete events
        /// </summary>
        /// <param name="cities"></param>
        [HttpDelete]
        public IActionResult DeleteCity([FromRoute] Guid id)
        {
            try
            {
                cityServise.DeleteCity(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get city
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCity([FromRoute] Guid id)
        {
            try
            {
                var cityModel =cityServise.GetCity(id);
                return Ok(mapper.Map<CityResponse>(cityModel));
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
        public IActionResult UpdateCity([FromRoute] Guid id, [FromBody] UpdateCityRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel = cityServise.UpdateCity(id,mapper.Map<UpdateCityModel>(model));
            return Ok(mapper.Map<CityResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
          
    }

}