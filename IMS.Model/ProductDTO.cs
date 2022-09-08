using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Model
{
    public class ProductDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int CategoryId { get; set; }
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        [MaxLength(256)]
        public string Image { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
        public decimal Price { get; set; }
        /*Khi thao tác với người dùng sẽ không có trường này
            public DateTime? Created { get; set; }
            public string CreateBy { get; set; } = string.Empty;
            public DateTime? Updated { get; set; }
            public string UpdateBy { get; set; } = string.Empty;
         */
        [ForeignKey("CategoryId")]
        public virtual CategoryDTO? Category { get; set; }
    }
}
