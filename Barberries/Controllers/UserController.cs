using Barberries.Database;
using Barberries.Models;
using Barberries.Services;
using Barberries.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Barberries.Controllers {
	public class UserController : Controller {
		const int MIN_COUNT = 0;
		const int MAX_COUNT = 1000000;
		const double MIN_COST = 0.0;
		const double MAX_COST = 1000000.0;


		ApplicationContext db;

		ICurrencyService currencyService;

		public User CurrentUser { get; set; } = null!;
		public Category? CurrentCategory { get; set; }
		public IEnumerable<Product>? CurrentProducts { get; set; }
		public OutputProductsViewModel ViewModel { get; set; } = null!;


		// получение категорий
		public IActionResult GetMainCategories(User user) {
			CurrentUser = user;
			IEnumerable<Category> categories = db.Categories.Where(c => c.Id < 6);
			CategoriesViewModel viewModel = new CategoriesViewModel(categories);
			return View("~Views/User/GetCategories", viewModel);
		}

		public IActionResult GetSubcategories(int categoryId) {
			CurrentCategory = db.Categories.FirstOrDefault(c => c.Id == categoryId);
			if(CurrentCategory != null) {
				IEnumerable<Category> categories = CurrentCategory.Subcategories;
				if (categories.Any()) {
					CategoriesViewModel viewModel = new CategoriesViewModel(categories, CurrentCategory);
					return View("~Views/User/GetCategories", viewModel);
				}
			}
			return NotFound("Категория не найдена");
		}

		// получение продуктов категории
		public async Task<IActionResult> GetCategoryProducts(int categoryId, int page = 1) {
			IQueryable<Product> products = db.Products.Include(p => p.Category).Where(p => p.CategoryId == categoryId);
			int pageSize = 6;
			int productCount = await products.CountAsync();
			IEnumerable<Product> viewProducts  = await products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
			CurrentCategory = db.Categories.FirstOrDefault(c => c.Id == categoryId);
			OutputProductsViewModel viewModel = new OutputProductsViewModel(
					viewProducts,
					new PageViewModel(productCount, page, pageSize),
					new FilterViewModel(),
					new SortViewModel()
				);
			return View("~/Views/User/OutputProducts", CurrentProducts);
		}

		// поиск продуктов по имени
		public IActionResult FindProducts(string name) {
			CurrentProducts = db.Products.Include(p =>p.Category).Where(p=>p.CategoryId == CurrentCategory!.Id && p.Name.Contains(name));
			
			return View("~Views/User/OutputProducts", CurrentProducts);
		}

		// применить сортировку и фильтрацию 
		public async Task<IActionResult> UseSortAndFilters(int page = 1, int countFrom = MIN_COUNT, 
			int countTo = MAX_COUNT, double costFrom = MIN_COST, double costTo = MAX_COST,
			SortState sortState = SortState.NameAscending) {
			
			int pageSize = 6;

			IQueryable<Product> products = db.Products.Include(p => p.Category);
			if(countFrom != MIN_COUNT && countTo != MAX_COUNT) {
				products = products.Where(p => p.Count >= countFrom && p.Count <= countTo);
			}
			if(costFrom != MIN_COST && costTo != MIN_COST) {
				products = products.Where(p => p.Cost >= costFrom &&  p.Cost <= costTo);
			}

			switch(sortState) {					
				case SortState.NameDescending:
					products = products.OrderByDescending(p => p.Name);
					break;
				case SortState.CountAscending:
					products = products.OrderBy(p => p.Count);
					break;
				case SortState.CountDescending:
					products = products.OrderByDescending(p => p.Count);
					break;
				case SortState.CostAscending:
					products = products.OrderBy(p => p.Cost);
					break;
				case SortState.CostDescending:
					products = products.OrderByDescending(p => p.Cost);
					break;
				default:
					products = products.OrderBy(p => p.Name);
					break;
			}

			int productCount = await products.CountAsync();
			IEnumerable<Product> products1 = await products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

			OutputProductsViewModel viewModel = new OutputProductsViewModel(
				products1,
				new PageViewModel(productCount, page, pageSize),
				new FilterViewModel(countFrom, countTo, costFrom, costTo),
				new SortViewModel(sortState)
				);
			return View("~Views/User/OutputProducts", viewModel);
		}
	}
}
