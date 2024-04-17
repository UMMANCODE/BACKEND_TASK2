using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers {
	public class BrandController : Controller {

		public readonly List<Brand> _brands;

		public BrandController() {
			_brands = new List<Brand> {
				new Brand { Id = 1, Name = "Brand 1" },
				new Brand { Id = 2, Name = "Brand 2" },
				new Brand { Id = 3, Name = "Brand 3" }
			};
		}
		public IActionResult Index() {
			if (_brands.Count == 0) {
				return View("Error");
			}
			TempData["Brands"] = _brands;
			return View();
		}

		public IActionResult Detail(int id) {
			var brand = _brands.FirstOrDefault(b => b.Id == id);
			if (brand == null) {
				return View("Error");
			}
			TempData["Brand"] = brand;
			return View();
		}
	}
}
