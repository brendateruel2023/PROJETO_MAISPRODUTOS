using Microsoft.EntityFrameworkCore;
using MaisProdutos.Data;
using MaisProdutos.Repositorios;
using MaisProdutos.Repositorios.Interfaces;

namespace MaisProdutos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add MySQL support
            builder.Services.AddEntityFrameworkMySql()
                .AddDbContext<ProdutosDbContext>(
                    options => options.UseMySql(
                        builder.Configuration.GetConnectionString("DataBase"),
                        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DataBase"))
                    )
                );

            builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();

            // Add CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Enable CORS
            app.UseCors("AllowAllOrigins");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}