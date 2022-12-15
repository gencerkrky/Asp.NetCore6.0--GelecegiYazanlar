var builder = WebApplication.CreateBuilder(args);

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

// use methodu her istek geldinde �al���r
#region Use ve Run Cal�sma yap�s�

////1. middleware

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Before 1. middleware\n");

//    await next();

//    //gercek projelerde Microsoft �nerisi response dokunmamak
//    await context.Response.WriteAsync("After 1. middleware\n");

//});

////2. middleware
////logic - next() - more logic
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Before 2. middleware\n");

//    await next();

//    await context.Response.WriteAsync("After 2. middleware\n");

//});

//// Sonland�r�c� middleware Run methoduyla �al���r
//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Terminal 3. middleware\n");
//});

#endregion

// gelen request yakalamak i�in kullan�yoruz
#region Map Cal�sma yap�s�
//app.Map("/ornek", app =>
//{
//app.Use(async (context, next) =>
//{
//    await context.Request.Body
//    await context.Request.QueryString
//    await context.Request.RouteValues
//    await context.Request.


//    await next();



//    //app.Run(async context =>
//    //{
//    //    context.Response.WriteAsync("Ornek url'i icin middleware");
//    //});
//}); 
#endregion

#region MapWhep Cal�sma yap�s�
//app.MapWhen(context => context.Request.Query.ContainsKey("name"), app =>
//{

//    //(localhost:****/Home/Index?name=*****) 'te �al���r
//    //1. middleware

//    app.Use(async (context, next) =>
//    {
//        await context.Response.WriteAsync("Before 1. middleware\n");

//        await next();

//        await context.Response.WriteAsync("After 1. middleware\n");

//    });

//    // Sonland�r�c� middleware Run methoduyla �al���r
//    app.Run(async context =>
//    {
//        await context.Response.WriteAsync("Terminal 2. middleware\n");
//    });

//}); 
#endregion



app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
