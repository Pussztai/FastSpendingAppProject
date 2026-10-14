
using FastSpendingApp.Contracts;
using FastSpendingApp.Data;
using FastSpendingApp.Services;
using Microsoft.EntityFrameworkCore;

namespace FastSpendingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("FastSpendingDbConnectionString");
            builder.Services.AddDbContext<FastSpendingDbContext>(options => options.UseNpgsql(connectionString));
            // Add services to the container.
            builder.Services.AddScoped<IExpenseService, ExpenseService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Frontend", policy =>
                {
                    policy.WithOrigins("http://127.0.0.1:5500")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            //app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.UseCors("Frontend");

            app.MapControllers();

            app.Run();
        }
    }
}
