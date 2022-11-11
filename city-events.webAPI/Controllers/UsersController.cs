using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using city_events.Entity.Models;
using city_events.Repository;
using Microsoft.AspNetCore.Mvc;


namespace city_events.webAPI.Controllers
{
    /// <summary>
    /// Doctors endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IRepository<User> _repository;

        /// <summary>
        /// Users controller
        /// </summary>
        public UsersController(IRepository<User> repository)
        {
            _repository = repository;
        }
        
        
        /// <summary>
        /// Get users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUsers()
        {
            //create new city via repository
            // get city id

            
            var myUser=new User()
            {
                FullName="Zazulin Nikita",
                Email="zazulin@gmail.com",
                PasswordHash="112qazwsx",
                CityId=_repository.GetCity()            
                
            };
            try{
                _repository.Save(myUser);

            }
            catch(Exception e){

            }
            
            var users =_repository.GetAll();
            return Ok(users);
        }
        
        
        
        
        /// <summary>
        /// Delete users
        /// </summary>
        /// <param name="user"></param>
        [HttpDelete]
        public IActionResult DeleteUsers(User user)
        {
            _repository.Delete(user);
            return Ok();
        }
        /// <summary>
        /// Post users
        /// </summary>
        /// <param name="users"></param>
        [HttpPost]
        public IActionResult PostUsers(User user)
        {
            var result = _repository.Save(user);
            return Ok(result);
        }

        /// <summary>
        /// Update users
        /// </summary>
        /// <param name="users"></param>
        [HttpPut]
        public IActionResult Updatesers(User user)
        {
            return PostUsers(user);
        }

    }

}
