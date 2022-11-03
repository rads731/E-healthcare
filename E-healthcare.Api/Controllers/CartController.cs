using EHealthcare.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProjectManagement.Api.Controllers
{ 
    [Authorize]
    [ApiController]
    [Route("api/Cart")]
    public class CartController : BaseController<Cart>
    {
        private readonly IBaseRepository<CartItem> CartItemRepository;
        public CartController(IBaseRepository<CartItem> _CartRepository)
        {
            CartItemRepository = _CartRepository;
        }

        [HttpGet("GetByUserID/{id}")]
        public IActionResult Get(long userID)
        {
            Cart result = Repository.Get().Where(i => i.OwnerID == userID).FirstOrDefault();
            if (result is null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [Route("PlaceOrder/{userID}")]
        [HttpPost]
        public async Task<IActionResult> PlaceOrder(long userID)
        {
            try
            {
                var userCart = Repository.Get().Where(i => i.OwnerID == userID).FirstOrDefault();

                if (userCart is null)
                {
                    userCart = await Repository.Add(new Cart { OwnerID = userID });
                }
                foreach (var item in userCart.Items)
                {
                    CartItemRepository.Add(item);
                }
                return Ok();
            }catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        [Route("AddInfo")]
        [HttpPost]
        public async Task<IActionResult> Post(long productID, long userID)
        {
            try
            {
                var userCart = Repository.Get().Where(i => i.OwnerID == userID).FirstOrDefault();

                if (userCart == null)
                {
                    userCart = await Repository.Add(new Cart { OwnerID = userID });

                }
                var cartItem = new CartItem { CartID = userCart.ID, ProductID = productID };
                var result = CartItemRepository.Add(cartItem);
                return Ok();
            }catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        public async override Task<IActionResult> Delete(long id)
        {
            await CartItemRepository.Delete(id);
            return Ok(); ;
        }
    }
}
