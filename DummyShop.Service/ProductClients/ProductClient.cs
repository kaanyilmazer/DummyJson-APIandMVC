using DummyShop.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using RestSharp.Serializers.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DummyShop.Service.ProductClients
{
    public class ProductClient : IProductClient
    {
        private readonly RestClient _client;
        private readonly string _url;

        public ProductClient()
        {
            _url = "https://dummyjson.com/products/";
            var options = new RestClientOptions(_url);
            _client = new RestClient(options);
        }


        public async Task<RootViewModel> Create(RootViewModel rootViewModel)
        {
            var request = new RestRequest("add");
            var response = await _client.ExecutePostAsync(request);
            RestResponse<RootViewModel> data = JsonSerializer.Deserialize<RestResponse<RootViewModel>>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return data.Data;
        }

     

        public async Task<RootViewModel> GetAllProduct()
        {
            var request = new RestRequest();
            var response = await _client.ExecuteGetAsync(request);
            RootViewModel data = JsonSerializer.Deserialize<RootViewModel>(response.Content , new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return data;
        }

        public async Task<ProductViewModel?> GetProductById(int id)
        {
            var request = new RestRequest($"{id}");
            RestResponse<ProductViewModel> response = await _client.ExecuteGetAsync<ProductViewModel>(request);
            //ProductViewModel p = JsonSerializer.DeserializeAsync<ProductViewModel>(response.Content);
            return response.Data;
        }


        public async Task<ProductViewModel?> Search(string param)
        {
            var request = new RestRequest("?q="+$"{param}");
            RestResponse<ProductViewModel> response = await _client.ExecuteGetAsync<ProductViewModel?>(request);
            return response.Data;
        }

  

        public async Task<RootViewModel> Update(RootViewModel rootViewModel ,int id)
        {
            var request = new RestRequest($"{id}");
            var response = await _client.ExecutePutAsync(request);
            RestResponse<RootViewModel> data = JsonSerializer.Deserialize<RestResponse<RootViewModel>>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return data.Data;
        }

        //public async Task Delete(int id)
        //{
        //    var request = new RestRequest()
        //                    .AddQueryParameter<int>("Id", id);
        //    // https://jsonplaceholder.typicode.com/users?id=12

        //    await _client.DeleteAsync(request);
        //}

        public async Task<ProductViewModel?> Delete(int id)
        {
            var request = new RestRequest($"{id}");
            var response = await _client.DeleteAsync(request);
            ProductViewModel data = JsonSerializer.Deserialize<ProductViewModel>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return data;
           
        }
    }
}
