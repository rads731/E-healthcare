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
    public class AdminController : ControllerBase
    {

        private readonly IBaseRepository<User> AdminRepository;
        public AdminController(IBaseRepository<User> UserRepo)
        {
            AdminRepository = UserRepo;
        }
    }
}
