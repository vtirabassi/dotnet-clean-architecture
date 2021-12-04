using Application;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();

#region Configuration Databases
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();

builder.Services.AddInfrastructure(configuration);
#endregion

#region Configuration APIVersion
builder.Services.AddMvc()
    .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2)
    .AddFluentValidation();

builder.Services.AddApiVersioning(p =>
{
    p.DefaultApiVersion = new ApiVersion(1, 0);
    p.ReportApiVersions = true;
    p.AssumeDefaultVersionWhenUnspecified = true;
});

builder.Services.AddVersionedApiExplorer(p =>
{
    p.GroupNameFormat = "'v'VVV";
    p.SubstituteApiVersionInUrl = true;
});
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configuration Serilog
builder.Host.UseSerilog((ctx, conf) =>
    conf
    .WriteTo.Console());
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint($"/swagger/v1/swagger.json", $"v1");
    options.DocExpansion(DocExpansion.List);
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
