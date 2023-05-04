using Barberries.Database;
using Barberries.Models;
using Barberries.Services;
using Microsoft.AspNetCore.Mvc;

namespace Barberries.Controllers {
	public class AdminController : Controller {
		public ApplicationContext db;

		public ICreateProductService createProductService;

		// Adding product
		[HttpGet]
		public IActionResult AddProduct() {
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddProduct(Product product, string[] keys, string[] values) {
			for(int i=0; i< keys.Length && keys[i] != null; i++) {
				product.Parameters.Add(keys[i], values[i]);
			}
			db.Products.Add(product);
			await db.SaveChangesAsync();
			return RedirectToAction("*******************************************");
		}

		public IActionResult OutputProduct(int? id) {
			if(id != null) {
				Product? product = db.Products.FirstOrDefault(p => p.Id == id);
				if(product != null) return View(product);
			}
			return NotFound("Товар не найден");
		}

		// Editing product
		[HttpGet]
		public IActionResult EditProduct(int? id = null) {
			if(id != null) {
				Product? product = db.Products.FirstOrDefault(p => p.Id == id);
				if (product != null) return View(product);
			}
			return NotFound("Товар не найден");
		}

		[HttpPost] 
		public async Task<IActionResult> EditProduct(Product product, string[] keys, string[] values) {
			createProductService.UpdateProduct(product, keys, values);
			db.Products.Update(product);
			await db.SaveChangesAsync();
			return RedirectToAction("********************************************");
		}

		// Removing product
		[HttpPost]
		public async Task<IActionResult> RemoveProduct(int? id = null) {
			if(id != null) {
				Product? product = db.Products.FirstOrDefault(p => p.Id == id);
				if(product != null) {
					db.Products.Remove(product);
					await db.SaveChangesAsync();
					return RedirectToAction("************************************");
				}
			}
			return NotFound("Товар не найден");
		}
	}
}
