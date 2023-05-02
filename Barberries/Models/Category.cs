namespace Barberries.Models {
	public class Category {
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Picture { get; set; } = null!;
		public bool IsSubcategory => ParentId != null;
		public bool IsCategory => ParentId == null;
		public List<Product> Products { get; set; } = new();

		public int? ParentId { get; set; }
		public Category? Parent { get; set; }
		public List<Category> Subcategories { get; set; } = new();
	}
}
