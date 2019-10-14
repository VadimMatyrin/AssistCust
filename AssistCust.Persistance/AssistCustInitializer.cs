using AssistCust.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssistCust.Persistance
{
    public class AssistCustInitializer
    {
        private readonly List<string> _userIds = new List<string>();
        private readonly List<int> _companiesIds = new List<int>();
        private readonly List<int> _shopIds = new List<int>();
        private readonly List<int> _productIds = new List<int>();

        public static void Initialize(AssistCustDbContext context)
        {
            var initializer = new AssistCustInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(AssistCustDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return; // Db has been seeded
            }

            SeedUsers(context);
            SeedCompanies(context);
            SeedShops(context);
            SeedProducts(context);
        }

        public void SeedUsers(AssistCustDbContext context)
        {
            var users = new[]
            {
                new User { FirstName = "Vadym", LastName = "Matyrin", PhoneNumber = "+380999999999", UserName = "vadym_matyrin"},
                new User { FirstName = "Dmytro", LastName = "Striha", PhoneNumber = "+380503003030", UserName = "dmitry_striha"},
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            _userIds.AddRange(users.Select(u => u.Id));
        }

        public void SeedCompanies(AssistCustDbContext context)
        {
            var companies = new[]
            {
                new Company { Name = "Adidas", UserId = _userIds[0], Country = "ua" },
                new Company { Name = "Reebok", UserId = _userIds[1], Country = "ua" }
            };

            context.Companies.AddRange(companies);
            context.SaveChanges();

            _companiesIds.AddRange(companies.Select(c => c.Id));
        }

        public void SeedShops(AssistCustDbContext context)
        {
            var shops = new[]
            {
                new CompanyShop { CompanyId = _companiesIds[0], ShopName = "Adidas Kiev", AddressField1 = "Kiev", AddressField2 = "Gagarina street",City = "Kiev", State = "Kievska oblast" },
                new CompanyShop { CompanyId = _companiesIds[1], ShopName = "Adidas Kharkiv", AddressField1 = "Kharkiv", AddressField2 = "Gagarina street",City = "Kharkiv", State = "Kharkivska oblast" }
            };

            context.CompanyShops.AddRange(shops);
            context.SaveChanges();

            _shopIds.AddRange(shops.Select(s => s.Id));
        }

        public void SeedProducts(AssistCustDbContext context)
        {
            var products = new[]
            {
                new Product { CompanyId = _companiesIds[0], Description = "Black, size 39", Name = "OZWEEGO SHOES" },
                new Product { CompanyId = _companiesIds[0], Description = "White, size 41", Name = "3MC VULC SHOES" },
                new Product { CompanyId = _companiesIds[1], Description = "Blue, size 42", Name = "SUPERSTAR SHOES" },
                new Product { CompanyId = _companiesIds[1], Description = "Green, size 43", Name = "BOX HOG 3 SHOES" }
            };

            context.Products.AddRange(products);
            context.SaveChanges();

            _productIds.AddRange(products.Select(p => p.Id));
        }
    }
}
