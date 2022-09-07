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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }
        public async Task<CategoryDTO> CreateCategory(CategoryDTO categoryDTO)
        {
            Category holtelRoom = _mapper.Map<CategoryDTO, Category>(categoryDTO); // mapping
            holtelRoom.Created = DateTime.Now;
            holtelRoom.CreateBy = "Huy Nguyen";
            var addedHotelRoom = await _db.Categories.AddAsync(holtelRoom);
            await _db.SaveChangesAsync();
            return _mapper.Map<Category, CategoryDTO>(addedHotelRoom.Entity);
        }

        public async Task<int> DeleteCategory(int categoryId)
        {
            var roomDetail = await _db.Categories.FindAsync(categoryId);
            if (roomDetail != null)
            {
                _db.Categories.Remove(roomDetail);
                return _db.SaveChanges();
            }
            return 0;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            try
            {
                IEnumerable<CategoryDTO> categoryDTOs =
                    _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
                return categoryDTOs;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<CategoryDTO> GetCategory(int categoryId)
        {
            try
            {
                CategoryDTO categoryDTO = _mapper.Map<Category, CategoryDTO>(
                    await _db.Categories.FirstOrDefaultAsync(x => x.Id == categoryId));
                return categoryDTO;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<CategoryDTO> IsRoomUnique(string name)
        {
            try
            {
                CategoryDTO categoryDTO = _mapper.Map<Category, CategoryDTO>(
                    await _db.Categories.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));
                return categoryDTO;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<CategoryDTO> UpdateCategory(int categoryId, CategoryDTO categoryDTO)
        {
            try
            {
                if (categoryId == categoryDTO.Id)
                {
                    Category categoryDetail = await _db.Categories.FindAsync(categoryId);
                    Category category = _mapper.Map<CategoryDTO, Category>(categoryDTO, categoryDetail); // update
                    category.UpdateBy = "Huy nguyen Update";
                    category.Updated = DateTime.Now;
                    var updateCategory = _db.Categories.Update(category);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<Category, CategoryDTO>(updateCategory.Entity);
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
