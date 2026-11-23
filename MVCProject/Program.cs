using MVCProject.MiddleWare;

namespace MVCProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //used to add built-in MVC Services inside Container
            //DI Container
            builder.Services.AddControllersWithViews();


            //used to add built-in Web API Services inside Container
            //builder.Services.AddControllers();

            //used to add built-in Razor Pages Services inside Container
            //builder.Services.AddRazorPages();

            var app = builder.Build();

            //Add Middelwares=>Function
            //custom middleware

            //app.Use(async(context,next)=>
            //{
            //    Console.WriteLine("Hello");
            //    await next.Invoke(context);
            //    Console.WriteLine("Bye bye");
            //} );
            app.UseMiddleware<RequestTimeMiddleware>();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
           // app.UseAuthentication();
            //app.UseAuthorization();
            //static file
            app.MapStaticAssets();

              //app.MapControllerRoute(
              //    name: "default2",
              //  pattern: "shop/{controller}/{action}"
              //  );

            //convention routing
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id:int?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
