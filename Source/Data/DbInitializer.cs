using ConfettiStore.Models;
using System;
using System.Linq;

namespace ConfettiStore.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            context.Database.EnsureCreated();

            // Look for any customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            //no data, seed
            if (!context.EventTypes.Any())
            {
                context.EventTypes.Add(new EventType() { EventName = "Birthday" });
                context.EventTypes.Add(new EventType() { EventName = "Anniversary" });
                context.EventTypes.Add(new EventType() { EventName = "Baby" });
                context.EventTypes.Add(new EventType() { EventName = "Wedding" });
                context.EventTypes.Add(new EventType() { EventName = "Corporate" });
                context.EventTypes.Add(new EventType() { EventName = "Graduation" });
                context.EventTypes.Add(new EventType() { EventName = "Other" });
            }
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category() { CategoryName = "Sports" });
                context.Categories.Add(new Category() { CategoryName = "Animals" });
                context.Categories.Add(new Category() { CategoryName = "Numbers" });
                context.Categories.Add(new Category() { CategoryName = "Music" });
                context.Categories.Add(new Category() { CategoryName = "Food" });
                context.Categories.Add(new Category() { CategoryName = "Retirement" });
                context.Categories.Add(new Category() { CategoryName = "Arts" });
                context.Categories.Add(new Category() { CategoryName = "College" });
                context.Categories.Add(new Category() { CategoryName = "Birthday" });
                context.Categories.Add(new Category() { CategoryName = "Wedding" });
                context.Categories.Add(new Category() { CategoryName = "Baby" });
                context.Categories.Add(new Category() { CategoryName = "Graduation" });
                context.Categories.Add(new Category() { CategoryName = "Easter" });
                context.Categories.Add(new Category() { CategoryName = "Christmas" });
                context.Categories.Add(new Category() { CategoryName = "Corporate" });
                context.Categories.Add(new Category() { CategoryName = "Outdoors" });
                context.Categories.Add(new Category() { CategoryName = "Dance" });
            }
            if (!context.Statuses.Any())
            {
                context.Statuses.Add(new Status() { StatusName = "Scheduled - Paid" });
                context.Statuses.Add(new Status() { StatusName = "Scheduled - Not Paid" });
                context.Statuses.Add(new Status() { StatusName = "Pending" });
                context.Statuses.Add(new Status() { StatusName = "Cancelled" });
                context.Statuses.Add(new Status() { StatusName = "Complete" });
            }
            if (!context.Confetti.Any())
            {
                context.Confetti.Add(new Confetti() { ConfettiName = "Baby Bottle", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Stack of Books", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Pink Ballerina", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Blue Cupcake", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Soccer Ball", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Red Truck", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Football", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Happy Birthday Cake", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Tiffany Box", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Volleyball", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Pure Barre", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Cheer Megaphone", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Apple", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Baseball", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Bats", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Champagne Glasses", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Blue Guitar", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Heart", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Basketball", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Emoji", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Pink Donut", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Unicorn", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Auburn", Active = true, Image = "/assets/confetti/thumbs/1.png" });
                context.Confetti.Add(new Confetti() { ConfettiName = "Alabama", Active = true, Image = "/assets/confetti/thumbs/1.png" });
            }

            context.SaveChanges();

            if (!context.Customers.Any())
            {
                var customers = new Customer[]
                {
                        new Customer{FirstName="Charlie",LastName="Brown",Email = "cbrown@mailinator.com",
                            Phone = "555-555-5555", ContactMethod = "Text", OderReceivedVia = "Facebook",
                            ReferredBy = "Friend", Created=DateTime.Now},
                        new Customer{FirstName="Lucy",LastName="Brown",Email = "lbrown@mailinator.com",
                            Phone = "555-555-5555", ContactMethod = "Call", OderReceivedVia = "Facebook",
                            ReferredBy = "Friend", Created=DateTime.Now},
                        new Customer{FirstName="Snoopy",LastName="Brown",Email = "sbrown@mailinator.com",
                            Phone = "555-555-5555", ContactMethod = "Text", OderReceivedVia = "Email",
                            ReferredBy = "", Created=DateTime.Now},
                        new Customer{FirstName="Meghan",LastName="Brown",Email = "cbrown@mailinator.com",
                            Phone = "555-555-5555", ContactMethod = "Messenger", OderReceivedVia = "Integram",
                            ReferredBy = "", Created=DateTime.Now},
                        new Customer{FirstName="Julie",LastName="Brown",Email = "cbrown@mailinator.com",
                            Phone = "555-555-5555", ContactMethod = "Text", OderReceivedVia = "Friend",
                            ReferredBy = "", Created=DateTime.Now},
                        new Customer{FirstName="Ashley",LastName="Brown",Email = "cbrown@mailinator.com",
                            Phone = "555-555-5555", ContactMethod = "Text", OderReceivedVia = "Friend",
                            ReferredBy = "", Created=DateTime.Now},
                        new Customer{FirstName="Amy",LastName="Brown",Email = "cbrow4n@mailinator.com",
                            Phone = "555-555-5555", ContactMethod = "Text", OderReceivedVia = "Friend",
                            ReferredBy = "", Created=DateTime.Now},
                        new Customer{FirstName="Courtney",LastName="Brown",Email = "cbrown4@mailinator.com",
                            Phone = "555-555-5555", ContactMethod = "Text", OderReceivedVia = "Friend",
                            ReferredBy = "", Created=DateTime.Now},
                        new Customer{FirstName="Hayden",LastName="Brown",Email = "cbrown5@mailinator.com",
                            Phone = "555-555-5555", ContactMethod = "Text", OderReceivedVia = "Friend",
                            ReferredBy = "", Created=DateTime.Now},
                        new Customer{FirstName="Brooklyn",LastName="Brown",Email = "bbrown@mailinator.com",
                            Phone = "555-555-5555", ContactMethod = "Text", OderReceivedVia = "Friend",
                            ReferredBy = "", Created=DateTime.Now},
                };
                context.Customers.AddRange(customers);
                context.SaveChanges();

                Random r = new Random(DateTime.Now.Millisecond);
                foreach (var c in customers)
                {
                    int x = r.Next(5, 50);
                    int s = r.Next(1, 5);
                    int e = r.Next(1, 7);

                    //create some orders
                    Console.WriteLine("s:" + s.ToString());
                    var ad = new Address()
                    {
                        AddressName = "Home",
                        Address1 = "555 South St",
                        City = "AL",
                        StateName = "AL",
                        CustomerId = c.CustomerId,
                        ZipCode = "35758"
                    };

                    var co = new CustomerOrder()
                    {
                        CustomerId = c.CustomerId,
                        SetupDate = DateTime.Now.AddDays(x),
                        PickUpDate = DateTime.Now.AddDays(x + 1),
                        RentPrice = 60.00,
                        EventTypeId = e,
                        Personalized = false,
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                        StatusId = s,
                        RentalAddress = ad, 
                    };
                    context.CustomerOrders.Add(co);

                    int o = r.Next(2, 4);
                    for (int i = 0; i <= o; i++)
                    {
                        //add confetti
                        int f = r.Next(1, 25);
                        var orderItems = new OrderItem()
                        {
                            CustomerOrder = co,
                            ConfettiId = f
                        };
                        context.OrderItems.Add(orderItems);
                    }

                    context.SaveChanges();

                }

                context.SaveChanges();
            }
        }
    }
}