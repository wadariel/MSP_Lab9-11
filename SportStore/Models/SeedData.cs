using Microsoft.EntityFrameworkCore;

namespace SportStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<StoreDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Каяк",
                        Description = "Лодка для одного человека",
                        Category = "Водный спорт",
                        Price = 275
                    },
                    new Product
                    {
                        Name = "Спортивный рюкзак",
                        Description = "Рюкзак для спортинвентаря",
                        Category = "Рюкзаки и сумки",
                        Price = 20
                    },
                    new Product
                    {
                        Name = "Футбольный мяч",
                        Description = "Установленный FIFA размер и вес",
                        Category = "Футбол",
                        Price = 15
                    },
                    new Product
                    {
                        Name = "Куртка зимняя Pum",
                        Description = "Зимняя одежда",
                        Category = "Верхняя одежда",
                        Price = 35
                    },
                    new Product
                    {
                        Name = "Волейбольный мяч",
                        Description = "Стандарт",
                        Category = "Волейбол",
                        Price = 11
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
