namespace Client
{
    using AutoMapper;
    using Data;
    using Models;
    using Models.Dtos;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;

    public class Startup
    {
        public static void Main()
        {
            using (var context = new ShopContext())
            {
                //context.Database.Initialize(true);
                //Console.WriteLine("Database created!");

                //Task1
                //JsonImportUsers();
                //JsonImportProducts();
                //JsonImportCategories();

                //Task2
                //Query1ProductsInRange();
                //Query2SuccessfullySoldProducts();   
                //Query3CategoriesByProductsCount
                //Query4UsersAndProducts();
            }
        }

        private static void Query4UsersAndProducts()
        {
            using (var context = new ShopContext())
            {
                var usersAndProducts = context.Users
                                                    .Where(u => u.SoldProducts.Count > 0)
                                                    .Select(u => new
                                                    {
                                                        FirstName = u.FirstName,
                                                        LastName = u.LastName,
                                                        Age = u.Age,
                                                        SoldProducts = new
                                                        {
                                                            Count = u.SoldProducts.Count,
                                                            Products = u.SoldProducts.Select(p => new
                                                            {
                                                                Name = p.Name,
                                                                Price = p.Price
                                                            })
                                                        }
                                                    })
                                                    .OrderByDescending(p => p.SoldProducts.Count)
                                                    .ThenBy(u => u.LastName)
                                                    .ToList();

                var json = JsonConvert.SerializeObject(new
                {
                    UsersCount = usersAndProducts.Count,
                    Users = usersAndProducts
                }, Formatting.Indented);

                File.WriteAllText("../../../users-query4.json", json);
                Console.WriteLine(json);
            }
        }

        private static void Query3CategoriesByProductsCount()
        {
            using (var context = new ShopContext())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Category, CategoryDto>()
                            .ForMember(dto => dto.ProductsCount, opt => opt.MapFrom(cat => cat.Products.Count()))
                            .ForMember(dto => dto.AveragePrice, opt => opt.MapFrom(cat => Math.Round(cat.Products.Average(p => p.Price), 6)))
                            .ForMember(dto => dto.TotalMoney, opt => opt.MapFrom(cat => Math.Round(cat.Products.Sum(p => p.Price), 2)));
                });

                var resultList = new List<CategoryDto>();
                var categoriesByProducts = context.Categories
                                                            .Where(c => c.Products.Count > 0)
                                                            .OrderBy(c => c.Name)
                                                            .ToList();

                foreach (var cat in categoriesByProducts)
                {
                    CategoryDto dto = Mapper.Map<CategoryDto>(cat);
                    resultList.Add(dto);
                }

                var json = JsonConvert.SerializeObject(resultList, Formatting.Indented);
                Console.WriteLine(json);
            }   
        }

        private static void Query2SuccessfullySoldProducts()
        {
            using (var context = new ShopContext())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<User, UserSoldProductsDto>();
                    cfg.CreateMap<Product, SoldProductDto>().ForMember(dto => dto.FirstName, opt => opt.MapFrom(p => p.Buyer.FirstName))
                                                            .ForMember(dto => dto.LastName, opt => opt.MapFrom(p => p.Buyer.LastName));
                });

                var resultList = new List<UserSoldProductsDto>();
                var soldProducts = context.Users
                                                .Where(u => u.SoldProducts.All(p => p.Buyer != null) && u.SoldProducts.Count > 0)
                                                .OrderBy(u => u.LastName)
                                                .ThenBy(u => u.FirstName)
                                                .ToList();

                foreach (var result in soldProducts)
                {
                    UserSoldProductsDto dto = Mapper.Map<UserSoldProductsDto>(result);
                    resultList.Add(dto);
                }

                var json = JsonConvert.SerializeObject(resultList, Formatting.Indented);
                Console.WriteLine(json);
            }  
        }

        private static void Query1ProductsInRange()
        {
            using (var context = new ShopContext())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Product, ProductDto>().ForMember(dto => dto.Seller, opt => opt.MapFrom(user => user.Seller.FullName.Trim()));
                });

                var listProductDto = new List<ProductDto>();

                //only 1 single query
                var allProduct = context.Products
                                                .Where(p => p.Price >= 500 && p.Price <= 1000)
                                                .OrderBy(p => p.Price)
                                                .ToList();

                foreach (var product in allProduct)
                {
                    ProductDto dto = Mapper.Map<ProductDto>(product);
                    listProductDto.Add(dto);
                }

                var json = JsonConvert.SerializeObject(listProductDto, Formatting.Indented);
                Console.WriteLine(json);
            } 
        }

        private static void JsonImportCategories()
        {
            using (var context = new ShopContext())
            {
                List<Category> categories;

                //it can be done with file read all text
                using (StreamReader reader = File.OpenText(@"../../../categories.json"))
                {
                    string jsonResult = reader.ReadToEnd();
                    categories = JsonConvert.DeserializeObject<List<Category>>(jsonResult);
                }

                foreach (var category in categories)
                {
                    context.Categories.Add(category);
                }

                context.SaveChanges();

                var products = context.Products.ToList();

                int maxCount = context.Categories.Count();
                Random rnd = new Random();

                foreach (var product in products)
                {
                    int randomCat = rnd.Next(1, maxCount);
                    var category = context.Categories.First(id => id.Id == randomCat);
                    product.Categories.Add(category);
                }

                context.SaveChanges();

                Console.WriteLine("Successfuly added categories!");
            }
        }

        private static void JsonImportUsers()
        {
            using (var context = new ShopContext())
            {
                List<User> users;

                using (StreamReader reader = File.OpenText(@"../../../users.json"))
                {
                    string jsonResult = reader.ReadToEnd();
                    users = JsonConvert.DeserializeObject<List<User>>(jsonResult);
                }

                context.Users.AddRange(users);

                context.SaveChanges();
                Console.WriteLine("Successfuly added users!");
            }
        }

        private static void JsonImportProducts()
        {
            using (var context = new ShopContext())
            {
                List<Product> products;

                using (StreamReader reader = File.OpenText(@"../../../products.json"))
                {
                    string jsonResult = reader.ReadToEnd();
                    products = JsonConvert.DeserializeObject<List<Product>>(jsonResult);
                }

                int countUsers = context.Users.Count();
                Random rnd = new Random();

                int counter = 0;
                foreach (var product in products)
                {
                    int rNumber = rnd.Next(1, countUsers);

                    if (counter % 2 == 0)
                    {
                        product.BuyerId = rNumber;
                    }

                    rNumber = rnd.Next(1, countUsers);
                    product.SellerId = rNumber;
                    
                    context.Products.Add(product);
                    counter++;
                }

                context.SaveChanges();
                Console.WriteLine("Successfuly added products!");
            }
        }
    }
}
