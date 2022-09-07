using IMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Business.Repository.IRepository
{
    public interface IProductRepository
    {
        public Task<ProductDTO> CreateProduct(ProductDTO categoryDTO);
        public Task<ProductDTO> UpdateProduct(int categoryId, ProductDTO categoryDTO);
        public Task<ProductDTO> GetProduct(int categoryId);
        public Task<int> DeleteProduct(int roomId);
        public Task<IEnumerable<ProductDTO>> GetAllProducts();
        public Task<ProductDTO> IsRoomUnique(string name);
    }
}
