
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Repositories.Models
{
    public static class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {


            using (var context = new InvoiceContext(
                serviceProvider.GetRequiredService<DbContextOptions<InvoiceContext>>()))
            {


                // Perform database delete and create
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                // Look for any Company.
                if (context.Categorys.Any())
                {
                    return; // DB has been seeded
                }

                #region Lägg till några dummy slumpmässiga företag 

                var company = new Company[]
                {
                    new Company
                    {
                        CompanyName = "Company 01",
                        Address = "Övre långvinkelsgatan 1",
                        City = "Helsingborg",
                        Region = "Skåne",
                        Country = "Sverige",
                        PostCode = "25435",
                        Phone = "00490101010101",
                        Email = "company01@company.se",
                        Website = "www.company01.se"
                    },
                    new Company
                    {
                        CompanyName = "Company 02",
                        Address = "Fredriksdalsplatsen 2",
                        City = "Helsingborg",
                        Region = "Skåne",
                        Country = "Sverige",
                        PostCode = "25435",
                        Phone = "00492211221122",
                        Email = "company02@company.se",
                        Website = "www.company02.se"
                    },
                };
                foreach (Company s in company)
                {
                    context.Companys.Add(s);
                }
                context.SaveChanges();

                #endregion

                #region Lägg till några dummy slumpmässiga Kund
       
                var customer = new Customer[]
                {
                    new Customer
                    {
                        FirstMidName = "Carson",
                        LastName = "Alexander",
                        ContactPerson = "Alexander",
                        ContactTitle = "Köpa",
                        Address = "Gatan 01",
                        City = "Helsingborg",
                        Region = "Skåne",
                        Country = "Sverige",
                        PostCode = "25435",
                        Phone = "00492211221122",
                        Phone2 = "00260101010101",
                        Fax = "00492211221122",
                        Email = "email@email.com",
                        Notes = "Här kan du Notera",
                        CompanyId = company.Single(c => c.CompanyName == "Company 01").CompanyId
                    },
                    new Customer
                    {
                        FirstMidName = "Meredith",
                        LastName = "Alonso",
                        ContactPerson = "Alonso",
                        ContactTitle = "Köpa",
                        Address = "Gatan 02",
                        City = "Helsingborg",
                        Region = "Skåne",
                        Country = "Sverige",
                        PostCode = "25435",
                        Phone = "00492211221122",
                        Phone2 = "00260101010101",
                        Fax = "00493232323201",
                        Email = "email@email.com",
                        Notes = "Här kan du Notera",
                        CompanyId = company.Single(c => c.CompanyName == "Company 01").CompanyId
                    },
                    new Customer
                    {
                        FirstMidName = "Arturo",
                        LastName = "Anand",
                        ContactPerson = "Anand",
                        ContactTitle = "Köpa",
                        Address = "Gatan 03",
                        City = "Helsingborg",
                        Region = "Skåne",
                        Country = "Sverige",
                        PostCode = "25435",
                        Phone = "00492211221122",
                        Phone2 = "00260101010101",
                        Fax = "00493232323201",
                        Email = "email@email.com",
                        Notes = "Här kan du Notera",
                        CompanyId = company.Single(c => c.CompanyName == "Company 01").CompanyId
                    },
                    new Customer
                    {
                        FirstMidName = "Gytis",
                        LastName = "Barzdukas",
                        ContactPerson = "Barzdukas",
                        ContactTitle = "Köpa",
                        Address = "Gatan 04",
                        City = "Helsingborg",
                        Region = "Skåne",
                        Country = "Sverige",
                        PostCode = "25435",
                        Phone = "00492211221122",
                        Phone2 = "00260101010101",
                        Fax = "00493232323201",
                        Email = "email@email.com",
                        Notes = "Här kan du Notera",
                        CompanyId = company.Single(c => c.CompanyName == "Company 01").CompanyId
                    },
                    new Customer
                    {
                        FirstMidName = "Yan",
                        LastName = "Li",
                        ContactPerson = "Li",
                        ContactTitle = "Köpa",
                        Address = "Gatan 05",
                        City = "Helsingborg",
                        Region = "Skåne",
                        Country = "Sverige",
                        PostCode = "25435",
                        Phone = "00492211221122",
                        Phone2 = "00260101010101",
                        Fax = "00493232323201",
                        Notes = "Här kan du Notera",
                        CompanyId = company.Single(c => c.CompanyName == "Company 01").CompanyId
                    },
                    new Customer
                    {
                        FirstMidName = "Peggy",
                        LastName = "Justice",
                        ContactPerson = "Justice",
                        ContactTitle = "Köpa",
                        Address = "Gatan 06",
                        City = "Helsingborg",
                        Region = "Skåne",
                        Country = "Sverige",
                        PostCode = "25435",
                        Phone = "00492211221122",
                        Phone2 = "00260101010101",
                        Fax = "00493232323201",
                        Email = "email@email.com",
                        Notes = "Här kan du Notera",
                        CompanyId = company.Single(c => c.CompanyName == "Company 01").CompanyId
                    },
                    new Customer
                    {
                        FirstMidName = "Laura",
                        LastName = "Norman",
                        ContactPerson = "Norman",
                        ContactTitle = "Köpa",
                        Address = "Gatan 07",
                        City = "Helsingborg",
                        Region = "Skåne",
                        Country = "Sverige",
                        PostCode = "25435",
                        Phone = "00492211221122",
                        Phone2 = "00260101010101",
                        Fax = "00493232323201",
                        Email = "email@email.com",
                        Notes = "Här kan du Notera",
                        CompanyId = company.Single(c => c.CompanyName == "Company 02").CompanyId
                    },
                    new Customer
                    {
                        FirstMidName = "Nino",
                        LastName = "Olivetto",
                        ContactPerson = "Olivetto",
                        ContactTitle = "Köpa",
                        Address = "Gatan 08",
                        City = "Helsingborg",
                        Region = "Skåne",
                        Country = "Sverige",
                        PostCode = "25435",
                        Phone = "00492211221122",
                        Phone2 = "00260101010101",
                        Fax = "00493232323201",
                        Email = "email@email.com",
                        Notes = "Här kan du Notera",
                        CompanyId = company.Single(c => c.CompanyName == "Company 02").CompanyId
                    }
                };
                foreach (Customer s in customer)
                {
                    context.Customers.Add(s);
                }
                context.SaveChanges();

                #endregion

                #region Kategori

                var category = new Category[]
                {
                    new Category
                    {
                        CategoryName = "Datorer & Tillbehör",
                        Description =
                            "På Elgiganten vill vi att du ska hitta rätt grej för just dig. Därför har vi bett Futuremark att testa alla våra datorer med PCMark10. Det gör det lättare för dig att hitta den dator du behöver, oavsett om det är en kraftfull maskin för videoredigering, en enkel laptop för basbehov, eller en superlätt bärbar dator för resor. Med två enkla val kan du hitta en dator som är perfekt just för dig!"
                    },
                    new Category
                    {
                        CategoryName = "Ljud & Bild",
                        Description =
                            "På jakt efter en billig OLED-TV eller en portabel och trådlös högtalare? Under Ljud & Bild på Elgiganten hittar du ett brett utbud av Smart-TV, OLED-TV, Multiroom-högtalare, hemmabiosystem, Blu-ray-spelare, receivers, HiFi-högtalare, projektorer eller trådlösa högtalare med Bluetooth eller AirPlay till låga priser. Välj allt från t.ex. exklusiva 3D LED-TV med 100Hz och WiFi. Kolla även in Apple-TV och Chromecast om du vill skicka bild och ljud trådlöst från din smartphone eller surfplatta. Vi har välkända märken från Samsung, LG, Sony, Panasonic, Apple, Philips och Benq. Dessutom erbjuder vi installation av TV och bortforsling av den gamla. Handla online, beställ via telefon eller boka på nätet och hämta i något av våra varuhus."
                    },
                };
                foreach (Category s in category)
                {
                    context.Categorys.Add(s);
                }
                context.SaveChanges();

                #endregion

                #region produkt

                var product = new Product[]
                {
                    new Product
                    {
                        Article = "Dator",
                        SupplierName = "Elgiganten",
                        Price = 10000,
                        Vat = new Random().Next(10, 50),
                        AdvancePaymentTax = 15,
                        Notes = "Skriva in Notes",
                        CategoryId = category.Single(c => c.CategoryName == "Datorer & Tillbehör").CategoryId
                    },
                    new Product
                    {
                        Article = "TV",
                        SupplierName = "Elgiganten",
                        Price = 11000,
                        Vat = new Random().Next(10, 50),
                        AdvancePaymentTax = 15,
                        Notes = "Skriva in Notes",
                        CategoryId = category.Single(c => c.CategoryName == "Ljud & Bild").CategoryId
                    }
                };
                foreach (Product p in product)
                {
                    context.Products.Add(p);
                }
                context.SaveChanges();

                #endregion

                #region beställa

                var order = new Order[]
                {
                    new Order
                    {
                        CustomerId = customer.Single(c => c.LastName == "Alexander").CustomerId,
                        OrderDate = DateTime.Parse("2017-09-12"),
                        RequiredDate = DateTime.Parse("2017-09-16"),
                        AdvancePaymentTax = 15,
                        Paid = true,
                        OrderNumber = 1
                    },
                    new Order
                    {
                        CustomerId = customer.Single(c => c.LastName == "Alonso").CustomerId,
                        OrderDate = DateTime.Parse("2017-09-12"),
                        RequiredDate = DateTime.Parse("2017-09-16"),
                        AdvancePaymentTax = 15,
                        Paid = true,
                        OrderNumber = 2
                    },
                    new Order
                    {
                        CustomerId = customer.Single(c => c.LastName == "Anand").CustomerId,
                        OrderDate = DateTime.Parse("2017-09-01"),
                        RequiredDate = DateTime.Parse("2017-09-01"),
                        AdvancePaymentTax = 15,
                        Paid = true,
                        OrderNumber = 3
                    },
                    new Order
                    {
                        CustomerId = customer.Single(c => c.LastName == "Barzdukas").CustomerId,
                        OrderDate = DateTime.Parse("2017-09-04"),
                        RequiredDate = DateTime.Parse("2017-09-04"),
                        AdvancePaymentTax = 15,
                        Paid = true,
                        OrderNumber = 4
                    }
                };
                foreach (Order o in order)
                {
                    context.Orders.Add(o);
                }
                context.SaveChanges();

                #endregion

                #region Orderdetaljer

                var orderDetails = new OrderDetail[]
                {
                    new OrderDetail
                    {
                        OrderId = order.Single(o => o.CustomerOrders.LastName == "Alexander").OrderId,
                        ProductId = product.Single(p => p.Article == "Dator").ProductId,
                        Vat = new Random().Next(10, 50),
                        Quantity = 1,
                        Price = 10000,
                        Article = "Datorer & Tillbehör"
                    },
                    new OrderDetail
                    {
                        OrderId = order.Single(o => o.CustomerOrders.LastName == "Alonso").OrderId,
                        ProductId = product.Single(p => p.Article == "Dator").ProductId,
                        Vat = new Random().Next(10, 50),
                        Quantity = 1,
                        Price = 10000,
                        Article = "Datorer & Tillbehör"
                    },
                    new OrderDetail
                    {
                        OrderId = order.Single(o => o.CustomerOrders.LastName == "Anand").OrderId,
                        ProductId = product.Single(p => p.Article == "TV").ProductId,
                        Vat = new Random().Next(10, 50),
                        Quantity = 1,
                        Price = 11000,
                        Article = "Ljud & Bild"
                    },
                    new OrderDetail
                    {
                        OrderId = order.Single(o => o.CustomerOrders.LastName == "Barzdukas").OrderId,
                        ProductId = product.Single(p => p.Article == "TV").ProductId,
                        Vat = new Random().Next(10, 50),
                        Quantity = 1,
                        Price = 11000,
                        Article = "Ljud & Bild"
                    }
                };
                foreach (OrderDetail e in orderDetails)
                {
                    var enrollmentInDataBase = context.OrderDetails.SingleOrDefault(s =>
                        s.Orders.OrderId == e.OrderId &&
                        s.Products.ProductId == e.ProductId);
                    if (enrollmentInDataBase == null)
                    {
                        context.OrderDetails.Add(e);
                    }
                }
                context.SaveChanges();

                #endregion

            }


        }
    }
   

}
