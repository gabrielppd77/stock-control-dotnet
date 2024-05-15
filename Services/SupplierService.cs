using stock_control_api.DataBase.Repositories;
using stock_control_api.DTOs;
using stock_control_api.Entities;

namespace stock_control_api.Services
{
	public class SupplierService
	{
		private readonly SupplierRepository repository;

		public SupplierService(SupplierRepository repository)
		{
			this.repository = repository;
		}

		internal async Task Create(SupplierCreateDTO supplier)
		{
			var newSupplier = new Supplier()
			{
				Id = Guid.NewGuid(),
				Name = supplier.name
			};
			await repository.AddSupplier(newSupplier);
			await repository.SaveChanges();
		}

		internal async Task<List<SupplierDTO>> GetAll()
		{
			var categories = await repository.GetAll();
			return categories.Select(x => new SupplierDTO(x.Id, x.Name)).ToList();
		}

		internal async Task Remove(Guid supplierId)
		{
			var supplierFinded = await repository.GetById(supplierId);

			if (supplierFinded == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar a categoria");
			}

			repository.Remove(supplierFinded);

			await repository.SaveChanges();
		}

		internal async Task Update(Guid supplierId, SupplierUpdateDTO supplier)
		{
			var supplierFinded = await repository.GetById(supplierId);

			if (supplierFinded == null)
			{
				throw new BadHttpRequestException("Não foi possível encontrar a categoria");
			}

			supplierFinded.Name = supplier.name;

			await repository.SaveChanges();
		}
	}
}