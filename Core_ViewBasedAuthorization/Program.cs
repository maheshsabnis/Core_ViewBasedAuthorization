using Core_ViewBasedAuthorization.CustomHandler;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Registering the Handler


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(options =>
           {
               // Set the Login Path Explicitely
               options.Cookie.Name = "SampleCookieAuth";
               options.LoginPath = "/Account/Login";
           });
//Check the User's AUTHORIZATION
builder.Services.AddAuthorization(options =>
{
    // The Custom Policy for View Accessibility
    options.AddPolicy("ViewBasedAuthorizationDemo", policy =>
    {
        // The USer MUST be Adim
        policy.RequireRole("Admin");
        // MUST be 18years 
        policy.Requirements.Add(new AgeRequirement(18));
    });
});
// Custom Request Handler for AUTHORIZATION Check
builder.Services.AddSingleton<IAuthorizationHandler, AgeRequirementHandler>();



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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
