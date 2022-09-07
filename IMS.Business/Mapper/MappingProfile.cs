using AutoMapper;
using IMS.DataAccess;
using IMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Business.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // ánh xạ dữ liệu của HotelRoomDTO sang HotelRom thông qua tên của thuộc tính đối tượn
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
