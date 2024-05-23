
using stock_control_api.DataBase.Repositories;
using stock_control_api.DTOs;
using stock_control_api.Entities;

namespace stock_control_api.Services
{
	public class ProductService
	{
		private readonly ProductRepository repository;

		public ProductService(ProductRepository repository)
		{
			this.repository = repository;
		}

		internal async Task Create(ProductCreateDTO product)
		{
			var newProduct = new Product()
			{
				Id = Guid.NewGuid(),
				Name = product.Name,
				Code = product.Code,
				GroupId = product.GroupId,
				SupplierId = product.SupplierId,
				CategoryId = product.CategoryId,
				NrClient = product.NrClient,
				Observation = product.Observation,
				Status = Enums.ProductStatusEnum.Available
			};
			await repository.AddProduct(newProduct);
			await repository.SaveChanges();
		}

		internal async Task<List<ProductDTO>> GetAll()
		{
			var categories = await repository.GetAll();
			return categories.Select(x => new ProductDTO(
					x.Id,
					x.Name,
					x.Code,
					x.GroupId,
					x.SupplierId,
					x.CategoryId,
					x.NrClient,
					x.Observation,
					x.Status
				)).ToList();
		}

		internal async Task Remove(Guid productId)
		{
			var productFinded = await repository.GetById(productId);

			if (productFinded == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar o produto");
			}

			repository.Remove(productFinded);

			await repository.SaveChanges();
		}

		internal async Task Update(Guid productId, ProductUpdateDTO product)
		{
			var productFinded = await repository.GetById(productId);

			if (productFinded == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar o produto");
			}

			productFinded.Name = product.Name;
			productFinded.Code = product.Code;
			productFinded.GroupId = product.GroupId;
			productFinded.SupplierId = product.SupplierId;
			productFinded.CategoryId = product.CategoryId;
			productFinded.NrClient = product.NrClient;
			productFinded.Observation = product.Observation;
			productFinded.Status = product.Status;

			await repository.SaveChanges();
		}
	}
}