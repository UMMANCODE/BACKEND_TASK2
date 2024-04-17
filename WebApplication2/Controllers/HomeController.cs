using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers {
	public class HomeController : Controller {
		private readonly ProductController _productController;
		private readonly BrandController _brandController;
		public HomeController() {
			_productController = new ProductController();
			_brandController = new BrandController();
		}
		public IActionResult Index() {
			if (_productController._products.Count == 0 || _brandController._brands.Count == 0) {
				return View("Error");
			}
			TempData["Products"] = _productController._products;
			TempData["Brands"] = _brandController._brands;

			return View();
		}

		public IActionResult Privacy() {
			return View();
		}
	}
}
