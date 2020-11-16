using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
         
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));
           

            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        
                        Name = "Tesla",
                        ShortDesk = "Электоавтомобиль",
                        LongDesk = "Красивый быстрый и очень тихий, автомобиль премиум класса",
                        Img = "https://i0.wp.com/itc.ua/wp-content/uploads/2019/06/Tesla-Model-S-2gen.jpg?w=1280&quality=100&strip=all&ssl=1",
                        Price = 45000,
                        IsFavourite = false,
                        AvaiLable = true,
                        Category = Categories["Электомобили"]
                    },
                new Car
                {
                    
                    Name = "Audi E-tron",
                    ShortDesk = "Электоавтомобиль",
                    LongDesk = "Красивый быстрый и очень тихий, автомобиль премиум класса от концерна Audi",
                    Img = "https://img.drive.ru/i/0/5ba01408ec05c4bb2c00002b.jpg",
                    Price = 55000,
                    IsFavourite = true,
                    AvaiLable = true,
                    Category = Categories["Электомобили"]
                },
                 new Car
                 {
                    
                     Name = "BMW-M3",
                     ShortDesk = "Класический автомобиль",
                     LongDesk = "Красивый быстрый и очень быстрый , автомобиль премиум класса от концерна BMW",
                     Img = "https://kolesa-uploads.ru/-/e292722e-bb3d-41af-8770-3cfaf1cffaa5/bmw-m3-new-front2.jpg",
                     Price = 55000,
                     IsFavourite = false,
                     AvaiLable = true,
                     Category = Categories["Классические авто"]
                 },
                  new Car
                  {
                  
                      Name = "Toyota Camry",
                      ShortDesk = "Класический автомобиль",
                      LongDesk = "Красивый семейный и очень надежный, автомобиль М класса от концерна Toyota",
                      Img = "https://autoreview.ru/images/gallery/%D0%9D%D0%BE%D0%B2%D0%BE%D1%81%D1%82%D0%B8/2020/July/15/Toyota-Camry-XSE.jpg",
                      Price = 35000,
                      IsFavourite = true,
                      AvaiLable = true,
                      Category = Categories["Классические авто"]
                  },
                   new Car
                   {

                       Name = "Lada Vesta",
                       ShortDesk = "Класический автомобиль",
                       LongDesk = "Авто не очень, но для народа",
                       Img = "https://wroom.ru/i/cars2/lada_vestasport_1.jpg",
                       Price = 15000,
                       IsFavourite = false,
                       AvaiLable = true,
                       Category = Categories["Классические авто"]
                   }, 
                     new Car
                     {
                         Name = "Lexus IS",
                         ShortDesk = "Класический автомобиль",
                         LongDesk = "Бизнес сидан проверенный временем,красывый и надежный ",
                         Img = "https://avatars.mds.yandex.net/get-verba/1540742/2a00000172e05234923ed4d26fb64459e42a/cattouchret",
                         Price = 49000,
                         IsFavourite = true,
                         AvaiLable = true,
                         Category = Categories["Классические авто"]
                     }

                  ) ;


            }
            content.SaveChanges();


        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                    new Category{CategoruName="Электомобили", Desc = "Современный вид автотрансопрта "},
                    new Category{ CategoruName = "Классические авто", Desc = "Авто с двигателем внутренего сгорания" }
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                    {
                        category.Add(el.CategoruName, el);

                    }
                }
                return category;
            }

        }
    }
}
