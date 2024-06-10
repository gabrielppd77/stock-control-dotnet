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

var CorsPolicy = "CorsPolicy";

var allowedOrigins = builder.Configuration.GetSection("CorsSettings:AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
	options.AddPolicy(CorsPolicy,
		  builder => builder.WithOrigins(allowedOrigins ?? [])
							.AllowAnyMethod()
							.AllowAnyHeader()
							.AllowCredentials());
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

app.UseCors(CorsPolicy);
app.MapControllers();
app.UseExceptionHandler();
app.UseHttpsRedirection();

app.MapGet("/", () => "Server is Living!");

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.Run();