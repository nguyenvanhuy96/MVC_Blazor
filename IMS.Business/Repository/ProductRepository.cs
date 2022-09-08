using AutoMapper;
using IMS.Business.Repository.IRepository;
using IMS.DataAccess;
using IMS.DataAccess.Data;
using IMS.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Business.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        public async Task<ProductDTO> CreateProduct(ProductDTO productDTO)
        {
            Product product = _mapper.Map<ProductDTO, Product>(productDTO); // mapping
            product.Created = DateTime.Now;
            product.CreateBy = "Huy Nguyen";
            var addedHotelRoom = await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDTO>(addedHotelRoom.Entity);
        }

        public async Task<int> DeleteProduct(int productId)
        {
            var product = await _db.Products.FindAsync(productId);
            if (product != null)
            {
                _db.Products.Remove(product);
                return _db.SaveChanges();
            }
            return 0;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts(string prodName = "")
        {
            try
            {
                IEnumerable<ProductDTO> productDTOs =
                    _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_db.Products);
                if (string.IsNullOrEmpty(prodName))
                {
                    return productDTOs;
                }
                else
                {
                    return productDTOs.Where(k => k.Name.ToLower().IndexOf(prodName.ToLower()) >= 0);
                }
                
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ProductDTO> GetProduct(int categoryId)
        {
            try
            {
                ProductDTO productDTO = _mapper.Map<Product, ProductDTO>(
                    await _db.Products.FirstOrDefaultAsync(x => x.Id == categoryId));
                return productDTO;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ProductDTO> IsRoomUnique(string name)
        {
            try
            {
                ProductDTO categoryDTO = _mapper.Map<Product, ProductDTO>(
                    await _db.Products.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));
                return categoryDTO;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async  Task<ProductDTO> UpdateProduct(int productId, ProductDTO productDTO)
        {
            try
            {
                if (productId == productDTO.Id)
                {
                    Product productDetail = await _db.Products.FindAsync(productId);
                    Product product = _mapper.Map<ProductDTO, Product>(productDTO, productDetail); // update
                    product.UpdateBy = "Huy nguyen Update";
                    product.Updated = DateTime.Now;
                    var updateProduct = _db.Products.Update(product);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<Product, ProductDTO>(updateProduct.Entity);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
