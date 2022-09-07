using IMS.Business.Repository.IRepository;
using IMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Business.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Task<ProductDTO> CreateProduct(ProductDTO categoryDTO)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteProduct(int roomId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetProduct(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> IsRoomUnique(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> UpdateProduct(int categoryId, ProductDTO categoryDTO)
        {
            throw new NotImplementedException();
        }
    }
}
