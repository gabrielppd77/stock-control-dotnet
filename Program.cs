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

builder.Services.AddScoped<PgContext>();

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<SupplierService>();

builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<SupplierRepository>();

var app = builder.Build();

app.MapControllers();
app.UseExceptionHandler();
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.Run();