using Barberries.Attributes;
using Barberries.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml.Linq;

namespace Barberries.Models {
	public class Product {
		public int Id { get; set; }
		public Category? Category { get; set; }
		public int CategoryId { get; set; }

		[Required(ErrorMessage = "Фотография товара должна быть приведена")]
		[RegularExpression("", ErrorMessage = "Ссылка на фотографию некорректна")]
		public string? Picture { get; set; }

		[Display(Name = "Название книги")]
		[Required(ErrorMessage = "Введите название книги")]
		/**/
		[TextLength(MaxLength = 50)]
		public string Name { get; set; } = null!;

		[Display(Name = "Цена книги")]
		[Required(ErrorMessage = "Введите цену книги")]
		[Range(0.1, 130, ErrorMessage = "Цена должна быть не более 130р.")]
		public double Cost { get; set; }

		[Display(Name = "Количество экземпляров")]
		[Required(ErrorMessage = "Введите количество экземпляров")]
		public int Count { get; set; }

		[Display(Name = "Описание книги")]
		[Required(ErrorMessage = "Приведите описание книги")]
		[TextLength(MaxLength = 1000, MinLength = 100)]
		public string? Description { get; set; }

		[BindNever]
		public Dictionary<string, string> Parameters { get; set; } = new();

		[BindNever]
		public Currency Currency { get; set; } = Currency.BYN;

		public bool IsHere { get => Count == 0; }

		public Product() {

		}

		public  bool Contains(string? str) {
			if (str == null) return true;
			return Name.Contains(str);
		}
	}
}
