using Infra;
using stock_control_api.DataBase;
using stock_control_api.DataBase.Repositories;
using stock_control_api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAllOrigins",
		builder =>
		{
			builder.AllowAnyOrigin()
				   .AllowAnyMethod()
				   .AllowAnyHeader();
		});
});

builder.Services.AddScoped<PgContext>();

builder.Services.AddScoped<SupplierService>();
builder.Services.AddScoped<GroupService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<StockService>();

builder.Services.AddScoped<SupplierRepository>();
builder.Services.AddScoped<GroupRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<StockRepository>();

var app = builder.Build();

app.MapControllers();
app.UseExceptionHandler();
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	app.UseCors("AllowAllOrigins");
}

app.Run();