using Book.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("con2")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
//builder.Services.AddDbContext<AppDbContext>(
//    options => options.UseSqlServer(connectionString));
//builder.Services.AddIdentity<AppUser, IdentityRole>(
//    options =>
//    {
//        options.Password.RequiredUniqueChars = 0;
//        options.Password.RequireUppercase = false;
//        options.Password.RequiredLength = 8;
//        options.Password.RequireNonAlphanumeric = false;
//        options.Password.RequireLowercase = false;
//    })
//    .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();



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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LR}/{action=Register}/{id?}");

app.Run();
