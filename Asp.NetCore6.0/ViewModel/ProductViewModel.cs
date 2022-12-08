using Microsoft.Build.Framework;

namespace Asp.NetCore6._0.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]//alanı zorunlu kılar
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public string Description { get; set; }
        public string? Color { get; set; }

        public DateTime? PublishDate { get; set; }
        public bool IsPublish { get; set; }

        public int Expire { get; set; }
    }
}
