using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using PhonePlanAPI.Data;
using PhonePlanAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers().AddOData(options => options.EnableQueryFeatures());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PlanTypeRepository>();
builder.Services.AddScoped<OperatorRepository>();
builder.Services.AddScoped<PhonePlanRepository>();
builder.Services.AddScoped<DDDRepository>();
builder.Services.AddScoped<PhonePlanService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();