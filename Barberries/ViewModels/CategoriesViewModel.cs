using Barberries.Models;

namespace Barberries.ViewModels {
	public class CategoriesViewModel {
		public IEnumerable<Category> Categories { get; set; }
		public Category? ParentCategory { get; set; }
		public CategoriesViewModel(IEnumerable<Category> categories, Category? category = null) {
			Categories = categories;
			ParentCategory = (category == null) ? new Category { Name = "Категории" } : category;
		}
	}
}
