using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Model
{
    public class CategoryDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(256)]
        public string Image { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        /*Khi thao tác với người dùng thì không có những trường này
                 public DateTime? Created { get; set; }
                public string CreateBy { get; set; } = string.Empty;
                public DateTime? Updated { get; set; }
                public string UpdateBy { get; set; } = string.Empty;
         */
        public virtual ICollection<ProductDTO>? Products { get; set; }
    }
}
