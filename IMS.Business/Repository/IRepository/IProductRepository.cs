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
        public Task<ProductDTO> CreateProduct(ProductDTO productDTO);
        public Task<ProductDTO> UpdateProduct(int productId, ProductDTO productDTO);
        public Task<ProductDTO> GetProduct(int productId);
        public Task<int> DeleteProduct(int productId);
        public Task<IEnumerable<ProductDTO>> GetAllProducts(string prodName="");
        public Task<ProductDTO> IsRoomUnique(string name);
    }
}
