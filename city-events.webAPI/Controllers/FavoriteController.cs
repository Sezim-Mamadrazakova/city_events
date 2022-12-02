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
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService favServise;
        private readonly IMapper mapper;

        /// <summary>
        /// favorite controller
        /// </summary>
        public FavoriteController(IFavoriteService favServise,IMapper mapper)
        {
            this.favServise=favServise;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get favorites by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetFavorites([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =favServise.GetFavorites(limit,offset);

            return Ok(mapper.Map<PageResponse<FavotiteResponses>>(pageModel));
        }
        /// <summary>
        /// Delete events
        /// </summary>
        /// <param name="favorites"></param>
        [HttpDelete]
        public IActionResult DeleteFavorite([FromRoute] Guid id)
        {
            try
            {
                favServise.DeleteFavorite(id);
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
        public IActionResult GetFavorite([FromRoute] Guid id)
        {
            try
            {
                var favModel =favServise.GetFavorite(id);
                return Ok(mapper.Map<EventResponse>(favModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update favorite
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateFavorite([FromRoute] Guid id, [FromBody] FavotiteResponses model)
        {
           
           try
           {
            var resultModel = favServise.UpdateFavorite(id,mapper.Map<FavoriteModel>(model));
            return Ok(mapper.Map<FavotiteResponses>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
        
    }

}