
using WebAPI.Models;

namespace WebAPI.Seeds
{
    public static partial class SeedData
    {
        public static List<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    UserName = "bekzod@gmail.com",
                    Email = "bekzod@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Bekzod",
                    LastName = "Ubaydullaev",
                    PhoneNumber = "123-34-55",
                    Ssn = "1234"
                },
            
                new User
                {
                    UserName = "mukhammadsaid@gmail.com",
                    Email = "mukhammadsaid@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Mukhammadsaid",
                    LastName = "Mamasaidov",
                    PhoneNumber = "123-34-55",
                    Ssn = "1234"
                },
            
                new User
                {
                    UserName = "navruz@gmail.com",
                    Email = "navruz@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Navruz",
                    LastName = "Rakhimov",
                    PhoneNumber = "123-34-55",
                    Ssn = "1234"
                },
            
                new User
                {
                    UserName = "jasur@gmail.com",
                    Email = "jasur@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Jasur",
                    LastName = "Yusupov",
                    PhoneNumber = "123-34-55",
                    Ssn = "1234"
                },

                new User
                {
                    UserName = "strange@gmail.com",
                    Email = "strange@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Strange",
                    LastName = "Strange",
                    PhoneNumber = "123-34-55",
                    Ssn = "1234"
                },

                new User
                {
                    UserName = "iampass@gmail.com",
                    Email = "iampass@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Iampass",
                    LastName = "Iampass",
                    PhoneNumber = "123-34-55",
                    Ssn = "1234"
                },

                new User
                {
                    UserName = "passenger@gmail.com",
                    Email = "passenger@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Passenger",
                    LastName = "Passenger",
                    PhoneNumber = "123-34-55",
                    Ssn = "1234"
                }
            };
        }
    }
}