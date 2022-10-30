using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Ehealthcare.Api;
using E_healthcare.Web.HttpClients;
using EHealthcare.Entities;

namespace E_healthcare.Web.Helpers
{
    public interface IAuthenticationHelper
    {
        Task<AuthUserModel> GetUserLogin(Users users);
    }

    public class AuthenticationHelper : IAuthenticationHelper
    {
        #region Variables
        private readonly AuthenticationHttpClient _authenticationHttpClient;
        #endregion Variables

        #region Constructor
        public AuthenticationHelper(AuthenticationHttpClient authenticationHttpClient)
        {
            _authenticationHttpClient = authenticationHttpClient;
        }
        #endregion Constructor

        #region Methods
        public async Task<AuthUserModel> GetUserLogin(Users users)
        {
            try
            {
                if (users != null)
                {
                    var authUserModel = await _authenticationHttpClient.GetUserAuth(users);//await call from httpclient
                    return authUserModel;
                }
                return null;

            }
            catch(Exception ex)
            {
                return null;
            }

        } 
        #endregion Methods
    }
}
