using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Model
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public decimal Price { get; set; }
        /*DTO là lấy dữ liệu ra sẽ không có các thuộc tính này, 
         * các thuộc tính này sẽ xử lý trong phần liên kết dữ liệu database
            public DateTime? Created { get; set; }
            public string CreateBy { get; set; } = string.Empty;
            public DateTime? Updated { get; set; }
            public string UpdateBy { get; set; } = string.Empty;
        */
        public virtual CategoryDTO? Category { get; set; }
    }
}
