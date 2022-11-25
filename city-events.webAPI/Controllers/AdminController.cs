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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;
        private readonly IMapper mapper;

        /// <summary>
        /// admin controller
        /// </summary>
        public AdminController(IAdminService  adminService,IMapper mapper)
        {
            this.adminService=adminService;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get admin by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetAdmins([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =adminService.GetAdmins(limit,offset);

            return Ok(mapper.Map<PageResponse<AdminResponse>>(pageModel));
        }
        /// <summary>
        /// Delete admin
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAdmin([FromRoute] Guid id)
        {
            try
            {
                adminService.DeleteAdmin(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get admin
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAdmin([FromRoute] Guid id)
        {
            try
            {
                var adminModel =adminService.GetAdmin(id);
                return Ok(mapper.Map<AdminResponse>(adminModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update admin
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateAdmin([FromRoute] Guid id, [FromBody] UpdateAdminRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =adminService.UpdateAdmin(id,mapper.Map<UpdateAdminModel>(model));
            return Ok(mapper.Map<AdminResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
          
    }

}