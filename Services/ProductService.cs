
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
				Code = await repository.GetLastCode() + 1,
				Name = product.Name,
				GroupId = product.GroupId,
				NrClient = product.NrClient,
				Observation = product.Observation,
				Status = Enums.ProductStatusEnum.Available
			};
			await repository.AddProduct(newProduct);
			await repository.SaveChanges();
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
			productFinded.NrClient = product.NrClient;
			productFinded.Observation = product.Observation;
			productFinded.Status = product.Status;

			await repository.SaveChanges();
		}

		internal async Task MultiplyProduct(Guid productId, int quantity)
		{
			if (quantity > 10)
			{
				throw new BadHttpRequestException("Não foi possível multiplicar o produto, quantidade máxima de 10 atingida");
			}

			var product = await repository.GetById(productId);

			if (product == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar o produto");
			}

			var lastCode = await repository.GetLastCode();

			for (int i = 0; i < quantity; i++)
			{
				lastCode++;
				await repository.AddProduct(
					new Product()
					{
						Id = Guid.NewGuid(),
						Code = lastCode,
						Name = product.Name,
						GroupId = product.GroupId,
						Status = product.Status,
						NrClient = product.NrClient,
						Observation = product.Observation
					}
				);
			}

			await repository.SaveChanges();
		}
	}
}