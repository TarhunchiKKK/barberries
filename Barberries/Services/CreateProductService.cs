using Barberries.Models;

namespace Barberries.Services {
	public interface ICreateProductService {
		public Product CreateProduct(Product product, string[] keys, string[] values);
		public void UpdateProduct(Product product, string[] keys, string[] values);
	}
	
	public class CreateProductService : ICreateProductService{
		public Product CreateProduct(Product product, string[] keys, string[] values) {
			Product newProduct = new Product {
				Id = product.Id,
				CategoryId = product.CategoryId,
				Category = product.Category,

				Name = product.Name,
				Count = product.Count,
				Cost = product.Cost,
				Description = product.Description,
				Picture = product.Picture
			};
			for (int i = 0; i < keys.Length && keys[i] != null; i++) {
				newProduct.Parameters.Add(keys[i], values[i]);
			}
			return newProduct;
		}

		public void UpdateProduct(Product product, string[] keys, string[] values) {
			product.Parameters.Clear();
			for (int i = 0; i < keys.Length && keys[i] != null; i++) {
				product.Parameters.Add(keys[i], values[i]);
			}
		}
	}
}
