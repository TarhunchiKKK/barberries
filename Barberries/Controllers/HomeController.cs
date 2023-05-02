using Barberries.Database;
using Barberries.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Barberries.Controllers {
	public class HomeController : Controller {
		ApplicationContext db;
		public static string AdminPassword = "BlAcKbErRiEs";

		//инициализация бд и словаря пользователь-пароль
		public HomeController(ApplicationContext context) {
			db = context;
		}

		//Начальная стрница(выбор способа входа)
		public IActionResult HomePage() {
			return View();
		}

		//ввод пароля
		public IActionResult LogIn(bool isAdmin) {
			ViewBag.IsAdmin = isAdmin;
			return View();
		}

		//авторизация пользователя
		public IActionResult Authorize(LogPair logPair) {
			if (logPair.NickName == "Admin") {
				if (logPair.Password != AdminPassword)
					return Unauthorized("Вы не являетесь администратором");
				else {
					User admin = new User { NickName = "Admin", Password = AdminPassword };
					return RedirectToAction("HomePage", "Admin", new { admin });
				}
			}
			else {
				User? user = db.Users.FirstOrDefault(u => u.Name == logPair.NickName, null); 
				if(user is null) return Unauthorized("Неверное имя");
				else {
					if(user.Password != logPair.Password) return Unauthorized("Неверный пароль");
					else return RedirectToAction("HomePage", "User", new { user });
				}
			}
		}

		//переход на страницу регистрации
		public IActionResult Registration() {
			return View();
		}

		//проверка на существование пользователя
		[AcceptVerbs("Get", "Post")]
		public IActionResult CheckUser(string nickName, string password) {
			foreach (User user in db.Users.ToList()) {
				if (user.NickName == nickName || user.Password == password) return Json(false);
			}
			return Json(true);
		}
	}

	public class LogPair {
		[Required(ErrorMessage = "Введите имя")]
		[StringLength(20, MinimumLength = 5, ErrorMessage = "Имя должно содержать от 5 до 20 символов")]
		public string NickName { get; set; } = null!;

		[Required(ErrorMessage = "Введите пароль")]
		[StringLength(30, MinimumLength = 10, ErrorMessage = "Пароль должен содержать от 5 до 20 символов")]
		public string Password { get; set; } = null!;
	}
}