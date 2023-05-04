using Barberries.Models;

namespace Barberries.ViewModels {
	public class OutputProductsViewModel {
		public IEnumerable<Product> Products { get; set; }
		public Category Category { get; set; } = null!;

		public string? Name { get; set; } = null;
		public PageViewModel PageViewModel { get; set; }
		public FilterViewModel FilterViewModel { get; set; }
		public SortViewModel SortViewModel { get; set; }

		public User User { get; set; } = null!;
		public bool IsAdmin => User.Name == "Admin";

		public OutputProductsViewModel(IEnumerable<Product> products, PageViewModel pageViewModel,
			FilterViewModel filterViewModel, SortViewModel sortViewModel) { 
			Products = products;
			PageViewModel = pageViewModel;
			FilterViewModel = filterViewModel;
			SortViewModel = sortViewModel;
		}

		public void SetDefault() {
			FilterViewModel.SetDefault();
			SortViewModel.SetDefault();
		}

		public bool IsDefault => FilterViewModel.IsDefault && Name == null;
	}
}
