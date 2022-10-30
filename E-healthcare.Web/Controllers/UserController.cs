using E_healthcare.Web.Helpers;
using Ehealthcare.Api;
using EHealthcare.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace E_healthcare.Web.Controllers
{
    public class UserController : Controller
    {
        #region Variables
        private readonly AuthenticationHelper authenticationHelper;
        #endregion Variables

        #region Constructor
        public UserController(AuthenticationHelper _authenticationHelper)
        {
            authenticationHelper = _authenticationHelper;
        }
        #endregion Constructor

        #region Methods
        // GET: UserController
        public ActionResult Index()
        {
            return View("~/Views/Admin/Index.cshtml");
        }

        // GET: UserController/Details/5
        [HttpPost]
        public async Task<ActionResult<AuthUserModel>> Login(Users user)
        {
            try
            {
                if (user is null)
                    return BadRequest();
                var response = await authenticationHelper.GetUserLogin(user);
                return View("~/Views/User/Index.cshtml",response);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion Methods
    }
}
