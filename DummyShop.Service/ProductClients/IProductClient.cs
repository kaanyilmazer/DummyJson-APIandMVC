using DummyShop.Service.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyShop.Service.ProductClients
{
    public interface IProductClient
    {
        Task<ProductViewModel> GetProductById(int id);
        Task<RootViewModel> GetAllProduct();
        Task<RootViewModel> Create(RootViewModel rootViewModel);
        Task<RootViewModel> Update(RootViewModel rootViewModel, int id);

        Task<ProductViewModel> Delete(int id);

        Task<ProductViewModel> Search(string param);


    }
}
