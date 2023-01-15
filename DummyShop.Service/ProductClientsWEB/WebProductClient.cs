using DummyShop.Service.ViewModel;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DummyShop.Service.ProductClientsWEB
{
    public class WebProductClient : IWebProductClient
    {
        private readonly RestClient _client;
        private readonly string _url;

        public WebProductClient()
        {
            _url = "https://localhost:7123";
            var options = new RestClientOptions(_url);
            _client = new RestClient(options);
            
        }
        public async Task<RootViewModel> Add(RootViewModel rootViewModel)
        {
            var request = new RestRequest("api/Product/add");
            var response = await _client.ExecutePostAsync(request);
            RestResponse<RootViewModel> data = JsonConvert.DeserializeObject<RestResponse<RootViewModel>>(response.Content);
            return data.Data;
        }

        public async Task<ProductViewModel> Delete(int id)
        {
            var request = new RestRequest("api/Product"+$"/{id}");
            var response = await _client.DeleteAsync(request);
            ProductViewModel data = JsonConvert.DeserializeObject<ProductViewModel>(response.Content);
            return data;
        }

        public async Task<RootViewModel> GetAllProduct()
        {
            var request = new RestRequest("api/Product");
            var response = await _client.ExecuteGetAsync(request);
            var r = JsonConvert.DeserializeObject<RootViewModel>(response.Content);

            return r;
        }

        public async Task<ProductViewModel?> GetProductById(int id)
        {
            var request = new RestRequest("api/Product"+$"/{id}");
            RestResponse<ProductViewModel> response = await _client.ExecuteGetAsync<ProductViewModel>(request);
            //ProductViewModel p = JsonSerializer.DeserializeAsync<ProductViewModel>(response.Content);
            return response.Data;
        }

            public Task<RootViewModel> Update(RootViewModel rootViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
