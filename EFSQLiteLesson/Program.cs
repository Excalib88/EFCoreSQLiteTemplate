using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFSQLiteLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var db = new ShopContext())
            {
                db.Database.Migrate();

                var user = new User();
                user.Id = 0;
                user.Name = "Юлия";
                user.Login = "admin";
                user.Password = "admin";
                user.Mail = "admin@mail.ru";

                var product = new Product();
                product.Id = 0;
                product.Name = "Пылесос";
                product.Price = 9999;

                RemoveById(db, 1);
                //Write(db, user, product);
                Read(db);

                db.SaveChanges();
            }

            Console.ReadKey();
        }
        /// <summary>
        /// Теперь все действия можно совершать просто добавляя элементы в DbSet(это обычный список(List))
        /// ВАЖНО! Нужно сохранить изменения(SaveChanges)
        /// </summary>
        public static void Write(ShopContext context, User user, Product product)
        {
            context.Users.Add(user);
            context.Products.Add(product);
        }

        public static void Read(ShopContext context)
        {
            var users = context.Users.ToList();
            var products = context.Products.ToList();

            Console.WriteLine("Users:");

            foreach(var user in users)
            {
                Console.WriteLine($"{user.Id}, {user.Login}, {user.Password}, {user.Name}, {user.Mail}");
            }

            Console.WriteLine("Products:");

            foreach(var product in products)
            {
                Console.WriteLine($"{product.Id}, {product.Name}, {product.Price}");
            }

        }
        /// <summary>
        /// удаляет одну запись, если нужно несколько то можно через foreach перебрать все записи выборки убрав FirstOrDefault
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        public static void RemoveById(ShopContext context, int id)
        {
            var productItem = context.Products.ToList().Where(p => p.Id == id).FirstOrDefault();
            var userItem = context.Users.ToList().Where(user => user.Id == id).FirstOrDefault();

            if (productItem != null)
            {
                context.Products.Remove(productItem);

                Console.WriteLine("Запись из продуктов удалена");
            }
            if (userItem != null)
            {
                context.Users.Remove(userItem);

                Console.WriteLine("Запись из пользователей удалена");
            }

            Console.WriteLine("Запись не найдена");
            Read(context);
        }
    }
}
