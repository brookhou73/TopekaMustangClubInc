using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

//This session control determins how long a browser session will idle
//This is meant to control and prevent multiple browser sessions open simultaneously
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "TimeoutSession";
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.Name = "BRATS.Session";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//ENABLE Serilog
builder.Host.UseSerilog((HostBuilderContext context,
    IServiceProvider services, LoggerConfiguration loggerConfiguration) =>
{
    loggerConfiguration
    .ReadFrom.Configuration(context.Configuration) //read configuration settings from built-in IConfiguration
    .ReadFrom.Services(services); //read out current app's services and make them available to serilog
});

Serilog.Log.Information("[PROGRAM] UseSerilog service started successfully.");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IEmailSender, EmailSender>();
//builder.Services.AddTransient<IEmailSender, EmailSender>();

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
//app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapRazorPages();


//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
//app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
