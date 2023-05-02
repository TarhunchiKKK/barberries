using Barberries.Models;

namespace Barberries.Services {
	public enum Currency {
		RUB = 1,
		BYN = 28,
		USD = 81,
		EUR = 89
	}

	public interface ICurrencyService {
		public void Transfer(Product product, Currency currency);
		public void Transfer(IEnumerable<Product> products, Currency currency);
	}

	public class CurrencyService : ICurrencyService{
		public static Dictionary<Currency, double> courses = new Dictionary<Currency, double>() {
			{ Currency.BYN, 1 },
			{ Currency.RUB, 27.78 },
			{ Currency.USD,  0.34 },
			{ Currency.EUR, 0.31 }
		};

		public void Transfer(Product product, Currency currency = Currency.BYN) {
			product.Cost = product.Cost * courses[product.Currency] / courses[currency];
			product.Currency = currency;
		}

		public void Transfer(IEnumerable<Product> products, Currency currency = Currency.BYN) {
			foreach(Product product in products) {
				product.Cost = product.Cost * courses[product.Currency] / courses[currency];
				product.Currency = currency;
			}
		}
	}
}
