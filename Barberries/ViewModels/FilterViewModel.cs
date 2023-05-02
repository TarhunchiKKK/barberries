namespace Barberries.ViewModels {
	public class FilterViewModel {
		public int CountFrom { get; set; }
		public int CountTo { get; set; }
		public double CostFrom { get; set; }
		public double CostTo { get; set; }
		public FilterViewModel() {
			SetDefault();
		}
		public FilterViewModel(int countFrom, int countTo, double costFrom, double costTo) {
			CountFrom = countFrom;
			CountTo = countTo;
			CostFrom = costFrom;
			CostTo = costTo;
		}
		public void SetDefault() {
			CountFrom = 0;
			CountTo = 1000000;
			CostFrom = 0.0;
			CostTo = 1000000.0;
		}
		public bool IsDefault => CountFrom == 0 && CountTo == 1000000 && CostFrom == 0.0 && CostTo == 1000000.0;
	}
}
