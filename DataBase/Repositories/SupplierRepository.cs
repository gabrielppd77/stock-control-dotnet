using Microsoft.EntityFrameworkCore;
using stock_control_api.Entities;

namespace stock_control_api.DataBase.Repositories
{
	public class SupplierRepository
	{
		private readonly PgContext context;

		public SupplierRepository(PgContext context)
		{
			this.context = context;
		}

		internal async Task<int> GetLastCode()
		{
			return await context.Supplier
				.OrderBy(x => x.Code)
				.Select(x => x.Code)
				.LastOrDefaultAsync();
		}

		internal async Task AddSupplier(Supplier newSupplier)
		{
			await context.Supplier.AddAsync(newSupplier);
		}

		internal async Task<List<Supplier>> GetAll()
		{
			return await context.Supplier.AsNoTracking().OrderBy(x => x.Code).ToListAsync();
		}

		internal async Task<Supplier?> GetById(Guid supplierId)
		{
			return await context.Supplier.FirstOrDefaultAsync(x => x.Id == supplierId);
		}

		internal void Remove(Supplier supplierFinded)
		{
			context.Supplier.Remove(supplierFinded);
		}

		internal async Task SaveChanges()
		{
			await context.SaveChangesAsync();
		}
	}
}