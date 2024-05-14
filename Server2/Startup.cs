using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Server2
{
    public class Startup
    {
        // �����������, � ������� ����������� IConfiguration
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // ����� ConfigureServices ��� ��������� �������� ����������
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
            // ���������� ��������� ������ � ������� ����������
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            // ������ ������� � ������������ ����� ���� ��������� �����
        }

        // ���� ����� ���������� ��� ��������� ��������� ������� HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAnyOrigin");
            // ������������ ���������� ��� ��������� ���� ����������
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // ��������� ��������� ������ � ���������������� �����
                app.UseExceptionHandler("/Home/Error");
                // ��������� ��������� ����� ��������� HTTP � ���������������� �����
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            // ������ ��������� middleware

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