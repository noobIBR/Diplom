using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Server2
{
    public class Startup
    {
        // Конструктор, в котором принимается IConfiguration
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Метод ConfigureServices для настройки сервисов приложения
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
            services.AddControllers();
            // Добавление контекста данных в сервисы приложения
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            // Другие сервисы и конфигурации могут быть добавлены здесь
        }

        // Этот метод вызывается для настройки конвейера запроса HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAnyOrigin");
            // Конфигурация приложения для различных сред выполнения
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Настройка обработки ошибок в производственной среде
                app.UseExceptionHandler("/Home/Error");
                // Настройка обработки кодов состояния HTTP в производственной среде
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            // Прочие настройки middleware

            app.UseRouting();

            app.UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    context.Response.Redirect("/index.html");
                    await Task.CompletedTask;
                });
            });
        }
    }
}