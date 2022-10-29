using EHealthcare.Entities;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class ProductController : BaseController<Product>
    {
        private IBaseRepository<Category> CatRepository { get; set; }
        public ProductController(IBaseRepository<Category> repository)
        {
            CatRepository = repository;
        }

        [HttpPost("addMedicine")]
        public async Task<IActionResult> AddMedicine(Product product)
        {
            try
            {
                return Ok(await base.Post(product));
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }

        }

        [HttpPut("updateMedicine")]
        public async Task<IActionResult> UpdateMedicine(Product product)
        {
            try
            {
                return Ok(await base.Post(product));
            }catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }

        }

        [HttpGet("getAllMedicine")]
        public IActionResult Get()
        {
            try
            {
                return Ok(base.Get());
            }catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        [HttpGet("getMedicineById/{mid}")]
        public IActionResult UpdateMedicine(long id)
        {
            try
            {
                return Ok(base.Get(id));
            }catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }

        }

        [HttpDelete("deleteMedicineById/{mid}")]
        public async Task<IActionResult> DeleteMedicine(long id)
        {
            try
            {
                return await base.Delete(id);
            }catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }

        }
    }
}
