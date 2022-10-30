using Ehealthcare.Api;
using EHealthcare.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace E_healthcare.Web.HttpClients
{
    public interface IAuthenticationHttpClient
    {
        Task<AuthUserModel> GetUserAuth(Users userRequest);
    }

    public class AuthenticationHttpClient : BaseHttpClient, IAuthenticationHttpClient
    {
        #region Variables
        private IConfiguration _configuration { get; }
        private string baseUrl => _configuration["baseUrl"];
        private HttpClient _httpClient { get; }
        #endregion Variables

        #region Constructor
        public AuthenticationHttpClient(IConfiguration configuration, HttpClient httpClient) :base(configuration,httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
           
        }
        #endregion Constructor

        #region Methods
        public async Task<AuthUserModel> GetUserAuth(Users userRequest)
        {


        
            try
            {
                string apiUrl = $"{baseUrl}/api/user/login";
                var requestPayload = JsonConvert.SerializeObject(userRequest);
                
                _httpClient.DefaultRequestHeaders.Accept.Clear();
               

                HttpRequestMessage httpRequestMessage = await GetAuthPostHttpRequestMessage(apiUrl, userRequest);
                HttpResponseMessage httpResponse = await _httpClient.SendAsync(httpRequestMessage);
               
                httpResponse.EnsureSuccessStatusCode();
                var serializer = new JsonSerializer();
                using Stream responseStream = await httpResponse.Content.ReadAsStreamAsync();
                var streamReader = new StreamReader(responseStream, new UTF8Encoding());
                using (var jsonTextReader = new JsonTextReader(streamReader))
                {
                    return serializer.Deserialize<AuthUserModel>(jsonTextReader);
                }
                
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        #endregion Methods
    }
}
