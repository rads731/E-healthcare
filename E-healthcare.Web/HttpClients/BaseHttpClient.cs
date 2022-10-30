using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace E_healthcare.Web.HttpClients
{

    [ExcludeFromCodeCoverage]
    public class BaseHttpClient 
    {
        #region Variables
        private IConfiguration _configuration { get; }
        private HttpClient _httpClient { get; }
        private string baseUrl => _configuration["baseUrl"];
        #endregion Variables

        #region Constructor
        public BaseHttpClient(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            
        }
        #endregion Constructor

        #region Methods
        protected async Task<HttpRequestMessage> GetAuthPostHttpRequestMessage<T>(string endpoint, T request)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, endpoint)
            {
                Content = new StringContent(request?.ToString(), Encoding.UTF8, "application/json")
            };

           

            return httpRequestMessage;
        }

        protected async Task<HttpRequestMessage> GetAuthGetHttpRequestMessage<T>(string endpoint, T request)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, endpoint)
            {
                Content = new StringContent(request?.ToString(), Encoding.UTF8, "application/json")
            };



            return httpRequestMessage;
        }
        #endregion Methods
    }
}
