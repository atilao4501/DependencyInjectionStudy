using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using PersonalBlog.Interface;
using PersonalBlog.Services;

var builder = WebApplication.CreateBuilder(args);

var credentials = new BasicAWSCredentials(builder.Configuration["AWS:Key"], builder.Configuration["AWS:SecretKey"]);

var client = new AmazonDynamoDBClient(credentials, Amazon.RegionEndpoint.USEast1);
var context = new DynamoDBContext(client);

builder.Services.AddSingleton<IDynamoDBContext>(context);
builder.Services.AddScoped<IDataService, DynamoDbDataService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
