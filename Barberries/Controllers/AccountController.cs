using Barberries.Database;
using Barberries.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Barberries.Controllers {
	public class AccountController : Controller{
		ApplicationContext db = null!;

		public User CurrentUser { get; set; } = null!;

		public AccountController(User user) {
			CurrentUser = user;
		}

		public IActionResult HomePage() {
			return View(CurrentUser);
		}

		[HttpGet]
		public IActionResult EditUser() {
			return View(CurrentUser);
		}

		[HttpPost]
		public async Task<IActionResult> EditUser(User user) {
			CurrentUser = user;
			db.Users.Update(user);
			await db.SaveChangesAsync();
			return RedirectToAction("HomePage");
		}

		public IActionResult OutputFavouriteProducts() {
			return View(CurrentUser.FavouriteProducts);
		}
		
		public IActionResult OutputAcquiredProducts() {
			return View(CurrentUser.AcquiredProducts);
		}
	}
}
