using Barberries.Attributes;
using Barberries.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Barberries.Models {
	public class User : IValidatableObject {
		public int Id { get; set; }

		[Required(ErrorMessage = "Введите фамилию")]
		[StringLength(20, MinimumLength = 3, ErrorMessage = "Длина фамилии должна быть от 3 до 20 символов")]
		public string Surname { get; set; } = null!;

		[Required(ErrorMessage = "Введите имя")]
		[StringLength(20, MinimumLength = 2, ErrorMessage = "Длина имени должна быть от 2 до 20 символов")]
		public string Name { get; set; } = null!;

		[Required(ErrorMessage = "Введите возраст")]
		[NumberRange<int>(MinValue = 12, MaxValue = 110)]
		public int Age { get; set; }

		[Required(ErrorMessage = "Придумайте себе никнейм")]
		[StringLength(20, MinimumLength = 5, ErrorMessage = "Никнейм должен содержать от 5 до 20 символов")]
		[Remote(action: "CheckUser", controller: "Home", AdditionalFields = "Password", ErrorMessage = "Пользователь с таким именем уже существует")]
		public string? NickName { get; set; }

		[Required(ErrorMessage = "Введите номер телефона")]
		[RegularExpression("^+375 [1-9]{2} [0-9]{3} [0-9]{2} [0-9]{2}", ErrorMessage = "Некорректный номер телефона")]
		public string? PhoneNumber { get; set; }

		[Required(ErrorMessage = "Введите пароль")]
		[StringLength(30, MinimumLength = 10, ErrorMessage = "Пароль должен содержать от 10 до 30 символов")]
		[Remote(action: "CheckUser", controller: "Home", AdditionalFields = "NickName", ErrorMessage = "Пользователь с таким именем уже существует")]
		public string? Password { get; set; }

		[BindNever]
		public Currency Currency { get; set; } = Currency.BYN;

		[BindNever]
		public List<Product> FavouriteProducts { get; set; } = new();

		public Dictionary<Product, DateTime> AcquiredProducts = new();

		public bool IsAdmin => Name == "Admin";

		List<ValidationResult> errors = new List<ValidationResult>();
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
			string? substring = PhoneNumber?.Substring(5, 2);
			switch (substring) {
				case "17": case "29": case "33": case "44": break;
				default: errors.Add(new ValidationResult("Неверный мобильный оператор")); break;
			}
			return errors;
		}

		public static bool operator ==(User user1, User user2) {
			return user1.Name == user2.Name;
		}

		public static bool operator !=(User user1, User user2) {
			return user1 != user2;
		}

		public static bool operator ==(User user, string name) {
			return user.Name == name;
		}

		public static bool operator !=(User user, string name) {
			return user.Name != name;
		}
	}
}
