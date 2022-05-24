using AspIntro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspIntro.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(string search)
        {
            List<Product> products = new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "Test 1",
                    Description = "Test 1 desc",
                    Image = "camera.jfif",
                    Price = 100
                },
                new Product
                {
                    Id = 2,
                    Name = "Test 2",
                    Description = "Test 2 desc",
                    Image = "car.jpg",
                    Price = 105
                },
                new Product
                {
                    Id = 3,
                    Name = "Test 3",
                    Description = "Test 3 desc",
                    Image = "headphone.jpg",
                    Price = 103
                }
            };

            if (!string.IsNullOrWhiteSpace(search))
            {
                products = products.FindAll(p => p.Name.ToLower().Contains(search.ToLower()));
                if (products.Count == 0)
                    return NotFound();
            }

            return View(products);
        }
    }
}
