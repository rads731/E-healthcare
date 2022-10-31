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

        private readonly IBaseRepository<Users> UserRepository;
        public UserController(IBaseRepository<Users> UserRepo)
        {
            UserRepository = UserRepo;
        }

       

        [AllowAnonymous]
        [HttpPost]
        [Route("signup")]
        public async Task<ActionResult<string>> Register(Users user)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    if (user is null)
                        return BadRequest();
                    user.ID = new Random().Next();
                    UserRepository.Add(user);
                }
                else
                {
                    return BadRequest("User not created");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthUserModel>> LoginUser(LoginDto login)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    AuthService authService = new AuthService(UserRepository);
                    AuthUserModel response = await authService.Authenticate(login).ConfigureAwait(true);
                    if (response != null)
                    {
                        return Ok(response);
                    }
                    else
                    {
                        return BadRequest(new { error = "invalid_grant", error_description = "Invalid Credentials" });
                    }
                }
            }catch(Exception ex)
            {
                throw;
            }

            return BadRequest();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("findUser/{email}")]
        public async Task<Users> Find(string email)
        {
           
            return UserRepository.Get().Where(u => u.Email == email).FirstOrDefault();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("editUser")]
        public ActionResult Update(Users user)
        {
            try
            {
                Users result = UserRepository.Update(user).Result;
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
