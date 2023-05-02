namespace Barberries.ViewModels {
	public enum SortState {
		NameAscending,
		NameDescending,
		CountAscending,
		CountDescending,
		CostAscending,
		CostDescending
	}

	public class SortViewModel {
		public SortState NameSort { get; set; }
		public SortState CountSort { get; set; }
		public SortState CostSort { get; set; }
		public SortState CurrentSort { get; set; }

		public SortViewModel() {
			SetDefault();
		}
		public SortViewModel(SortState sortState) {
			NameSort = (sortState == SortState.NameAscending) ? SortState.NameDescending : SortState.NameAscending;
			CountSort = (sortState == SortState.CountAscending) ? SortState.CountDescending : SortState.CountAscending;
			CostSort = (sortState == SortState.CostAscending) ? SortState.CostDescending : SortState.CostAscending;
			CurrentSort = sortState;
		}

		public void SetDefault() {
			CurrentSort = SortState.NameAscending;
		}

		public bool IsDefault => CurrentSort == SortState.NameAscending;
	}
}
