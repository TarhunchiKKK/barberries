﻿using Barberries.Models;

namespace Barberries.ViewModels {
	public class OutputProductsViewModel {
		public IEnumerable<Product> Products { get; }
		public PageViewModel PageViewModel { get; }
		public FilterViewModel FilterViewModel { get; }
		public SortViewModel SortViewModel { get; }

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

		public bool IsDefault => FilterViewModel.IsDefault && SortViewModel.IsDefault;
	}
}
