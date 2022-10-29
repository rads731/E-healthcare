using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ehealthcare.Entities.Dto;
using EHealthcare.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;

namespace Ehealthcare.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IBaseRepository<User> UserRepository;
        public UserController(IBaseRepository<User> UserRepo)
        {
            UserRepository = UserRepo;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("signup")]
        public async Task<string> Register(User user)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    UserRepository.Add(user);
                }
                else
                {
                    return "User not created";
                }

                return "User created";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser(LoginDto login)
        {
            if (this.ModelState.IsValid)
            {
                AuthService authService = new AuthService(UserRepository);
                AuthUserModel response = await authService.Authenticate(login).ConfigureAwait(true);
                if (response != null)
                {
                    return this.Ok(response);
                }
                else
                {
                    return this.BadRequest(new { error = "invalid_grant", error_description = "Invalid Credentials" });
                }
            }

            return this.BadRequest();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("findUser/{email}")]
        public async Task<User> Find(string email)
        {
           
            return UserRepository.Get().Where(u => u.Email == email).FirstOrDefault();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("editUser")]
        public ActionResult Update(User user)
        {
            try
            {
                User result = UserRepository.Update(user).Result;
                if (result is null)
                {
                    return BadRequest("User is not updated");
                }
                else
                {
                    return Ok("User is updated");
                }
            }
            catch (Exception ex){
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        [HttpPost]
        [Route("Admin/addMedicines")]
        public ActionResult<Product> AddMedicines(Product product)
        {
            try
            {
                if (product == null)
                    return BadRequest(product);
                else
                {
                    return Ok(product);
                }
            }
            catch (Exception ex) 
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }
    }
}
