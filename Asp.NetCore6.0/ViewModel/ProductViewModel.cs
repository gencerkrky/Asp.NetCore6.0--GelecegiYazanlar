using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Asp.NetCore6._0.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }


        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "boş olamaz")]//alanı zorunlu kılar
      
        [Remote(action: "HasProductName",controller:"Products")]
        public string? Name { get; set; }
        public decimal Price { get; set; }

        [Range(1, 200 ,ErrorMessage = "Stok 1 ile 200 arasında olmalı")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "boş olamaz")]//alanı zorunlu kılar
        public int Stock { get; set; }

        public string? Description { get; set; }
        public string? Color { get; set; }

        public DateTime? PublishDate { get; set; }
        public bool IsPublish { get; set; }

        public int Expire { get; set; }
    }
}
