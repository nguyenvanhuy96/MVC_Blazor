using IMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Business.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<CategoryDTO> CreateCategory(CategoryDTO categoryDTO);
        public Task<CategoryDTO> UpdateCategory(int categoryId, CategoryDTO categoryDTO);
        public Task<CategoryDTO> GetCategory(int categoryId);
        public Task<int> DeleteCategory(int roomId);
        public Task<IEnumerable<CategoryDTO>> GetAllCategories();
        public Task<CategoryDTO> IsRoomUnique(string name);

    }
}
