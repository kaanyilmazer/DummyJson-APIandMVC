using DummyShop.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyShop.Service.ProductClientsWEB
{
        public interface IWebProductClient
        {
            Task<ProductViewModel> GetProductById(int id);
            Task<RootViewModel> GetAllProduct();
            Task<RootViewModel> Add(RootViewModel rootViewModel);
            Task<RootViewModel> Update(RootViewModel rootViewModel);
            Task<ProductViewModel> Delete(int id);
        }
}
