using EHealthcare.Entities;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Ehealthcare.Api.Controllers
{
    [ApiController]
    public class MedicineController : Controller
    {
        private IBaseRepository<Product> ProductRepo { get; set; }
        public MedicineController(IBaseRepository<Product> repository)
        {
            ProductRepo = repository;
        }

        [HttpGet("search/{uses}")]
        public  ActionResult<List<Product>> SearchMedicineByDisease(string uses)
        {
            try
            {
                return Ok(ProductRepo.Get().Where(p => p.Uses.Contains(uses)).ToList());
            }catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        [HttpGet("getAllMedicine")]
        public ActionResult<List<Product>> GetAll()
        {
            try
            {
                return Ok(ProductRepo.Get().ToList());
            }catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }
    }
}
