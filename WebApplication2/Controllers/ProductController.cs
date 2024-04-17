using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers {
	public class ProductController : Controller {

		public readonly List<Product> _products;

		public ProductController() {
			_products = new List<Product> {
				new Product { Id = 1, Name = "Product 1", Price = 100 },
				new Product { Id = 2, Name = "Product 2", Price = 200 },
				new Product { Id = 3, Name = "Product 3", Price = 300 }
			};
		}
		public IActionResult Index() {
			if (_products.Count == 0) {
				return View("Error");
			}
			TempData["Products"] = _products;
			return View();
		}

		public IActionResult Detail(int id) {
			var product = _products.FirstOrDefault(p => p.Id == id);
			if (product == null) {
				return View("Error");
			}
			TempData["Product"] = product;
			return View();
		}
	}
}
