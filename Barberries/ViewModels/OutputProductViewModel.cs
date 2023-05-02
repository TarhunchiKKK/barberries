using Barberries.Models;

namespace Barberries.ViewModels {
	public class OutputProductViewModel {
		public Product? Product { get; set; }
		public bool IsAdmin { get; set; }
		public User? User { get; set; }
		public OutputProductViewModel() { }
	}
}
